namespace Gaten.Game.Dung_Eo_Ri
{
    public class ImageUtil
    {
        public static Image GetResourceImage(string path)
        {
            string ImageResourcesPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.ToString(), "Resources/Images");
            return Image.FromFile(Path.Combine(ImageResourcesPath, path));
        }
    }
}
