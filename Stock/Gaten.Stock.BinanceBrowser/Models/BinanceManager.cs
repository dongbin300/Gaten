using Binance.Net.Clients;
using Binance.Net.Objects;

using CryptoExchange.Net.Authentication;

using System.Collections.Generic;
using System.Linq;

namespace Gaten.Stock.BinanceBrowser.Models
{
    public class BinanceManager
    {
        private static BinanceClient client { get; set; }

        public static void Init(string apiKey, string secretKey)
        {
            client = new BinanceClient(new BinanceClientOptions
            {
                ApiCredentials = new ApiCredentials(apiKey, secretKey)
            });
        }

        public static List<FuturesPosition> GetPositioningInformation(string symbol)
        {
            var positionInformation = client.UsdFuturesApi.Account.GetPositionInformationAsync(symbol);
            positionInformation.Wait();

            return positionInformation.Result.Data
                .Where(x => x.Symbol.Equals(symbol))
                .Select(x => new FuturesPosition(
                    x.Symbol,
                    x.Leverage,
                    x.Quantity,
                    x.EntryPrice,
                    x.MarkPrice,
                    x.UnrealizedPnl,
                    x.LiquidationPrice
                    ))
                .ToList();
        }
    }
}
