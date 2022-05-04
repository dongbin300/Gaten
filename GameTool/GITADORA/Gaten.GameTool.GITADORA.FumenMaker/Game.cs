using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.GameTool.GITADORA.FumenMaker
{
    internal class Game
    {
        public enum Mode
        {
            Drum,
            Guitar,
            Bass
        }

        public enum DiffMode
        {
            Basic,
            Advanced,
            Extreme,
            Master
        }

        public enum DrumType
        {
            None,
            CrashSymbol,
            Hihat,
            LeftPedal,
            Snare,
            HighTom,
            RightPedal,
            LowTom,
            FloorTom,
            RideSymbol
        }
    }
}
