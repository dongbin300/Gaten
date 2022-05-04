using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Game.BrandNewType
{
    class Track
    {
        public List<Bar> Bars = new List<Bar>();
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
