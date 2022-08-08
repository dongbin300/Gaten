namespace Gaten.Game.BrandNewType
{
    internal class Track
    {
        public List<Bar> Bars = new();
        public Track()
        {

        }

        public void SetupBar()
        {
            for (int i = 0; i < 100; i++)
            {
                Bars.Add(new Bar((int)(i * 3600.0 / NoteObject.Bpm)));
            }
        }
    }
}
