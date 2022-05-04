using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Game.BrandNewType
{
    class Rail
    {
        public int Position;
        public int ServiceSpeed;

        public const int HitPosition = 200;
        public const int Margin = 10;

        public Rail()
        {
            Position = 0;
            ServiceSpeed = 10;
        }

        public void IncreaseServiceSpeed()
        {
            ServiceSpeed++;
        }

        public void DecreaseServiceSpeed()
        {
            ServiceSpeed--;
        }
    }
}
