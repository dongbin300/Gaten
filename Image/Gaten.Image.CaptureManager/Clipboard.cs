using Gaten.Net.Windows;

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Gaten.Image.CaptureManager
{
    public sealed class Clipboard
    {
        public static bool HasDataToRestore = false;
        static uint Format;
        static object Data;
        static IntPtr MemoryHandle = IntPtr.Zero;

        /// <summary>
        /// 현재 클립보드에 저장되어 있는 데이터를 백업합니다. 클립보드 열기 요청 실패 시 Clipboard.CannotOpenException 예외가 발생합니다.
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
                case WinApi.CF_BITMAP:
                    Data = System.Drawing.Image.FromHbitmap(pointer);
                    MemoryHandle = ((Bitmap)Data).GetHbitmap();
                    break;
            }
            WinApi.CloseClipboard();

            HasDataToRestore = true;
        }

        /// <summary>
        /// 백업했던 클립보드 데이터를 복구합니다. 현재 텍스트와 이미지만 복구 기능을 지원하며, 클립보드 열기 요청 실패 시 Clipboard.CannotOpenException 예외가 발생합니다.
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
                case WinApi.CF_BITMAP:
                case WinApi.CF_DIB:
                    Format = WinApi.CF_BITMAP;
                    SetImage(MemoryHandle, clipboardOwner);
                    (Data as Bitmap).Dispose();
                    break;
            }
            if (Format == WinApi.CF_TEXT || Format == WinApi.CF_UNICODETEXT) WinApi.CloseClipboard();

            WinApi.DeleteObject(MemoryHandle);
            Data = null;
            MemoryHandle = IntPtr.Zero;
            HasDataToRestore = false;
        }

        /// <summary>
        /// 클립보드에서 텍스트를 가져옵니다. 클립보드 열기 요청 실패 시 Clipboard.CannotOpenException 예외가 발생하고, 만약 텍스트가 존재하지 않을 경우 null을 반환합니다.
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
        /// 클립보드에 텍스트를 저장합니다. 클립보드 열기 요청 실패 시 Clipboard.CannotOpenException 예외가 발생합니다.
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

        /// <summary>
        /// 클립보드에 이미지를 저장합니다. 클립보드 열기 요청 실패 시 Clipboard.CannotOpenException 예외가 발생합니다.
        /// 또한 이 메서드를 짧은 시간 간격을 두고 주기적으로 호출할 경우 ExternalException 및 ContextSwitchDeadLock 현상이 발생할 수 있습니다.
        /// 따라서 이 메서드를 반복문 내에서 사용할 때는 주의가 필요합니다.
        /// </summary>
        /// <param name="imagePath">저장할 이미지의 원본 파일 경로</param>
        public static void SetImage(string imagePath, IntPtr clipboardOwner)
        {
            using (Bitmap image = (Bitmap)System.Drawing.Image.FromFile(imagePath)) _SetImage(image, clipboardOwner);
        }

        public static void SetImage(IntPtr hBitmap, IntPtr clipboardOwner)
        {
            using (Bitmap image = System.Drawing.Image.FromHbitmap(hBitmap)) _SetImage(image, clipboardOwner);
        }

        private static void _SetImage(Bitmap image, IntPtr clipboardOwner)
        {
            Bitmap tempImage = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(tempImage))
            {
                IntPtr hScreenDC = WinApi.GetWindowDC(IntPtr.Zero); // 기본적인 Device Context의 속성들을 카피하기 위한 작업
                IntPtr hDestDC = WinApi.CreateCompatibleDC(hScreenDC);
                IntPtr hDestBitmap = WinApi.CreateCompatibleBitmap(hScreenDC, image.Width, image.Height); // destDC와 destBitmap 모두 반드시 screenDC의 속성들을 기반으로 해야 함.
                IntPtr hPrevDestObject = WinApi.SelectObject(hDestDC, hDestBitmap);

                IntPtr hSourceDC = graphics.GetHdc();
                IntPtr hSourceBitmap = image.GetHbitmap();
                IntPtr hPrevSourceObject = WinApi.SelectObject(hSourceDC, hSourceBitmap);

                WinApi.BitBlt(hDestDC, 0, 0, image.Width, image.Height, hSourceDC, 0, 0, WinApi.SRCCOPY);

                WinApi.DeleteObject(WinApi.SelectObject(hSourceDC, hPrevSourceObject));
                WinApi.SelectObject(hDestDC, hPrevDestObject); // 리턴값 : hDestBitmap
                graphics.ReleaseHdc(hSourceDC);
                WinApi.DeleteDC(hDestDC);

                bool isClipboardOpen = WinApi.OpenClipboard(clipboardOwner);
                if (!isClipboardOpen)
                {
                    WinApi.DeleteObject(hDestBitmap);
                    WinApi.DeleteObject(hSourceDC);
                    WinApi.DeleteObject(hSourceBitmap);
                    tempImage.Dispose();
                    throw new CannotOpenException();
                }
                WinApi.EmptyClipboard();
                WinApi.SetClipboardData(WinApi.CF_BITMAP, hDestBitmap);
                WinApi.CloseClipboard();

                WinApi.DeleteObject(hDestBitmap);
                WinApi.DeleteObject(hSourceDC);
                WinApi.DeleteObject(hSourceBitmap);
            }
            tempImage.Dispose();
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
