namespace Gaten.Net.GameRule.RubiksCube.v2
{
    public class AlgorithmGenerator
    {
        static string[] cases;

        /// <summary>
        /// 이전 상태와 이후 상태를 넣으면 알고리즘을 생성해주는 함수입니다.
        /// </summary>
        /// <param name="beforeCube">이전 상태의 큐브, 관계 없는 스티커는 Unknown으로 정의합니다.</param>
        /// <param name="afterCube">이후 상태의 큐브, 관계 없는 스티커는 Unknown으로 정의합니다.</param>
        /// <param name="rotationCodeLimits">회전 가능유형 정의, F,L,U,R,D,B 사용 가능합니다.</param>
        /// <param name="rotationCountLimits">회전 최대횟수 정의, 20 미만을 권장합니다.</param>
        /// <returns></returns>
        public static List<string> Generate(RubiksCube333 beforeCube, RubiksCube333 afterCube)
        {
            if (cases == null)
            {
                LoadRuRotation();
            }

            List<string> algorithms = new List<string>();

            foreach (var _case in cases)
            {
                var _beforeCube = beforeCube.Clone();
                _beforeCube.Rotate(_case);
                if (CheckCorrect(_beforeCube, afterCube))
                {
                    algorithms.Add(_case);
                }
            }

            return algorithms;
        }

        /// <summary>
        /// 올바르게 이후 상태로 되었는지 체크합니다.
        /// </summary>
        /// <param name="beforeCube">이전 상태의 큐브, Unknown 스티커는 체크하지 않습니다.</param>
        /// <param name="afterCube">이후 상태의 큐브, Unknown 스티커는 체크하지 않습니다.</param>
        /// <returns></returns>
        private static bool CheckCorrect(RubiksCube333 beforeCube, RubiksCube333 afterCube)
        {
            var targetStickers = afterCube.Stickers.FindAll(x => x.Sticker != StickerCode.Unknown);

            foreach (var sticker in targetStickers)
            {
                var sameSticker = beforeCube.Stickers.Find(x => x.Location.Equals(sticker.Location));
                if (sameSticker == null)
                {
                    return false;
                }

                if (!sticker.Sticker.Equals(sameSticker.Sticker))
                {
                    return false;
                }
            }

            return true;
        }

        private static void LoadRuRotation()
        {
            cases = File.ReadAllLines("RU.txt");
        }
    }
}
