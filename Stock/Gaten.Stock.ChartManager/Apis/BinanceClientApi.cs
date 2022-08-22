﻿using Binance.Net.Clients;
using Binance.Net.Enums;
using Binance.Net.Objects;

using CryptoExchange.Net.Authentication;

using Gaten.Net.IO;
using Gaten.Stock.ChartManager.Charts;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace Gaten.Stock.ChartManager.Apis
{
    internal class BinanceClientApi
    {
        static BinanceClient binanceClient = new();

        public static void Init()
        {
            try
            {
                var data = GResource.BinanceApiKeyText;

                binanceClient = new BinanceClient(new BinanceClientOptions
                {
                    ApiCredentials = new ApiCredentials(data[0], data[1])
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<string> GetExchangeInfo()
        {
            var usdFuturesSymbolData = binanceClient.UsdFuturesApi.ExchangeData.GetExchangeInfoAsync();
            usdFuturesSymbolData.Wait();
            var data = usdFuturesSymbolData.Result.Data.Symbols
                .Where(s => s.Name.EndsWith("USDT"));

            List<string> symbols = new();
            foreach (var symbol in data)
            {
                symbols.Add(symbol.Name);
            }
            symbols.Remove("LINKUSDT");

            return symbols;
        }

        public static void GetCandleDataForOneDay(string symbol, DateTime startTime)
        {
            var result = binanceClient.UsdFuturesApi.ExchangeData.GetKlinesAsync(
                symbol,
                KlineInterval.OneMinute,
                startTime,
                startTime.AddMinutes(1439),
                1500);
            result.Wait();

            var builder = new StringBuilder();
            foreach (var data in result.Result.Data)
            {
                builder.AppendLine(string.Join(',', new string[] {
                data.OpenTime.ToString("yyyy-MM-dd HH:mm:ss"),
                data.OpenPrice.ToString(),
                data.HighPrice.ToString(),
                data.LowPrice.ToString(),
                data.ClosePrice.ToString(),
                data.Volume.ToString(),
                data.QuoteVolume.ToString(),
                data.TakerBuyBaseVolume.ToString(),
                data.TakerBuyQuoteVolume.ToString(),
                data.TradeCount.ToString()
            }));
            }

            if (builder.Length < 10)
            {
                return;
            }

            File.WriteAllText(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "BinanceFuturesData",
                symbol,
                $"{symbol}_{startTime:yyyy-MM-dd}.csv"),
                builder.ToString());
        }

        public static List<Candle> GetCandles(string symbol, KlineInterval candleInterval, DateTime startTime, DateTime endTime, int limit)
        {
            var result = binanceClient.UsdFuturesApi.ExchangeData.GetKlinesAsync(symbol, candleInterval, startTime, endTime, limit);
            result.Wait();

            var candles = new List<Candle>();

            foreach (var data in result.Result.Data)
            {
                candles.Add(new Candle(
                    data.OpenTime,
                    decimal.ToDouble(data.OpenPrice),
                    decimal.ToDouble(data.HighPrice),
                    decimal.ToDouble(data.LowPrice),
                    decimal.ToDouble(data.ClosePrice),
                    decimal.ToDouble(data.Volume)
                    ));
            }

            return candles;
        }
    }
}