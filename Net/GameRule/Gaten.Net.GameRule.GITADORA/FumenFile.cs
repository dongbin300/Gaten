using System.Text;

namespace Gaten.Net.GameRule.GITADORA
{
    public class FumenFile
    {
        public int Width;
        public int Height;
        public List<Path> Paths;

        public FumenFile()
        {
            Paths = new List<Path>();
        }

        public void MakePath(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string[] config = reader.ReadLine().Split(',');
                    Width = int.Parse(config[1]);
                    Height = int.Parse(config[2]);

                    try
                    {
                        while (true)
                        {
                            string[] pathString = reader.ReadLine().Split(',');
                            switch (pathString[0])
                            {
                                case "BP":
                                    Paths.Add(new Path()
                                    {
                                        type = Path.Type.BigPhrase,
                                        lineNum = int.Parse(pathString[1]),
                                        timing = double.Parse(pathString[2])
                                    });
                                    break;
                                case "SP":
                                    Paths.Add(new Path()
                                    {
                                        type = Path.Type.SmallPhrase,
                                        lineNum = int.Parse(pathString[1]),
                                        timing = double.Parse(pathString[2])
                                    });
                                    break;
                                case "NO":
                                    Paths.Add(new Path()
                                    {
                                        type = Path.Type.Note,
                                        lineNum = int.Parse(pathString[1]),
                                        timing = double.Parse(pathString[2]),
                                        noteNum = int.Parse(pathString[3]),
                                        holdLength = pathString.Length > 4 ? double.Parse(pathString[4]) : 0
                                    });
                                    break;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
