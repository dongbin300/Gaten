namespace Gaten.Net.Language.Japanese
{
    public class JapaneseSentence
    {
        public string Text { get; set; }

        public JapaneseSentence()
        {

        }

        public JapaneseSentence(string text)
        {
            Text = text;
        }

        public string ToRomaji()
        {
            string result = string.Empty;
            foreach (var t in Text)
            {
                result += t switch
                {
                    'あ' or 'ア' => "a",
                    'い' or 'イ' => "i",
                    'う' or 'ウ' => "u",
                    'え' or 'エ' => "e",
                    'お' or 'オ' => "o",
                    'か' or 'カ' => "ka",
                    'き' or 'キ' => "ki",
                    'く' or 'ク' => "ku",
                    'け' or 'ケ' => "ke",
                    'こ' or 'コ' => "ko",
                    'さ' or 'サ' => "sa",
                    'し' or 'シ' => "shi",
                    'す' or 'ス' => "su",
                    'せ' or 'セ' => "se",
                    'そ' or 'ソ' => "so",
                    'た' or 'タ' => "ta",
                    'ち' or 'チ' => "chi",
                    'つ' or 'ツ' => "tsu",
                    'て' or 'テ' => "te",
                    'と' or 'ト' => "to",
                    'な' or 'ナ' => "na",
                    'に' or 'ニ' => "ni",
                    'ぬ' or 'ヌ' => "nu",
                    'ね' or 'ネ' => "ne",
                    'の' or 'ノ' => "no",
                    'は' or 'ハ' => "ha",
                    'ひ' or 'ヒ' => "hi",
                    'ふ' or 'フ' => "fu",
                    'へ' or 'ヘ' => "he",
                    'ほ' or 'ホ' => "ho",
                    'ま' or 'マ' => "ma",
                    'み' or 'ミ' => "mi",
                    'む' or 'ム' => "mu",
                    'め' or 'メ' => "me",
                    'も' or 'モ' => "mo",
                    'や' or 'ヤ' => "ya",
                    'ゆ' or 'ユ' => "yu",
                    'よ' or 'ヨ' => "yo",
                    'ら' or 'ラ' => "ra",
                    'り' or 'リ' => "ri",
                    'る' or 'ル' => "ru",
                    'れ' or 'レ' => "re",
                    'ろ' or 'ロ' => "ro",
                    'わ' or 'ワ' => "wa",
                    'を' or 'ヲ' => "wo",
                    'ん' or 'ン' => "n",
                    'っ' or 'ッ' => "t",
                    'が' or 'ガ' => "ga",
                    'ぎ' or 'ギ' => "gi",
                    'ぐ' or 'グ' => "gu",
                    'げ' or 'ゲ' => "ge",
                    'ご' or 'ゴ' => "go",
                    'ざ' or 'ザ' => "za",
                    'じ' or 'ジ' => "zi",
                    'ず' or 'ズ' => "zu",
                    'ぜ' or 'ゼ' => "ze",
                    'ぞ' or 'ゾ' => "zo",
                    'だ' or 'ダ' => "da",
                    'ぢ' or 'ヂ' => "di",
                    'づ' or 'ヅ' => "du",
                    'で' or 'デ' => "de",
                    'ど' or 'ド' => "do",
                    'ば' or 'バ' => "ba",
                    'び' or 'ビ' => "bi",
                    'ぶ' or 'ブ' => "bu",
                    'べ' or 'ベ' => "be",
                    'ぼ' or 'ボ' => "bo",
                    'ぱ' or 'パ' => "pa",
                    'ぴ' or 'ピ' => "pi",
                    'ぷ' or 'プ' => "pu",
                    'ぺ' or 'ペ' => "pe",
                    'ぽ' or 'ポ' => "po",
                    _ => ""
                };
            }

            return result;
        }

        public string ToKorean()
        {
            string result = string.Empty;
            foreach (var t in Text)
            {
                switch (t)
                {
                    case 'ん':
                    case 'ン':
                        result = result[..^1] + (char)(result[^1] + 4);
                        break;

                    case 'っ':
                    case 'ッ':
                        result = result[..^1] + (char)(result[^1] + 19);
                        break;

                    case 'ゃ':
                    case 'ャ':
                        result = result[..^1] + (char)(result[^1] - 504);
                        break;

                    case 'ゅ':
                    case 'ュ':
                        result = result[..^1] + (char)(result[^1] - 84);
                        break;

                    case 'ょ':
                    case 'ョ':
                        result = result[..^1] + (char)(result[^1] - 224);
                        break;
                }

                result += t switch
                {
                    'あ' or 'ア' => "아",
                    'い' or 'イ' => "이",
                    'う' or 'ウ' => "우",
                    'え' or 'エ' => "에",
                    'お' or 'オ' => "오",
                    'か' or 'カ' => "카",
                    'き' or 'キ' => "키",
                    'く' or 'ク' => "쿠",
                    'け' or 'ケ' => "케",
                    'こ' or 'コ' => "코",
                    'さ' or 'サ' => "사",
                    'し' or 'シ' => "시",
                    'す' or 'ス' => "스",
                    'せ' or 'セ' => "세",
                    'そ' or 'ソ' => "소",
                    'た' or 'タ' => "타",
                    'ち' or 'チ' => "치",
                    'つ' or 'ツ' => "츠",
                    'て' or 'テ' => "테",
                    'と' or 'ト' => "토",
                    'な' or 'ナ' => "나",
                    'に' or 'ニ' => "니",
                    'ぬ' or 'ヌ' => "누",
                    'ね' or 'ネ' => "네",
                    'の' or 'ノ' => "노",
                    'は' or 'ハ' => "하",
                    'ひ' or 'ヒ' => "히",
                    'ふ' or 'フ' => "후",
                    'へ' or 'ヘ' => "헤",
                    'ほ' or 'ホ' => "호",
                    'ま' or 'マ' => "마",
                    'み' or 'ミ' => "미",
                    'む' or 'ム' => "무",
                    'め' or 'メ' => "메",
                    'も' or 'モ' => "모",
                    'や' or 'ヤ' => "야",
                    'ゆ' or 'ユ' => "유",
                    'よ' or 'ヨ' => "요",
                    'ら' or 'ラ' => "라",
                    'り' or 'リ' => "리",
                    'る' or 'ル' => "루",
                    'れ' or 'レ' => "레",
                    'ろ' or 'ロ' => "로",
                    'わ' or 'ワ' => "와",
                    'を' or 'ヲ' => "오",
                    'が' or 'ガ' => "가",
                    'ぎ' or 'ギ' => "기",
                    'ぐ' or 'グ' => "구",
                    'げ' or 'ゲ' => "게",
                    'ご' or 'ゴ' => "고",
                    'ざ' or 'ザ' => "자",
                    'じ' or 'ジ' => "지",
                    'ず' or 'ズ' => "즈",
                    'ぜ' or 'ゼ' => "제",
                    'ぞ' or 'ゾ' => "조",
                    'だ' or 'ダ' => "다",
                    'ぢ' or 'ヂ' => "지",
                    'づ' or 'ヅ' => "즈",
                    'で' or 'デ' => "데",
                    'ど' or 'ド' => "도",
                    'ば' or 'バ' => "바",
                    'び' or 'ビ' => "비",
                    'ぶ' or 'ブ' => "부",
                    'べ' or 'ベ' => "베",
                    'ぼ' or 'ボ' => "보",
                    'ぱ' or 'パ' => "파",
                    'ぴ' or 'ピ' => "피",
                    'ぷ' or 'プ' => "푸",
                    'ぺ' or 'ペ' => "페",
                    'ぽ' or 'ポ' => "포",
                    _ => ""
                };
            }

            return result;
        }
    }
}
