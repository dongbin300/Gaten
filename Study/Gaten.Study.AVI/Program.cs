using Gaten.Study.AVI;

AVIHeader ah = new AVIHeader();

// Read AVI and parse
using (FileStream fs = new FileStream("test.avi", FileMode.Open))
{
    using (BinaryReader br = new BinaryReader(fs))
    {
        ah.groupId = br.ReadBytes(4);
        ah.groupSize = br.ReadInt32();
        ah.riffType = br.ReadBytes(4);
    }
}

// Write result
using (FileStream fs = new FileStream("output.txt", FileMode.Create))
{
    using (StreamWriter sr = new StreamWriter(fs))
    {
        sr.WriteLine("-RIFF HEADER");
        sr.Write("groupID: ");
        foreach (byte b in ah.groupId)
            sr.Write(b);
        sr.WriteLine();
        sr.WriteLine($"groupSize: {ah.groupSize}");
        sr.Write("riffType: ");
        foreach (byte b in ah.riffType)
            sr.Write(b);
        sr.WriteLine();

    }
}