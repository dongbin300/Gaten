#pragma warning disable CS8602 // null 가능 참조에 대한 역참조입니다.

using Gaten.Net.IO;
using Gaten.Windows.MintChoco3.Model;
using Gaten.Windows.MintChoco3.Resources.Texts;
using Gaten.Windows.MintChoco3.Resources.Utils;

using MintChocoLibrary.Hooking;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;

namespace Gaten.Windows.MintChoco3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Status
        {
            None,
            Caps1,
            Selector
        }

        KeyboardHooker? keyboardHooker;
        Status status = Status.None;

        Selector selector;

        public MainWindow()
        {
            InitializeComponent();

            Back.Modules = new List<Module>();
            //LoadModuleData();
            selector = new Selector();
            selector.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Back.ComboString = string.Empty;
            keyboardHooker = new KeyboardHooker(HookProc);
            keyboardHooker.SetHook();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void LoadModuleData()
        {
            var data = GFile.ReadToArray(PathCollection.MintChocoSettingPath);

            foreach (var d in data)
            {
                string[] c = d.Split(',');
                Back.Modules.Add(new Module()
                {
                    Name = c[0],
                    Path = c[2],
                    HotKey = c[3].ToUpper()
                });
            }
        }

        void ShowWindow(Window window)
        {
            window.Show();
            window.Topmost = true;
            window.Topmost = false;
        }

        void HideWindow(Window window)
        {
            window.Hide();
        }

        void None()
        {
            status = Status.None;
            HideWindow(selector);
        }

        void StartModule(string modulePath)
        {
            None();
            ProcessUtil.StartProcess(modulePath);
        }

        private IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                if (code >= 0 && wParam == (IntPtr)KeyboardHooker.WM_KEYDOWN)
                {
                    int keyCode = Marshal.ReadInt32(lParam);

                    switch (status)
                    {
                        case Status.None:
                            switch (keyCode)
                            {
                                case KeyboardHooker.KEY_CAPSLOCK:
                                    status = Status.Caps1;
                                    break;
                            }
                            break;

                        case Status.Caps1:
                            switch (keyCode)
                            {
                                case KeyboardHooker.KEY_CAPSLOCK:
                                    status = Status.Selector;
                                    ShowWindow(selector);
                                    LogUtil.Log("선택기 열림", "HookProc");
                                    break;

                                default:
                                    None();
                                    break;
                            }
                            break;

                        case Status.Selector:
                            // 선택 화면에서 ESC키 누르면 빠져나오기
                            if (keyCode == KeyboardHooker.KEY_ESC)
                            {
                                None();
                            }

                            string letter = ((char)keyCode).ToString();
                            if (Back.ComboString.Length == 1)
                            {
                                Back.ComboString += letter;

                                var module = Back.Modules.Find(m => m.HotKey.Equals(Back.ComboString));
                                if (module == null)
                                {
                                    MessageBox.Show("존재하지 않는 모듈입니다.");
                                    LogUtil.Log("존재하지 않는 모듈 열기 시도", "HookProc");
                                    break;
                                }

                                StartModule(module.Path);
                                LogUtil.Log("모듈 열기 성공: " + module.Path, "HookProc");
                            }
                            else
                            {
                                Back.ComboString = letter;
                                //MessageBox.Show("MainWindow:" + Back.ComboString);
                            }
                            break;
                    }


                    LogUtil.Log("KeyDown", "HookProc");
                    return KeyboardHooker.CallNextHookEx(keyboardHooker.hook, code, (int)wParam, lParam); // 키입력을 정상적으로 동작하게 합니다.
                                                                                                          //return (IntPtr)1; // 키입력을 무효화 합니다.
                }
                else
                {
                    LogUtil.Log("Idle", "HookProc");
                    return KeyboardHooker.CallNextHookEx(keyboardHooker.hook, code, (int)wParam, lParam);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log(ex.Message, "HookProc");
                return KeyboardHooker.CallNextHookEx(keyboardHooker.hook, code, (int)wParam, lParam);
            }
        }
    }
}
