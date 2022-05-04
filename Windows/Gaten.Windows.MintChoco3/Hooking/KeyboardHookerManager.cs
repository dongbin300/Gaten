using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MintChocoLibrary.Hooking
{
    public class KeyboardHookerManager
    {
        //static KeyboardHooker keyboardHooker;
        //static bool _keyDown;
        //static int _keyCode = 0;

        //public static void Init()
        //{
        //    //keyboardHooker = new KeyboardHooker();
        //    //keyboardHooker.SetHook(HookProc);

        //    //_keyDown = false;
        //}

        //private static IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
        //{
        //    try
        //    {
        //        //Console.WriteLine("HookProc(" + code + ")");
        //        if (code >= 0 && 
        //           wParam == (IntPtr)KeyboardHooker.WM_KEYDOWN)
        //        {
        //            //Console.WriteLine("KEYDOWN: true");
        //            _keyDown = true;
        //            _keyCode = Marshal.ReadInt32(lParam);
        //            int keyCode = Marshal.ReadInt32(lParam);

        //            return KeyboardHooker.CallNextHookEx(keyboardHooker.hook, code, (int)wParam, lParam); // 키입력을 정상적으로 동작하게 합니다.
        //            //return (IntPtr)1; // 키입력을 무효화 합니다.
        //        }
        //        //else if (code >= 0 && wParam == (IntPtr)KeyboardHooker.WM_KEYUP)
        //        //{
        //        //    Console.WriteLine("KEYDOWN: false");
        //        //    //_keyDown = false;
        //        //    _keyCode = 1234;
        //        //    return KeyboardHooker.CallNextHookEx(keyboardHooker.hook, code, (int)wParam, lParam);
        //        //}
        //        else
        //        {
        //            _keyDown = false;
        //            _keyCode = 1234;
        //            return KeyboardHooker.CallNextHookEx(keyboardHooker.hook, code, (int)wParam, lParam);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        _keyCode = 1234;
        //        return KeyboardHooker.CallNextHookEx(keyboardHooker.hook, code, (int)wParam, lParam);
        //    }
        //}

        //public static bool IsKeyboardHit()
        //{
        //    return _keyDown;
        //}

        //public static bool IsKeyHit(string keyString)
        //{
        //    // 0~9
        //    if (int.TryParse(keyString, out int num))
        //    {
        //        int keyCode = 48 + num;
        //        if(_keyDown && keyCode == _keyCode)
        //        {
        //            _keyDown = false;
        //            return true;
        //        }
        //        return false;
        //    }
        //    // A~Z
        //    if (Regex.IsMatch(keyString, @"^[A-Za-z]+$"))
        //    {
        //        int keyCode = keyString.ToUpper()[0];
        //        if (_keyDown && keyCode == _keyCode)
        //        {
        //            _keyDown = false;
        //            return true;
        //        }
        //        return false;
        //    }

        //    return false;
        //}

        //public static bool IsKeyCombo(string keyString)
        //{
        //    if(keyString.Length == 2)
        //    {
        //        if (!_c1 && IsKeyHit(keyString[0].ToString()))
        //        {
        //            _c1 = true;
        //        }
        //    }
        //}
    }
}
