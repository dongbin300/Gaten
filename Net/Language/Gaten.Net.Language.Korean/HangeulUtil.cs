namespace Gaten.Net.Language.Korean
{
    public class HangeulUtil
    {
        private const int INITIAL_COUNT = 19;
        private const int MEDIAL_COUNT = 21;
        private const int FINAL_COUNT = 28;
        private const int HANGUL_UNICODE_START_INDEX = 0xac00;
        private const int HANGUL_UNICODE_END_INDEX = 0xD7A3;
        private const int INITIAL_START_INDEX = 0x1100;
        private const int MEDIAL_START_INDEX = 0x1161;
        private const int FINAL_START_INDEX = 0x11a7;

        private const int HANGUL_INDEPENDENT_UNICODE_START_INDEX = 0x3131;
        private const int HANGUL_INDEPENDENT_UNICODE_END_INDEX = 0x3163;

        public static bool IsHangeul(char source)
        {
            return HANGUL_UNICODE_START_INDEX <= source && source <= HANGUL_UNICODE_END_INDEX;
        }

        public static bool IsHangeul(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (HANGUL_UNICODE_START_INDEX > source[i] || source[i] > HANGUL_UNICODE_END_INDEX)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsHangeulIndependent(char source)
        {
            return HANGUL_INDEPENDENT_UNICODE_START_INDEX <= source && source <= HANGUL_INDEPENDENT_UNICODE_END_INDEX;
        }

        public static char[] DivideHangeul(char source)
        {
            if (!IsHangeul(source))
            {
                return Array.Empty<char>();
            }

            int index = source - HANGUL_UNICODE_START_INDEX;
            int initial = INITIAL_START_INDEX + index / (MEDIAL_COUNT * FINAL_COUNT);
            int medial = MEDIAL_START_INDEX + (index % (MEDIAL_COUNT * FINAL_COUNT)) / FINAL_COUNT;
            int final = FINAL_START_INDEX + index % FINAL_COUNT;

            if (final == 4519)
            {
                return new char[] { (char)initial, (char)medial };
            }
            else
            {
                return new char[] { (char)initial, (char)medial, (char)final };
            }
        }
    }
}