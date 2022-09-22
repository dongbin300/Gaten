using System.Linq;

namespace Gaten.Language.Mercury.Editor
{
	internal class MercuryCompletionDictionary
    {
        public static string[] Data =
        {
            "asset",
			"period",
			"interval",
			"target",
			"model",
			"scenario",
			"strategy",
			"signal",
			"order",
			"long",
			"short",
			"limit",
			"market",
			"balance",
			"poe",
			"ri",
			"rsi",
			"macd"
        };

		public static string[] GetSimilarData(string keyword)
		{
			return Data.Where(x => x.Contains(keyword)).ToArray();
		}
    }
}
