using Gaten.Net.Extensions;
using Gaten.Net.GameRule.GITADORA;
using Gaten.Net.Image;

using Path = Gaten.Net.GameRule.GITADORA.Path;

namespace Gaten.GameTool.GITADORA.GDMSM
{
    public class FumenParse
    {
        private readonly Bitmap bitmap;
        private readonly List<Color> colors = new();
        private readonly List<Path> paths = new();
        private List<Path> bpPaths = new();
        private readonly List<Path> bpPathsTemp = new();
        private List<Path> spPaths = new();
        private readonly List<Path> spPathsTemp = new();
        private readonly List<Path> noPaths = new();

        // x1.0
        private readonly int[] startXs = { 0, 22, 94, 143, 194, 251, 306, 369, 418, 472, 538 };
        private readonly int[] noteWidths = { 0, 64, 46, 48, 54, 46, 60, 46, 46, 64 };

        // x0.7
        //int[] startXs = { 0, 22, 94, 143, 194, 251, 306, 369, 418, 472, 538 };
        //int[] noteWidths = { 0, 64, 46, 48, 54, 46, 60, 46, 46, 64 };

        private readonly int noteHeight = 10;
        private readonly int inspectStartX = 10;
        private readonly int noteInspectY = 4;
        private readonly int PhraseInspectY = 2;
        //int bigPhraseInspectY = 1;
        //int smallPhraseInspectY = 1;


        public FumenParse(Bitmap bitmap)
        {
            this.bitmap = bitmap;

            double ratio = 1.0;
            for (int i = 0; i < startXs.Length; i++)
            {
                startXs[i] = (int)(startXs[i] * ratio);
            }

            for (int i = 0; i < noteWidths.Length; i++)
            {
                noteWidths[i] = (int)(noteWidths[i] * ratio);
            }

            noteHeight = (int)(noteHeight * ratio);
        }

        /// <summary>
        /// 보면 분석
        /// Bitmap Image -> .txt File
        /// 
        /// 1,2픽셀 차이는 크게 상관없으니까
        /// 고정픽셀로 해서 중간지점부터체킹하는것이 도움이됨
        /// 그러므로 첫 노트9개를 구분하는건 x좌표 고정값줌
        /// 고정값을 줄때는 각 노트의 width로 줌
        /// 그리고 체킹은 startXs+5부터 체킹함
        /// 
        /// 체킹 알고리즘
        /// 범위: X: startXs+5(inspectStartX)~startXs+5+noteWidths-10 , Y: 그위치~noteHeight-2
        /// 줄단위로 체킹하고 평균값이 너무높은(하얀색에가까운)줄은 스킵하고
        /// 전체 평균을 구한다
        /// 구해서 검은색 threshold를 넘으면 노트로 인식
        /// 
        /// 라인 체크:
        /// 라인체크는 startXs부터 체킹함
        /// 
        /// 체킹알고리즘:
        /// 범위: X: startXs~startXs+startXs[i+1], Y: 2픽셀
        /// BP먼저 체크하고 SP체크
        /// BP체크는 Y 2픽셀, SP체크는 Y 1픽셀의 평균값
        /// BP: 130, 130, 130
        /// SP: 84, 84, 84
        /// 
        /// 라인 인식:
        /// 9트랙의 모든 BP,SP 정보를 모아서
        /// 4트랙 이상 같은 포지션에서 라인을 인식했다면 그 포지션은 해당 라인이 존재하는것임
        /// 9트랙을 최종적으로 하나의 채보텍스트파일로 합칠때 이걸 취합함
        /// 
        /// </summary>
        public List<Path> Parse()
        {
            // RGB 정보 가져오기
            LockBitmap lockBitmap = new(bitmap);
            lockBitmap.LockBits();

            for (int i = 0; i < lockBitmap.Height; i++)
            {
                for (int j = 0; j < lockBitmap.Width; j++)
                {
                    colors.Add(lockBitmap.GetPixel(j, i));
                }
            }

            lockBitmap.UnlockBits();
            lockBitmap.Dispose();

            // 트랙별로 분석
            for (int i = 1; i <= 9; i++)
            {
                ParseByTrack(i);
            }

            // 소절선 대절선 취합
            AssembleLines();

            // 노트 리스트 정렬
            SortNotePaths();

            // paths에 추가
            paths.AddRange(bpPaths);
            paths.AddRange(spPaths);
            paths.AddRange(noPaths);

            // 타이밍 평준화
            string result = NormalizeTiming();

            return result switch
            {
                "negative" => null,
                _ => paths,// 반환
            };
        }

        public void AssembleLines()
        {
            List<Path> removePaths = new();
            bpPaths = bpPathsTemp.Distinct(new LinePathComparer()).ToList();
            bpPaths.Sort(new LinePathComparer());
            foreach (Path path in bpPaths)
            {
                if (bpPathsTemp.Count(p => p.timing.Equals(path.timing)) < 4)
                {
                    removePaths.Add(path);
                }
            }
            bpPaths = bpPaths.Except(removePaths).ToList();

            List<Path> removePaths2 = new();
            spPaths = spPathsTemp.Distinct(new LinePathComparer()).ToList();
            spPaths.Sort(new LinePathComparer());
            foreach (Path path in spPaths)
            {
                if (spPathsTemp.Count(p => p.timing.Equals(path.timing)) < 4)
                {
                    removePaths2.Add(path);
                }
            }
            spPaths = spPaths.Except(removePaths2).ToList();
        }

        public void SortNotePaths()
        {
            noPaths.Sort(new NotePathComparer());
        }

        public string NormalizeTiming()
        {
            double StartBigPhraseTiming = 96.0;
            double BigPhraseGap = 700.0;

            double currentGap = bpPaths[1].timing - bpPaths[0].timing;
            double ef = BigPhraseGap / currentGap;
            foreach (Path path in paths)
            {
                path.timing *= ef;
            }

            double num = paths[0].timing - StartBigPhraseTiming;
            foreach (Path path in paths)
            {
                path.timing -= num;

                /*if (path.timing < 0)
                {
                    return "negative";
                }*/
            }

            return "";
        }

        public void ParseByTrack(int trackNum)
        {
            for (int i = 0; i < bitmap.Height; i++)
            {
                Color pixelColor = colors[(i * bitmap.Width) + startXs[trackNum] + 5];

                // 검정색은 스킵
                if (pixelColor.IsBlack(30))
                {
                    continue;
                }

                if (CheckNote(trackNum, i, startXs[trackNum] + 5))
                {
                    i += noteHeight * 2;
                    continue;
                }

                if (CheckLine(trackNum, i, startXs[trackNum] + 5))
                {
                    i += PhraseInspectY * 5;
                    continue;
                }
            }
        }

        public bool CheckNote(int trackNum, int i, int j)
        {
            int life = 0;
            List<Color> inspectColors = new();

            // 검은색 픽셀이 5픽셀 이상 나오면 노트가 아님
            for (int t = i; t < i + noteInspectY; t++)
            {
                for (int u = j + inspectStartX; u < j + inspectStartX + noteWidths[trackNum] - 20; u++)
                {
                    Color pixelColor = colors[(t * bitmap.Width) + u];

                    if (pixelColor.IsBlack(20))
                    {
                        life++;
                        if (life >= 5)
                        {
                            return false;
                        }
                    }

                    inspectColors.Add(pixelColor);
                }
            }

            //Color averageColor = Color.FromArgb((int)inspectColors.Average(ic => ic.R), (int)inspectColors.Average(ic => ic.G), (int)inspectColors.Average(ic => ic.B));

            // 노트
            //if (!ImageHelper.IsBlack(averageColor, 60))
            {
                noPaths.Add(new Path()
                {
                    type = Path.Type.Note,
                    timing = bitmap.Height - (i + (noteHeight / 2)) + 1,
                    noteNum = trackNum
                });

                return true;
            }

            //return false;
        }

        public bool CheckLine(int trackNum, int i, int j)
        {
            // 픽셀 RGB 평균값이 60 이상이고
            if (colors[(i * bitmap.Width) + startXs[trackNum]].RGBAverage() < 60)
            {
                return false;
            }

            List<Color> inspectColors = new();
            for (int t = 0; t < 10; t++)
            {
                inspectColors.Add(colors[(i * bitmap.Width) + startXs[trackNum] + t]);
            }

            // 가로 10픽셀 연속 같은 색깔이면 라인으로 인식
            if (!inspectColors.IsSameColor(20))
            {
                return false;
            }

            // 라인으로 인식된 픽셀부터 20*2 픽셀의 RGB 평균값
            int num1 = colors.AverageOfInspectX(i, j, bitmap.Width, 20).RGBAverage();
            int num2 = colors.AverageOfInspectX(i + 1, j, bitmap.Width, 20).RGBAverage();
            int num = (num1 + num2) / 2;

            if (num > 100 && (num1 > 110 || num2 > 110))
            {
                bpPathsTemp.Add(new Path()
                {
                    type = Path.Type.BigPhrase,
                    timing = bitmap.Height - i
                });
            }
            else
            {
                spPathsTemp.Add(new Path()
                {
                    type = Path.Type.SmallPhrase,
                    timing = bitmap.Height - i
                });
            }

            return true;
        }
    }
}
