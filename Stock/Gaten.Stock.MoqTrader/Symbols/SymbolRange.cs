using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.MoqTrader.Symbols
{
    internal class SymbolRange
    {
        public List<string> Symbols { get; set; }

        public SymbolRange() : this(new List<string>())
        {

        }

        public SymbolRange(params string[] symbols) : this(symbols.ToList())
        {

        }

        public SymbolRange(List<string> symbols)
        {
            Symbols = symbols;
        }
    }
}
