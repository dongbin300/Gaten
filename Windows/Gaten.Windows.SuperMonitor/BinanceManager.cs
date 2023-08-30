using Binance.Net.Clients;
using Binance.Net.Objects;

using Gaten.Net.IO;

using System;
using System.Linq;

namespace Gaten.Windows.SuperMonitor
{
    public class BinanceManager
    {
        public static BinanceClient Client { get; set; } = default!;
        public static BinanceSocketClient SocketClient { get; set; } = default!;
        public static string listenKey { get; set; } = string.Empty;
        public static decimal BtcusdtChangePercent { get; set; } = 0;

        public static void Init()
        {
            var apiData = GResource.BinanceApiKeyText;
            Client = new BinanceClient(new BinanceClientOptions
            {
                ApiCredentials = new BinanceApiCredentials(apiData[0], apiData[1])
            });
            SocketClient = new BinanceSocketClient(new BinanceSocketClientOptions
            {
                ApiCredentials = new BinanceApiCredentials(apiData[0], apiData[1])
            });

            var btcusdtChangeResult = SocketClient.UsdFuturesStreams.SubscribeToTickerUpdatesAsync("BTCUSDT", (obj) =>
            {
                BtcusdtChangePercent = obj.Data.PriceChangePercent;
            });

            //var userStream = Client.SpotApi.Account.StartUserStreamAsync();
            //userStream.Wait();
            //listenKey = userStream.Result.Data;
        }

        public static (double, double) GetBinanceBalance()
        {
            try
            {
                var result = Client.UsdFuturesApi.Account.GetBalancesAsync();
                result.Wait();
                var balance = result.Result.Data;
                var usdtBalance = balance.First(b => b.Asset.Equals("USDT"));
                var usdt = usdtBalance.WalletBalance + usdtBalance.CrossUnrealizedPnl;
                var availableUsdt = (double)Math.Round(usdtBalance.AvailableBalance, 3);
                var total = (double)Math.Round(usdt, 3);

                return (total, availableUsdt);
            }
            catch
            {
                return (-1, -1);
            }
        }

        public static (double, double) GetBinancePosition()
        {
            try
            {
                // Socket client version
                //SocketClient.UsdFuturesStreams.SubscribeToUserDataUpdatesAsync(listenKey, null, null, (obj) =>
                //{

                //}, null, null, null, null);

                var result = Client.UsdFuturesApi.Account.GetPositionInformationAsync();
                result.Wait();
                var data = result.Result.Data;
                var longPosition = data.Where(d => d.Quantity != 0 && d.PositionSide == Binance.Net.Enums.PositionSide.Long).Sum(d=>d.EntryPrice * d.Quantity);
                var shortPosition = data.Where(d => d.Quantity != 0 && d.PositionSide == Binance.Net.Enums.PositionSide.Short).Sum(d => d.EntryPrice * -d.Quantity);

                return ((double)longPosition, (double)shortPosition);
            }
            catch
            {
                return (-1, -1);
            }
        }
    }
}
