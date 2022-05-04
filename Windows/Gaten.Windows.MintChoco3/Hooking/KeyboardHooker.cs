
using Gaten.Windows.MintChoco3.Resources.Utils;

using System;
using System.Runtime.InteropServices;

namespace MintChocoLibrary.Hooking
{
    public class KeyboardHooker
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private LowLevelKeyboardProc hookProcDelegate;

        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public IntPtr hook = IntPtr.Zero;

        #region KEY LIST
        public const int KEY_BACKSPACE = 8;
        public const int KEY_TAB = 9;
        public const int KEY_ENTER = 13;
        public const int KEY_CAPSLOCK = 20;
        public const int KEY_ALT = 21;
        public const int KEY_RCTRL = 25;
        public const int KEY_ESC = 27;
        public const int KEY_SPACEBAR = 32;
        public const int KEY_PAGEUP = 33;
        public const int KEY_PAGEDOWN = 34;
        public const int KEY_END = 35;
        public const int KEY_HOME = 36;
        public const int KEY_LEFT = 37;
        public const int KEY_UP = 38;
        public const int KEY_RIGHT = 39;
        public const int KEY_DOWN = 40;
        public const int KEY_PRINTSCREEN = 44;
        public const int KEY_INSERT = 45;
        public const int KEY_DELETE = 46;
        public const int KEY_0 = 48;
        public const int KEY_1 = 49;
        public const int KEY_2 = 50;
        public const int KEY_3 = 51;
        public const int KEY_4 = 52;
        public const int KEY_5 = 53;
        public const int KEY_6 = 54;
        public const int KEY_7 = 55;
        public const int KEY_8 = 56;
        public const int KEY_9 = 57;
        public const int KEY_A = 65;
        public const int KEY_B = 66;
        public const int KEY_C = 67;
        public const int KEY_D = 68;
        public const int KEY_E = 69;
        public const int KEY_F = 70;
        public const int KEY_G = 71;
        public const int KEY_H = 72;
        public const int KEY_I = 73;
        public const int KEY_J = 74;
        public const int KEY_K = 75;
        public const int KEY_L = 76;
        public const int KEY_M = 77;
        public const int KEY_N = 78;
        public const int KEY_O = 79;
        public const int KEY_P = 80;
        public const int KEY_Q = 81;
        public const int KEY_R = 82;
        public const int KEY_S = 83;
        public const int KEY_T = 84;
        public const int KEY_U = 85;
        public const int KEY_V = 86;
        public const int KEY_W = 87;
        public const int KEY_X = 88;
        public const int KEY_Y = 89;
        public const int KEY_Z = 90;
        public const int KEY_WINDOW = 91;
        public const int KEY_NUM0 = 96;
        public const int KEY_NUM1 = 97;
        public const int KEY_NUM2 = 98;
        public const int KEY_NUM3 = 99;
        public const int KEY_NUM4 = 100;
        public const int KEY_NUM5 = 101;
        public const int KEY_NUM6 = 102;
        public const int KEY_NUM7 = 103;
        public const int KEY_NUM8 = 104;
        public const int KEY_NUM9 = 105;
        public const int KEY_NUMMULTIPLE = 106;
        public const int KEY_NUMPLUS = 107;
        public const int KEY_NUMMINUS = 109;
        public const int KEY_NUMDOT = 110;
        public const int KEY_NUMDIVIDE = 111;
        public const int KEY_F1 = 112;
        public const int KEY_F2 = 113;
        public const int KEY_F3 = 114;
        public const int KEY_F4 = 115;
        public const int KEY_F5 = 116;
        public const int KEY_F6 = 117;
        public const int KEY_F7 = 118;
        public const int KEY_F8 = 119;
        public const int KEY_F9 = 120;
        public const int KEY_F10 = 121;
        public const int KEY_F11 = 122;
        public const int KEY_F12 = 123;
        public const int KEY_LSHIFT = 160;
        public const int KEY_RSHIFT = 161;
        public const int KEY_LCTRL = 162;

        /// <summary>
        /// :, ;
        /// </summary>
        public const int KEY_COLON = 186;
        public const int KEY_SEMICOLON = 186;

        /// <summary>
        /// +, =
        /// </summary>
        public const int KEY_PLUS = 187;
        public const int KEY_EQUAL = 187;

        /// <summary>
        /// <, ,
        /// </summary>
        public const int KEY_LANGLEBRACKET = 188;
        public const int KEY_COMMA = 188;

        /// <summary>
        /// _, -
        /// </summary>
        public const int KEY_UNDERSCORE = 189;
        public const int KEY_HYPHEN = 189;

        /// <summary>
        /// >, .
        /// </summary>
        public const int KEY_RANGLEBRACKET = 190;
        public const int KEY_DOT = 190;

        /// <summary>
        /// ?, /
        /// </summary>
        public const int KEY_QUESTION = 191;
        public const int KEY_SLASH = 191;

        /// <summary>
        /// ~, `
        /// </summary>
        public const int KEY_TILDE = 192;
        public const int KEY_ACUTE = 192;

        /// <summary>
        /// {, [
        /// </summary>
        public const int KEY_LBRACE = 219;
        public const int KEY_LBRACKET = 219;

        /// <summary>
        /// |, \
        /// </summary>
        public const int KEY_PIPE = 220;
        public const int KEY_WON = 220;

        /// <summary>
        /// }, ]
        /// </summary>
        public const int KEY_RBRACE = 221;
        public const int KEY_RBRACKET = 221;

        /// <summary>
        /// ", '
        /// </summary>
        public const int KEY_QUOTE = 222;
        public const int KEY_SQUOTE = 222;
        #endregion

        public KeyboardHooker(LowLevelKeyboardProc keyProc)
        {
            hookProcDelegate = keyProc;
        }

        public void SetHook()
        {
            try
            {
                IntPtr hInstance = LoadLibrary("User32");
                hook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProcDelegate, hInstance, 0);
            }
            catch (Exception ex)
            {
                LogUtil.Log(ex.Message, "SetHook");
            }
        }

        public void UnHook()
        {
            try
            {
                UnhookWindowsHookEx(hook);
            }
            catch (Exception ex)
            {
                LogUtil.Log(ex.Message, "UnHook");
            }
        }
    }
}
