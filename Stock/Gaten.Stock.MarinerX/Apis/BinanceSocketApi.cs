using Binance.Net.Clients;
using Binance.Net.Interfaces;
using Binance.Net.Objects;
using Binance.Net.Objects.Models.Futures.Socket;

using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Sockets;

using Gaten.Net.IO;

using System;
using System.Collections.Generic;
using System.Windows;

namespace Gaten.Stock.MarinerX.Apis
{
    internal class BinanceSocketApi
    {
        #region Initialize
        static BinanceSocketClient binanceClient = new();

        /// <summary>
        /// 바이낸스 클라이언트 초기화
        /// </summary>
        public static void Init()
        {
            try
            {
                var data = GResource.BinanceApiKeyText;

                binanceClient = new BinanceSocketClient(new BinanceSocketClientOptions
                {
                    ApiCredentials = new ApiCredentials(data[0], data[1])
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Market API
        public static async void GetKlineUpdatesAsync()
        {
            var result = await binanceClient.UsdFuturesStreams.SubscribeToKlineUpdatesAsync("BTCUSDT", Binance.Net.Enums.KlineInterval.OneMinute, KlineUpdatesOnMessage);
        }

        public static async void GetContinuousKlineUpdatesAsync()
        {
            var result = await binanceClient.UsdFuturesStreams.SubscribeToContinuousContractKlineUpdatesAsync("BTCUSDT", Binance.Net.Enums.ContractType.Perpetual, Binance.Net.Enums.KlineInterval.OneMinute, ContinuousKlineUpdatesOnMessage);
        }

        public static async void GetAllMarketMiniTickersAsync()
        {
            var result = await binanceClient.UsdFuturesStreams.SubscribeToAllMiniTickerUpdatesAsync(AllMarketMiniTickersOnMessage);
        }

        private static void AllMarketMiniTickersOnMessage(DataEvent<IEnumerable<IBinanceMiniTick>> obj)
        {
            var data = obj.Data;
            throw new NotImplementedException();
        }

        private static void ContinuousKlineUpdatesOnMessage(DataEvent<BinanceStreamContinuousKlineData> obj)
        {
            var data = obj.Data.Data;
            throw new NotImplementedException();
        }

        private static void KlineUpdatesOnMessage(DataEvent<IBinanceStreamKlineData> obj)
        {
            var data = obj.Data.Data;
            throw new NotImplementedException();
        }
        #endregion
    }
}
