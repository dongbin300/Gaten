using Gaten.Image.PlutoEditor.Panel;

namespace Gaten.Image.PlutoEditor
{
    public class UserSetting
    {
        public static bool Grid { get; set; }
        public static PPanel SelectedPanel { get; set; } = new();
    }
}
