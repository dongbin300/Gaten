using Binance.Net.Clients;
using Binance.Net.Objects;
using Binance.Net.Objects.Models.Futures.Socket;

using CryptoExchange.Net.Sockets;

using Gaten.Windows.MintPandaLinux.Utils;

using System;
using System.IO;
using System.Linq;

namespace Gaten.Windows.MintPandaLinux.Contents
{
    public class BinanceManager
    {
        public static BinanceClient Client { get; set; } = default!;
        public static BinanceSocketClient SocketClient { get; set; } = default!;
        public static DateTime StartTime { get; set; }
        public static double Seed { get; set; }
        public static decimal BnbPrice { get; set; }
        public static double UsdKrw { get; set; }

        public static void Init()
        {
            var seedData = File.ReadAllLines("seed.txt");
            StartTime = DateTime.Parse(seedData[0]);
            Seed = double.Parse(seedData[1]);

            var apiData = File.ReadAllLines("binance_api.txt");
            Client = new BinanceClient(new BinanceClientOptions
            {
                ApiCredentials = new BinanceApiCredentials(apiData[0], apiData[1])
            });
            SocketClient = new BinanceSocketClient(new BinanceSocketClientOptions
            {
                ApiCredentials = new BinanceApiCredentials(apiData[0], apiData[1])
            });

            CalculateUsdKrw();
            GetBnbMarkPriceUpdatesAsync();
        }

        private static async void GetBnbMarkPriceUpdatesAsync()
        {
            var result = await SocketClient.UsdFuturesStreams.SubscribeToMarkPriceUpdatesAsync("BNBUSDT", 1000, BnbMarkPriceUpdatesAsyncOnMessage);
        }

        private static void BnbMarkPriceUpdatesAsyncOnMessage(DataEvent<BinanceFuturesUsdtStreamMarkPrice> obj)
        {
            BnbPrice = obj.Data.MarkPrice;
        }

        public static void CalculateUsdKrw()
        {
            WebCrawler.SetUrl("https://www.google.com/finance/quote/USD-KRW");
            UsdKrw = double.Parse(WebCrawler.SelectNode("div", "class", "AHmHk").InnerText);
        }

        /// <summary>
        /// Return (Balance, PNL)
        /// </summary>
        /// <param name="isUsdt"></param>
        /// <returns></returns>
        public static (double, double) GetBinanceBalance(bool isUsdt = true)
        {
            try
            {
                var result = Client.UsdFuturesApi.Account.GetBalancesAsync();
                result.Wait();
                var balance = result.Result.Data;
                var usdtBalance = balance.First(b => b.Asset.Equals("USDT"));
                var usdt = usdtBalance.WalletBalance + usdtBalance.CrossUnrealizedPnl;
                var bnb = balance.First(b => b.Asset.Equals("BNB")).WalletBalance * BnbPrice;
                var totalBalance = (double)(usdt + bnb);

                return isUsdt ?
                    (totalBalance, totalBalance - Seed) :
                    (totalBalance * UsdKrw, (totalBalance - Seed) * UsdKrw);
            }
            catch
            {
                return (-1, -1);
            }
        }
    }
}
