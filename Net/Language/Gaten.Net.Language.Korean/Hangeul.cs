namespace Gaten.Net.Language.Korean
{
    public class Hangeul
    {
        public KoreanSeparateOption separateOption { get; set; }
        public readonly static string StringArea1 = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
        public readonly static string StringArea2 = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
        public readonly static string StringArea3 = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
        public string Area1 { get; set; } = string.Empty;
        public string Area2 { get; set; } = string.Empty;
        public string Area3 { get; set; } = string.Empty;
        public string AdditionalArea2 { get; set; } = string.Empty;
        public string AdditionalArea3 { get; set; } = string.Empty;

        public Hangeul()
        { 
        }

        /// <summary>
        /// 초/중/종성 출력
        /// ex) 괆=>ㄱㅘㄻ(Light), ㄱㅗㅏㄹㅁ(Heavy)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (separateOption)
            {
                case KoreanSeparateOption.Light:
                    return Area1 + Area2 + Area3;
                case KoreanSeparateOption.Heavy:
                    Area2 = AdditionalArea2 == string.Empty ? Area2 : Area2 + AdditionalArea2;
                    Area3 = AdditionalArea3 == string.Empty ? Area3 : Area3 + AdditionalArea3;
                    return Area1 + Area2 + Area3;
            }
            return string.Empty;
        }

        public int GetAreaCount()
        {
            int count = 0;

            if (!string.IsNullOrEmpty(Area1) && Area1 != " ")
            {
                count++;
            }
            if (!string.IsNullOrEmpty(Area2) && Area2 != " ")
            {
                count++;
            }
            if (!string.IsNullOrEmpty(Area3) && Area3 != " ")
            {
                count++;
            }
            if (!string.IsNullOrEmpty(AdditionalArea2) && AdditionalArea2 != " ")
            {
                count++;
            }
            if (!string.IsNullOrEmpty(AdditionalArea3) && AdditionalArea3 != " ")
            {
                count++;
            }

            return count;
        }
    }
}
