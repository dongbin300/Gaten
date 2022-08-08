namespace Gaten.GameTool.GITADORA.GDMSM
{
    public class Util
    {
        /// <summary>
        /// 스크린샷 캡처 이질도
        /// </summary>
        /// <param name="screenShotFiles"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static double DislocationRatio(FileInfo[] screenShotFiles, double threshold, int frame)
        {
            int standardInterval = (int)(1000.0 / ((double)30 / frame));
            int count = 0;

            for (int i = 0; i < screenShotFiles.Length - 1; i++)
            {
                int a = int.Parse(screenShotFiles[i].Name.Substring(screenShotFiles[i].Name.Length - 7, 3));
                int b = int.Parse(screenShotFiles[i + 1].Name.Substring(screenShotFiles[i].Name.Length - 7, 3));
                if (b - a < 0)
                {
                    b += 1000;
                }

                if (b - a >= standardInterval * threshold)
                {
                    count++;
                }
            }

            return (double)count / screenShotFiles.Length;
        }
    }
}
