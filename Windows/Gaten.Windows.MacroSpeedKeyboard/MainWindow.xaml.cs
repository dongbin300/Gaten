using System.Drawing;
using System.Windows;
using System.Windows.Media;

namespace Gaten.Windows.MacroSpeedKeyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(500);

        private readonly Hid myHid = new();
        private IntPtr myHidPtr;
        private readonly Hids.HidLib myHidLib = new();

        public MainWindow()
        {
            InitializeComponent();

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {

            }
            catch
            {
            }
        }

        private void KeyBoardVersion_Check()
        {
            //byte[] arrayBuff = new byte[65];
            //MainForm.KeyParam.ReportID = 0;
            //arrayBuff[0] = 0;
            //arrayBuff[1] = 0;
            //if (WriteMode == 0)
            //{
            //    if ((byte)myHid.Write(new ReportEventArgs(MainForm.KeyParam.ReportID, arrayBuff)) == 0)
            //    {
            //        MainForm.KeyParam.ReportID = 0;
            //    }
            //    else
            //    {
            //        MainForm.KeyParam.ReportID = 2;
            //        MainForm.KeyParam.ReportID = (byte)myHid.Write(new ReportEventArgs(MainForm.KeyParam.ReportID, arrayBuff)) == 0 ? (byte)2 : (byte)3;
            //    }
            //}
            //else
            //{
            //    if (WriteMode != 1)
            //    {
            //        return;
            //    }

            //    MainForm.KeyParam.ReportID = 3;
            //    if (myHidLib.WriteDevice(MainForm.KeyParam.ReportID, arrayBuff))
            //    {
            //        MainForm.KeyParam.ReportID = 3;
            //    }
            //    else
            //    {
            //        MainForm.KeyParam.ReportID = 0;
            //        if (myHidLib.WriteDevice(MainForm.KeyParam.ReportID, arrayBuff))
            //        {
            //            MainForm.KeyParam.ReportID = 0;
            //        }
            //        else
            //        {
            //            MainForm.KeyParam.ReportID = 2;
            //            if (!myHidLib.WriteDevice(MainForm.KeyParam.ReportID, arrayBuff))
            //            {
            //                return;
            //            }

            //            MainForm.KeyParam.ReportID = 2;
            //        }
            //    }
            //}
        }

        private void AutoCheckUsb()
        {
            if ((int)(myHidPtr = myHid.OpenDevice(4489, 34960)) != -1)
            {
                KeyBoardVersion_Check();
                ConnectionText.Text = "Connected";
                ConnectionText.Foreground = System.Windows.Media.Brushes.Lime;
            }
            else
            {
                ConnectionText.Text = "Not Connected";
                ConnectionText.Foreground = System.Windows.Media.Brushes.Gray;
            }

            //if (WriteMode == 0)
            //{
            //    if (!myHid.Opened)
            //    {
            //        if ((int)(myHidPtr = myHid.OpenDevice(4489, 34960)) != -1)
            //        {
            //            KeyBoardVersion_Check();
            //            stateLabel.Text = "Connected";
            //            stateLabel.BackColor = stateLabel.BackColor = Color.Green;
            //        }
            //        else
            //        {
            //            stateLabel.Text = "Not Connected";
            //            stateLabel.BackColor = stateLabel.BackColor = Color.Red;
            //        }
            //    }
            //    else
            //    {
            //        stateLabel.Text = "Connected";
            //        stateLabel.BackColor = stateLabel.BackColor = Color.Green;
            //    }
            //}
            //else
            //{
            //    if (WriteMode != 1)
            //    {
            //        return;
            //    }

            //    if (!myHidLib.Get_Dev_Sta())
            //    {
            //        if (myHidLib.Connect_Device())
            //        {
            //            KeyBoardVersion_Check();
            //            stateLabel.Text = "Connected";
            //            stateLabel.BackColor = stateLabel.BackColor = Color.Green;
            //        }
            //        else
            //        {
            //            stateLabel.Text = "Not Connected";
            //            stateLabel.BackColor = stateLabel.BackColor = Color.Red;
            //        }
            //    }
            //    else if (myHidLib.Check_Disconnect())
            //    {
            //        stateLabel.Text = "Connected";
            //        stateLabel.BackColor = stateLabel.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //        stateLabel.Text = "Not Connected";
            //        stateLabel.BackColor = stateLabel.BackColor = Color.Red;
            //    }
            //}
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
