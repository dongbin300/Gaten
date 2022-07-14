using System.Runtime.InteropServices;

namespace Gaten.Net.Windows.KakaoTalk
{
    internal sealed class ClipboardManager
    {
        public static bool HasDataToRestore = false;
        static uint Format;
        static object Data;
        static IntPtr MemoryHandle = IntPtr.Zero;

        /// <summary>
        /// 현재 클립보드에 저장되어 있는 데이터를 백업합니다. 클립보드 열기 요청 실패 시 ClipboardManager.CannotOpenException 예외가 발생합니다.
        /// </summary>
        public static void BackupData(IntPtr clipboardOwner)
        {
            Format = 0;

            bool isClipboardOpen = WinApi.OpenClipboard(clipboardOwner);
            if (!isClipboardOpen) throw new CannotOpenException();
            do { Format = WinApi.EnumClipboardFormats(Format); }
            while (Format >= 0x200 || Format == 0);

            IntPtr pointer = WinApi.GetClipboardData(Format);
            switch (Format)
            {
                case WinApi.CF_TEXT:
                    Data = Marshal.PtrToStringAnsi(pointer);
                    MemoryHandle = Marshal.StringToHGlobalAnsi((string)Data);
                    break;
                case WinApi.CF_UNICODETEXT:
                    Data = Marshal.PtrToStringUni(pointer);
                    MemoryHandle = Marshal.StringToHGlobalUni((string)Data);
                    break;
            }
            WinApi.CloseClipboard();

            HasDataToRestore = true;
        }

        /// <summary>
        /// 백업했던 클립보드 데이터를 복구합니다. 현재 텍스트와 이미지만 복구 기능을 지원하며, 클립보드 열기 요청 실패 시 ClipboardManager.CannotOpenException 예외가 발생합니다.
        /// </summary>
        public static void RestoreData(IntPtr clipboardOwner)
        {
            if (!HasDataToRestore) return;

            if (Format == WinApi.CF_TEXT || Format == WinApi.CF_UNICODETEXT)
            {
                bool isClipboardOpen = WinApi.OpenClipboard(clipboardOwner);
                if (!isClipboardOpen) throw new CannotOpenException();
            }

            switch (Format)
            {
                case WinApi.CF_TEXT:
                    WinApi.SetClipboardData(Format, MemoryHandle);
                    break;
                case WinApi.CF_UNICODETEXT:
                    WinApi.SetClipboardData(Format, MemoryHandle);
                    break;
            }
            if (Format == WinApi.CF_TEXT || Format == WinApi.CF_UNICODETEXT) WinApi.CloseClipboard();

            WinApi.DeleteObject(MemoryHandle);
            Data = null;
            MemoryHandle = IntPtr.Zero;
            HasDataToRestore = false;
        }

        /// <summary>
        /// 클립보드에서 텍스트를 가져옵니다. 클립보드 열기 요청 실패 시 ClipboardManager.CannotOpenException 예외가 발생하고, 만약 텍스트가 존재하지 않을 경우 null을 반환합니다.
        /// </summary>
        public static string GetText(IntPtr clipboardOwner)
        {
            string text = null;

            bool isClipboardOpen = WinApi.OpenClipboard(clipboardOwner);
            if (!isClipboardOpen) throw new CannotOpenException();
            IntPtr pointer = WinApi.GetClipboardData(WinApi.CF_UNICODETEXT);
            if (pointer == IntPtr.Zero)
            {
                pointer = WinApi.GetClipboardData(WinApi.CF_TEXT);
                if (pointer != IntPtr.Zero) text = Marshal.PtrToStringAnsi(pointer);
            }
            else text = Marshal.PtrToStringUni(pointer);
            WinApi.CloseClipboard();

            return text;
        }

        /// <summary>
        /// 클립보드에 텍스트를 저장합니다. 클립보드 열기 요청 실패 시 ClipboardManager.CannotOpenException 예외가 발생합니다.
        /// </summary>
        /// <param name="text">저장할 텍스트</param>
        public static void SetText(string text, IntPtr clipboardOwner)
        {
            bool isClipboardOpen = WinApi.OpenClipboard(clipboardOwner);
            if (!isClipboardOpen) throw new CannotOpenException();
            WinApi.EmptyClipboard();
            WinApi.SetClipboardData(WinApi.CF_TEXT, Marshal.StringToHGlobalAnsi(text));
            WinApi.SetClipboardData(WinApi.CF_UNICODETEXT, Marshal.StringToHGlobalUni(text));
            WinApi.CloseClipboard();
        }

        public class CannotOpenException : Exception
        {
            internal CannotOpenException() : base("클립보드가 다른 프로그램에 의해 이미 사용되고 있습니다.") { }
        }

        public class InvalidFormatRequestException : Exception
        {
            internal InvalidFormatRequestException() : base("잘못된 클립보드 포맷 요청입니다.") { }
        }
    }
}