using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.GameRule.GITADORA
{
    public class LinePathComparer : PathComparer, IEqualityComparer<Path>
    {
        public bool Equals(Path x, Path y)
        {
            return x.timing == y.timing;
        }

        public int GetHashCode(Path obj)
        {
            return obj.timing.GetHashCode();
        }

        public bool TypeEquals(Path x, Path y)
        {
            return x.type == y.type;
        }
    }
}
