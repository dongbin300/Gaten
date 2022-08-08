using System.Runtime.InteropServices;

namespace Gaten.Study.AVI
{
    public enum BitmapCompressionMode : uint
    {
        BI_RGB = 0,
        BI_RLE8 = 1,
        BI_RLE4 = 2,
        BI_BITFIELDS = 3,
        BI_JPEG = 4,
        BI_PNG = 5
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER
    {
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public BitmapCompressionMode biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;

        public void Init()
        {
            biSize = (uint)Marshal.SizeOf(this);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WaveFormatExtensible
    {
        public ushort wFormatTag;
        public ushort nChannels;
        public uint nSamplesPerSec;
        public uint nAvgBytesPerSec;
        public ushort nBlockAlign;
        public ushort wBitsPerSample;
        public ushort cbSize;

        public ushort wValidBitsPerSample;
        public uint dwChannelMask;
        public Guid SubFormat;
    }

    public class AVIHeader
    {
        public byte[] groupId = new byte[4];
        public int groupSize;
        public byte[] riffType = new byte[4];
        public HeaderList headerList = default!;
        public ListHeader listHeader = default!;
        public JunkHeader junkHeader = default!;
        public DataListHeader dataListHeader = default!;
        public IndexListHeader indexListHeader = default!;
    }

    public class HeaderList
    {
        byte[] groupId = new byte[4];
        int listSize;
        byte[] listType = new byte[4];
        AVI avi = default!;
        VideoStreamList videoStreamList = default!;
        AudioStreamList audioStreamList = default!;
        __Junk junk = default!;
    }

    public class AVI
    {
        Chunk chunk = default!;
        int microSecPerFrame;
        int maxBytesPerSec;
        int paddingGranularity;
        int flags;
        int totalFrames;
        int initialFrames;
        int streams;
        int suggestedBufferSize;
        int width;
        int height;
        int[] reserved = new int[4];
    }

    public class Stream
    {
        Chunk chunk = default!;
        byte[] fccType = new byte[4];
        byte[] fccHandler = new byte[4];
        int flags;
        short priority;
        short language;
        int initialFrames;
        int scale;
        int rate;
        int start;
        int length;
        int suggestedBufferSize;
        int quality;
        int sampleSize;
        ulong frame;
    }

    public class VideoStreamFormat
    {
        Chunk chunk = default!;
        BITMAPINFOHEADER bitmapInfoHeader;
    }

    public class AudioStreamFormat
    {
        Chunk chunk = default!;
        WaveFormatExtensible waveFormatEx;
        short[] data = default!;
    }

    public class VideoStreamList
    {
        List list = default!;
        Stream stream = default!;
        VideoStreamFormat videoStreamFormat = default!;
        Junk junk = default!;
    }

    public class AudioStreamList
    {
        List list = default!;
        Stream stream = default!;
        AudioStreamFormat audioStreamFormat = default!;
        Junk junk = default!;
    }

    public class ListHeader
    {
        List list = default!;
        short[] data = default!;
    }

    public class JunkHeader
    {
        Chunk chunk = default!;
        short[] data = default!;
    }

    // video, audio data, dc=video, wb=audio
    public class Data
    {
        Chunk chunk = default!;
        short[] data = default!;
    }

    public class DataListHeader
    {
        List list = default!;
        Data[] data = default!;
    }

    public class Index
    {
        byte[] chunkId = new byte[4];
        int flags;
        int offset;
        int size;
    }

    public class IndexListHeader
    {
        Chunk chunk = default!;
        Index[] data = default!;
    }

    public class Chunk
    {
        byte[] id = new byte[4];
        int size;
    }

    public class List
    {
        byte[] id = new byte[4];
        int size;
        byte[] type = new byte[4];
    }

    public class Junk
    {
        Chunk chunk = default!;
        int[] none = new int[2];
        byte[] fourCc = new byte[4];
        short[] data = default!;
    }

    public class __Junk
    {
        Chunk chunk = default!;
        int[] none = new int[2];
        int size;
        short[] data = default!;
    }

}