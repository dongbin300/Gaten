using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Gaten.Audio.Mp3Player
{
    public class MusicPlayerAPI
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        const int MaxStringLength = 128;

        public MusicPlayerAPI() { }

        public static int GetLength()
        {
            StringBuilder lengthString = new StringBuilder();
            mciSendString("status MediaFile length", lengthString, MaxStringLength, IntPtr.Zero);
            return int.Parse(lengthString.ToString());
        }

        public static void SetVolume(int left, int right, int master)
        {
            mciSendString($"setaudio MediaFile left volume to {(int)(left * 10 * (double)master / 100)}", null, 0, IntPtr.Zero);
            mciSendString($"setaudio MediaFile right volume to {(int)(right * 10 * (double)master / 100)}", null, 0, IntPtr.Zero);
        }

        public static void Play(MusicFile file)
        {
            string typeString = file.info.Extension.Equals(".mp3") ? "type mpegvideo " : "";
            string mciString = $"open \"{file.info.FullName}\" {typeString}alias MediaFile";

            mciSendString(mciString, null, 0, IntPtr.Zero);
            mciSendString("play MediaFile", null, 0, IntPtr.Zero);
        }
    }
}
