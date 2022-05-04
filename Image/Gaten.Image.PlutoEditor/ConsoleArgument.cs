using System.Drawing.Imaging;

namespace Gaten.Image.PlutoEditor
{
    public class ConsoleArgument
    {
        public static string SaveTempScene(System.Drawing.Image bitmap)
        {
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
            bitmap.Save(fileName, ImageFormat.Bmp);

            return fileName;
        }
    }
}
