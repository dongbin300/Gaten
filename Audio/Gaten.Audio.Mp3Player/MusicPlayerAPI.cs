using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Gaten.Audio.Mp3Player
{
    public class MusicPlayerAPI
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        private const int MaxStringLength = 128;

        public MusicPlayerAPI() { }

        public static int GetLength()
        {
            StringBuilder lengthString = new();
            _ = mciSendString("status MediaFile length", lengthString, MaxStringLength, IntPtr.Zero);
            return int.Parse(lengthString.ToString());
        }

        public static void SetVolume(int left, int right, int master)
        {
            _ = mciSendString($"setaudio MediaFile left volume to {(int)(left * 10 * (double)master / 100)}", default!, 0, IntPtr.Zero);
            _ = mciSendString($"setaudio MediaFile right volume to {(int)(right * 10 * (double)master / 100)}", default!, 0, IntPtr.Zero);
        }

        public static void Play(MusicFile file)
        {
            string typeString = file.Info.Extension.Equals(".mp3") ? "type mpegvideo " : "";
            string mciString = $"open \"{file.Info.FullName}\" {typeString}alias MediaFile";

            _ = mciSendString(mciString, default!, 0, IntPtr.Zero);
            _ = mciSendString("play MediaFile", default!, 0, IntPtr.Zero);
        }
    }
}
