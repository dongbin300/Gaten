using Gaten.Net.GameRule.osu;
using Gaten.Net.GameRule.osu.OsuFile;

List<CatchTheBeatCalculator> c = new List<CatchTheBeatCalculator>();

c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Easy].osu")));
c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Normal].osu")));
c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Advanced].osu")));
c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Hard].osu")));
c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Hyper].osu")));
c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Light Insane].osu")));
c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Another].osu")));
c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Insane].osu")));
c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Expert].osu")));
c.Add(new CatchTheBeatCalculator(new OsuFileObject("Shiggy Jr. - oyasumi (-Arche) [Extra].osu")));

foreach (CatchTheBeatCalculator ctbc in c)
{
    Console.WriteLine(string.Format("{0:0.00}", ctbc.Calculate(CatchTheBeatCalculator.CalculateRule.SumNote)));

}