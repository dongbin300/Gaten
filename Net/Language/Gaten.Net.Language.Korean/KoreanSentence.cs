namespace Gaten.Net.Language.Korean
{
    public enum KoreanSeparateOption
    {
        Light,
        Heavy
    }

    public class KoreanSentence
    {
        public string KoreanString { get; set; }

        public KoreanSentence()
        {
        }

        public KoreanSentence(char letter)
        {
            KoreanString = letter.ToString();
        }

        public KoreanSentence(string str)
        {
            KoreanString = str;
        }

        /// <summary>
        /// 초/중/종성 분리
        /// </summary>
        /// <param name="separateOption"></param>
        /// <returns></returns>
        public List<Hangeul> Separate(KoreanSeparateOption separateOption = KoreanSeparateOption.Light)
        {
            List<Hangeul> h = new List<Hangeul>();

            char[] letters = KoreanString.ToCharArray();

            foreach (char letter in letters)
            {
                // 한글이 아니면 탈출
                if ((letter < 0xAC00) || (letter > 0xD79F))
                    continue;

                int code = letter - 0xAC00;
                string Area1 = Hangeul.StringArea1[code / (21 * 28)].ToString();

                code = code % (21 * 28);
                string Area2 = Hangeul.StringArea2[code / 28].ToString();

                code = code % 28;
                string Area3 = Hangeul.StringArea3[code].ToString();

                string AdditionalArea2 = string.Empty;
                string AdditionalArea3 = string.Empty;

                if (separateOption == KoreanSeparateOption.Heavy)
                {
                    switch (Area2)
                    {
                        case "ㅘ":
                            Area2 = "ㅗ";
                            AdditionalArea2 = "ㅏ";
                            break;
                        case "ㅙ":
                            Area2 = "ㅗ";
                            AdditionalArea2 = "ㅐ";
                            break;
                        case "ㅚ":
                            Area2 = "ㅗ";
                            AdditionalArea2 = "ㅣ";
                            break;
                        case "ㅝ":
                            Area2 = "ㅜ";
                            AdditionalArea2 = "ㅓ";
                            break;
                        case "ㅞ":
                            Area2 = "ㅜ";
                            AdditionalArea2 = "ㅔ";
                            break;
                        case "ㅟ":
                            Area2 = "ㅜ";
                            AdditionalArea2 = "ㅣ";
                            break;
                        case "ㅢ":
                            Area2 = "ㅡ";
                            AdditionalArea2 = "ㅣ";
                            break;
                    }
                    switch (Area3)
                    {
                        case " ":
                            Area3 = string.Empty;
                            break;
                        case "ㄳ":
                            Area3 = "ㄱ";
                            AdditionalArea3 = "ㅅ";
                            break;
                        case "ㄵ":
                            Area3 = "ㄴ";
                            AdditionalArea3 = "ㅈ";
                            break;
                        case "ㄶ":
                            Area3 = "ㄴ";
                            AdditionalArea3 = "ㅎ";
                            break;
                        case "ㄺ":
                            Area3 = "ㄹ";
                            AdditionalArea3 = "ㄱ";
                            break;
                        case "ㄻ":
                            Area3 = "ㄹ";
                            AdditionalArea3 = "ㅁ";
                            break;
                        case "ㄼ":
                            Area3 = "ㄹ";
                            AdditionalArea3 = "ㅂ";
                            break;
                        case "ㄽ":
                            Area3 = "ㄹ";
                            AdditionalArea3 = "ㅅ";
                            break;
                        case "ㄾ":
                            Area3 = "ㄹ";
                            AdditionalArea3 = "ㅌ";
                            break;
                        case "ㄿ":
                            Area3 = "ㄹ";
                            AdditionalArea3 = "ㅍ";
                            break;
                        case "ㅀ":
                            Area3 = "ㄹ";
                            AdditionalArea3 = "ㅎ";
                            break;
                        case "ㅄ":
                            Area3 = "ㅂ";
                            AdditionalArea3 = "ㅅ";
                            break;
                    }

                }

                h.Add(new Hangeul()
                {
                    separateOption = separateOption,
                    Area1 = Area1,
                    Area2 = Area2,
                    Area3 = Area3,
                    AdditionalArea2 = AdditionalArea2,
                    AdditionalArea3 = AdditionalArea3
                });
            }
            return h;
        }

        /// <summary>
        /// 한글의 초성만 출력
        /// </summary>
        /// <returns></returns>
        public string ToChosung()
        {
            List<Hangeul> hangeul = Separate();
            string str = string.Empty;

            foreach (Hangeul h in hangeul)
                str += h.Area1;

            return str;
        }

        /// <summary>
        /// 한글의 중성만 출력
        /// </summary>
        /// <returns></returns>
        public string ToJungsung()
        {
            List<Hangeul> hangeul = Separate();
            string str = string.Empty;

            foreach (Hangeul h in hangeul)
                str += h.Area2;

            return str;
        }

        /// <summary>
        /// 한글의 종성만 출력
        /// </summary>
        /// <returns></returns>
        public string ToJongsung()
        {
            List<Hangeul> hangeul = Separate();
            string str = string.Empty;

            foreach (Hangeul h in hangeul)
                str += h.Area3;

            return str;
        }
    }
}
