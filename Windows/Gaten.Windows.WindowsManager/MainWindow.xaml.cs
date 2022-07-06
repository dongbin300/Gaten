using Gaten.Net.Data.IO;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gaten.Windows.WindowsManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshWork();
        }

        void RefreshWork()
        {
            BaseInfo.GetInfo();

            WindowsVersionText.Text = $"운영체제: {BaseInfo.ProductName}({BaseInfo.WindowsBit}) {BaseInfo.ProductVersion}";
            ProcessorText.Text = $"프로세서: {BaseInfo.CpuName} {BaseInfo.CpuCore} {BaseInfo.CpuThread} {BaseInfo.CpuSpeed}";
            MemoryText.Text = $"메모리: {BaseInfo.RamCapacity}";
            GraphicCardText.Text = $"그래픽 카드: {BaseInfo.GpuName} {BaseInfo.GpuRam}";
            ComputerNameText.Text = $"컴퓨터 이름: {BaseInfo.ComputerName}";
            AuthText.Text = $"정품 인증: {BaseInfo.SerialNumber}";

            using (var windowsDefenderKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender"))
            {
                SetRegistryLabel(windowsDefenderKey, "DisableAntiSpyware", RtpText1);
                SetRegistryLabel(windowsDefenderKey, "DisableRoutinelyTakingAction", RtpText2);
            }
            using (var realTimeProtectionKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection"))
            {
                SetRegistryLabel(realTimeProtectionKey, "DisableBehaviorMonitoring", RtpText3);
                SetRegistryLabel(realTimeProtectionKey, "DisableOnAccessProtection", RtpText4);
                SetRegistryLabel(realTimeProtectionKey, "DisableScanOnRealtimeEnable", RtpText5);
            }

            RtpHelpText.Text = "모든 설정값이 켜져야 실시간 보호가 꺼집니다. 모든 백신을 끄고 관리자 권한으로 실행해야 합니다. 설정값을 변경하고 나서는 재부팅을 합니다.";
        }

        #region 정품인증
        private void W7Button_Click(object sender, RoutedEventArgs e)
        {
            string path = GResource.GetPath("wauth/w7.bat");
            ProcessStartInfo psi = new()
            {
                FileName = path,
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            System.Diagnostics.Process.Start(psi)?.WaitForExit();
        }

        private void W10ProButton_Click(object sender, RoutedEventArgs e)
        {
            string path = GResource.GetPath("wauth/w10pro.bat");
            ProcessStartInfo psi = new()
            {
                FileName = path,
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            System.Diagnostics.Process.Start(psi)?.WaitForExit();
        }

        private void W10HomeButton_Click(object sender, RoutedEventArgs e)
        {
            string path = GResource.GetPath("wauth/w10home.bat");
            ProcessStartInfo psi = new()
            {
                FileName = path,
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            System.Diagnostics.Process.Start(psi)?.WaitForExit();
        }

        private void W10EnterpriseButton_Click(object sender, RoutedEventArgs e)
        {
            string path = GResource.GetPath("wauth/w10ep.bat");
            ProcessStartInfo psi = new()
            {
                FileName = path,
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            System.Diagnostics.Process.Start(psi)?.WaitForExit();
        }

        private void W10EducationButton_Click(object sender, RoutedEventArgs e)
        {
            string path = GResource.GetPath("wauth/w10edu.bat");
            ProcessStartInfo psi = new()
            {
                FileName = path,
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            System.Diagnostics.Process.Start(psi)?.WaitForExit();
        }

        private void Office2016Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new()
            {
                FileName = "cmd.exe",
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Normal,
                CreateNoWindow = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var process = System.Diagnostics.Process.Start(psi);
            process.StandardInput.Write(@"cd /d %ProgramFiles%\Microsoft Office\Office16");
            //process.StandardInput.Write(@"cd /d %ProgramFiles(x86)%\Microsoft Office\Office16");
            process.StandardInput.Write(@"for /f %x in ('dir /b ..\root\Licenses16\ProPlus2019VL*.xrm-ms') do cscript ospp.vbs /inslic:'..\root\Licenses16\% x'");
            process.StandardInput.Write(@"cscript ospp.vbs /setprt:1688");
            process.StandardInput.Write(@"cscript ospp.vbs /unpkey:6MWKP >nul");
            process.StandardInput.Write(@"cscript ospp.vbs /inpkey:NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP");
            process.StandardInput.Write(@"cscript ospp.vbs /sethst:kms8.msguides.com");
            process.StandardInput.Write(@"cscript ospp.vbs /act");
            process.StandardInput.Close();
            process.WaitForExit();
            process.Close();

            MessageBox.Show("완료");
        }
        #endregion

        #region 실시간 보호
        void SetRegistryLabel(RegistryKey baseKey, string keyName, TextBlock textBlock)
        {
            if (baseKey == null)
            {
                textBlock.Text = $"{keyName} : 꺼짐";
                textBlock.Foreground = Brushes.DimGray;
                return;
            }

            var value = baseKey.GetValue(keyName);

            if (value == null || (int)value == 0)
            {
                textBlock.Text = $"{keyName} : 꺼짐";
                textBlock.Foreground = Brushes.DimGray;
            }
            else
            {
                textBlock.Text = $"{keyName} : 켜짐";
                textBlock.Foreground = Brushes.DimGray;
            }
        }

        private void RtpOffButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var windowsDefenderKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender", true))
                {
                    windowsDefenderKey.SetValue("DisableAntiSpyware", 1, RegistryValueKind.DWord);
                    windowsDefenderKey.SetValue("DisableRoutinelyTakingAction", 1, RegistryValueKind.DWord);
                }

                using (var realTimeProtectionKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", true))
                {
                    realTimeProtectionKey.SetValue("DisableBehaviorMonitoring", 1, RegistryValueKind.DWord);
                    realTimeProtectionKey.SetValue("DisableOnAccessProtection", 1, RegistryValueKind.DWord);
                    realTimeProtectionKey.SetValue("DisableScanOnRealtimeEnable", 1, RegistryValueKind.DWord);
                }

                MessageBox.Show("실시간 보호를 정상적으로 껐습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RefreshWork();
        }
        #endregion

    }
}
