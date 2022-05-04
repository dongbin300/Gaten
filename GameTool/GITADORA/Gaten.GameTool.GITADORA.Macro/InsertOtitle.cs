using System.Text;

namespace Gaten.GameTool.GITADORA.Macro
{
    internal class InsertOtitle
    {
        public InsertOtitle()
        {
            FileStream fs = new("version.txt", FileMode.Open);
            StreamReader sr = new(fs, Encoding.UTF8);
            string[] otitle = new string[1000];

            int p = 0;
            for (int i = 0; sr.Peek() >= 0; i++)
            {
                otitle[i] = sr.ReadLine();
                p = i;
            }

            FileStream fs2 = new("otitle.sql", FileMode.Create);
            StreamWriter sw = new(fs2, Encoding.UTF8);

            //UPDATE `music_info` SET `Otitle` = 'FIRE' WHERE `music_info`.`id` = 2;
            //UPDATE `music_info` SET `Version` = 'gfdm' WHERE `music_info`.`id` = 1;
            for (int i = 0; i < p; i++)
            {
                //sw.WriteLine($"UPDATE `music_info` SET `Otitle` = '{otitle[i]}' WHERE `music_info`.`id` = {i + 1};");
                sw.WriteLine($"UPDATE `music_info` SET `Version` = '{otitle[i]}' WHERE `music_info`.`id` = {i + 1};");
            }

            sw.Flush();
            fs2.Close();
        }
    }
}
