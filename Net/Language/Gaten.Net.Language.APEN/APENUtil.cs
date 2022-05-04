using Gaten.Net.Language.Korean;

namespace Gaten.Net.Language.APEN
{
    public class APENUtil
    {
        /// <summary>
        /// 종성이 'ㄹ'이면 true
        /// </summary>
        static bool isFinalL = false;

        /// <summary>
        /// 외래어이면 true
        /// </summary>
        static bool isLoanword = false;

        /// <summary>
        /// 독립이면 true
        /// </summary>
        static bool isIndependent = false;

        public static EncodeBlock Encode(string plainText)
        {
            EncodeBlock result = new();

            var plainArray = plainText.ToCharArray();
            foreach (char c in plainArray)
            {
                result.AddBlock(c, EncodeOne(c));
            }

            if (isLoanword)
            {
                isLoanword = false;
                result.AddBlock(EncodeBlock.NONE_TEXT, "]");
            }

            if (isIndependent)
            {
                isIndependent = false;
                result.AddBlock(EncodeBlock.NONE_TEXT, ")!");
            }

            return result;
        }

        public static string EncodeSimple(string plainText)
        {
            string result = string.Empty;

            var plainArray = plainText.ToCharArray();
            foreach (char c in plainArray)
            {
                result += EncodeOne(c);
            }

            if (isLoanword)
            {
                isLoanword = false;
                result += "]";
            }

            if (isIndependent)
            {
                isIndependent = false;
                result += ")!";
            }

            return result;
        }

        public static string Decode(string apenText)
        {
            string result = string.Empty;

            return result;
        }

        public static string EncodeOne(char letter)
        {
            string result = string.Empty;

            // 한글
            if (HangeulUtil.IsHangeul(letter))
            {
                if (isLoanword)
                {
                    isLoanword = false;
                    result += "]";
                }

                if (isIndependent)
                {
                    isIndependent = false;
                    result += ")!";
                }

                var elements = HangeulUtil.DivideHangeul(letter);

                result += EncodeElement(elements[0]);
                isFinalL = false;

                result += EncodeElement(elements[1]);

                if (elements.Length == 3)
                {
                    result += EncodeElement(elements[2]);
                    if (elements[2] == 0x11af)
                    {
                        isFinalL = true;
                    }
                }
            }
            // 띄어쓰기
            else if (letter == ' ')
            {
                result += " ";
            }
            // 독립 한글
            else if (HangeulUtil.IsHangeulIndependent(letter))
            {
                if (isLoanword)
                {
                    isLoanword = false;
                    result += "]";
                }

                var element = letter;

                if (!isIndependent)
                {
                    isIndependent = true;
                    result += "(";
                }
                result += EncodeIndependentElement(element);
            }
            else
            {
                if (isIndependent)
                {
                    isIndependent = false;
                    result += ")!";
                }

                var element = letter;

                if (!isLoanword)
                {
                    isLoanword = true;
                    result += "[";
                }
                result += EncodeLoanword(element);
            }
            //// 영어
            //else if ((letter >= 0x61 && letter <= 0x7A) || (letter >= 0x41 && letter <= 0x5A))
            //{
            //    //
            //}
            //// 숫자
            //else if (letter >= 0x30 && letter <= 0x39)
            //{
            //    //
            //}
            //// 이외
            //else
            //{

            //}

            return result;
        }

        public static string EncodeElement(char element)
        {
            return element switch
            {
                // 초성
                (char)0x1100 => "g",
                (char)0x1101 => "g'",
                (char)0x1102 => "n",
                (char)0x1103 => "d",
                (char)0x1104 => "d'",
                (char)0x1105 => isFinalL ? "'" : "r",
                (char)0x1106 => "m",
                (char)0x1107 => "b",
                (char)0x1108 => "b'",
                (char)0x1109 => "s",
                (char)0x110a => "s'",
                (char)0x110b => "",
                (char)0x110c => "j",
                (char)0x110d => "j'",
                (char)0x110e => "q",
                (char)0x110f => "k",
                (char)0x1110 => "t",
                (char)0x1111 => "p",
                (char)0x1112 => "h",

                // 중성
                (char)0x1161 => ".",
                (char)0x1162 => ".'",
                (char)0x1163 => "._",
                (char)0x1164 => ".=",
                (char)0x1165 => "o'",
                (char)0x1166 => "'",
                (char)0x1167 => "o=",
                (char)0x1168 => "'_",
                (char)0x1169 => "o",
                (char)0x116a => ".~",
                (char)0x116b => "'=",
                (char)0x116c => "i=",
                (char)0x116d => "o_",
                (char)0x116e => "-",
                (char)0x116f => "o~",
                (char)0x1170 => "'~",
                (char)0x1171 => "i~",
                (char)0x1172 => "-_",
                (char)0x1173 => "-'",
                (char)0x1174 => "i_",
                (char)0x1175 => "i",

                // 종성
                (char)0x11a8 => "k",
                (char)0x11a9 => "k'",
                (char)0x11aa => "kt",
                (char)0x11ab => "n",
                (char)0x11ac => "nt",
                (char)0x11ad => "nh",
                (char)0x11ae => "t",
                (char)0x11af => "l",
                (char)0x11b0 => "lk",
                (char)0x11b1 => "lm",
                (char)0x11b2 => "lp",
                (char)0x11b3 => "lt",
                (char)0x11b4 => "lt",
                (char)0x11b5 => "lp",
                (char)0x11b6 => "lh",
                (char)0x11b7 => "m",
                (char)0x11b8 => "p",
                (char)0x11b9 => "pt",
                (char)0x11ba => "t",
                (char)0x11bb => "w", // t'
                (char)0x11bc => "n'",
                (char)0x11bd => "t",
                (char)0x11be => "t",
                (char)0x11bf => "k",
                (char)0x11c0 => "t",
                (char)0x11c1 => "p",
                (char)0x11c2 => "h",

                _ => ""
            };
        }

        public static string EncodeIndependentElement(char element)
        {
            return element switch
            {
                // 초성
                (char)0x3131 => "g",
                (char)0x3132 => "g'",
                (char)0x3133 => "gs",
                (char)0x3134 => "n",
                (char)0x3135 => "nj",
                (char)0x3136 => "nh",
                (char)0x3137 => "d",
                (char)0x3138 => "d'",
                (char)0x3139 => "r",
                (char)0x313a => "rg",
                (char)0x313b => "rm",
                (char)0x313c => "rb",
                (char)0x313d => "rs",
                (char)0x313e => "rt",
                (char)0x313f => "rp",
                (char)0x3140 => "rh",
                (char)0x3141 => "m",
                (char)0x3142 => "b",
                (char)0x3143 => "b'",
                (char)0x3144 => "bs",
                (char)0x3145 => "s",
                (char)0x3146 => "s'",
                (char)0x3147 => "'",
                (char)0x3148 => "j",
                (char)0x3149 => "j'",
                (char)0x314a => "q",
                (char)0x314b => "k",
                (char)0x314c => "t",
                (char)0x314d => "p",
                (char)0x314e => "h",


                // 중성
                (char)0x314f => ".",
                (char)0x3150 => ".'",
                (char)0x3151 => "._",
                (char)0x3152 => ".=",
                (char)0x3153 => "o'",
                (char)0x3154 => "'",
                (char)0x3155 => "o=",
                (char)0x3156 => "'_",
                (char)0x3157 => "o",
                (char)0x3158 => ".~",
                (char)0x3159 => "'=",
                (char)0x315a => "i=",
                (char)0x315b => "o_",
                (char)0x315c => "-",
                (char)0x315d => "o~",
                (char)0x315e => "'~",
                (char)0x315f => "i~",
                (char)0x3160 => "-_",
                (char)0x3161 => "-'",
                (char)0x3162 => "i_",
                (char)0x3163 => "i",

                _ => ""
            };
        }

        public static string EncodeLoanword(char element)
        {
            return element.ToString();
        }
    }
}