using Binance.Net.Clients;
using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Objects;
using Binance.Net.Objects.Models.Futures.Socket;

using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Sockets;

using Gaten.Net.IO;
using Gaten.Net.Stock.MercuryTradingModel.Charts;
using Gaten.Stock.MarinerX.Charts;

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
        public static async void GetKlineUpdatesAsync(string symbol, KlineInterval interval)
        {
            var result = await binanceClient.UsdFuturesStreams.SubscribeToKlineUpdatesAsync(symbol, interval, KlineUpdatesOnMessage);
        }

        public static async void GetContinuousKlineUpdatesAsync(string symbol, KlineInterval interval)
        {
            var result = await binanceClient.UsdFuturesStreams.SubscribeToContinuousContractKlineUpdatesAsync(symbol, ContractType.Perpetual, interval, ContinuousKlineUpdatesOnMessage);
        }

        public static async void GetAllMarketMiniTickersAsync()
        {
            var result = await binanceClient.UsdFuturesStreams.SubscribeToAllMiniTickerUpdatesAsync(AllMarketMiniTickersOnMessage);
        }

        private static void AllMarketMiniTickersOnMessage(DataEvent<IEnumerable<IBinanceMiniTick>> obj)
        {
            var data = obj.Data;
        }

        private static void ContinuousKlineUpdatesOnMessage(DataEvent<BinanceStreamContinuousKlineData> obj)
        {
            var data = obj.Data.Data;
        }

        private static void KlineUpdatesOnMessage(DataEvent<IBinanceStreamKlineData> obj)
        {
            var data = obj.Data.Data;
            QuoteFactory.UpdateQuote(new RealtimeQuote()
            {
                Symbol = obj.Data.Symbol,
                OpenTime = data.OpenTime,
                CloseTime = data.CloseTime,
                Open = data.OpenPrice,
                High = data.HighPrice,
                Low = data.LowPrice,
                Close = data.ClosePrice,
                Volume = data.Volume,
                TradeCount = data.TradeCount,
                TakerBuyBaseVolume = data.TakerBuyBaseVolume
            });
        }
        #endregion
    }
}
