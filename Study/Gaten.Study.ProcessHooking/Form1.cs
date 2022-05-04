using System.Diagnostics;
//.NET6 System.Windows.Automation 패키지 못찾음

namespace Gaten.Study.ProcessHooking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string GetChromeCurrentCaption()
        {
            Process[] chromeProcess = Process.GetProcessesByName("chrome");
            foreach (Process chrome in chromeProcess)
            {
                if (chrome.MainWindowHandle == IntPtr.Zero) continue;

                //AutomationElement element = AutomationElement.FromHandle(chrome.MainWindowHandle);
                //return element.Current.Name;
            }
            return "";
        }

        string GetChromeCurrentUrl()
        {
            Process[] procsChrome = Process.GetProcessesByName("chrome");
            foreach (Process chrome in procsChrome)
            {
                if (chrome.MainWindowHandle == IntPtr.Zero)
                    continue;

                //AutomationElement element = AutomationElement.FromHandle(chrome.MainWindowHandle);
                //if (element == null) return null;
                //Condition conditions = new AndCondition(
                //    new PropertyCondition(AutomationElement.ProcessIdProperty, chrome.Id),
                //    new PropertyCondition(AutomationElement.IsControlElementProperty, true),
                //    new PropertyCondition(AutomationElement.IsContentElementProperty, true),
                //    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                //AutomationElement elementx = element.FindFirst(TreeScope.Descendants, conditions);
                //return ((ValuePattern)elementx.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
            }
            return null;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string osuBeatmapUrl = GetChromeCurrentUrl();
            string[] urlData = osuBeatmapUrl.Split('/');
        }
    }
}