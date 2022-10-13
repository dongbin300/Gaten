using Binance.Net.Clients;
using Binance.Net.Enums;
using Binance.Net.Objects;

using CryptoExchange.Net.Authentication;

using Gaten.Net.Extensions;
using Gaten.Net.IO;
using Gaten.Stock.MarinerX.Accounts;
using Gaten.Stock.MarinerX.Markets;
using Gaten.Stock.MarinerX.NewFolder;

using Skender.Stock.Indicators;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace Gaten.Stock.MarinerX.Apis
{
    internal class BinanceClientApi
    {
        #region Initialize
        static BinanceClient binanceClient = new();
        static BinanceClient binanceJsonClient = new();

        /// <summary>
        /// 바이낸스 클라이언트 초기화
        /// </summary>
        public static void Init()
        {
            try
            {
                var data = GResource.BinanceApiKeyText;

                binanceClient = new BinanceClient(new BinanceClientOptions
                {
                    ApiCredentials = new ApiCredentials(data[0], data[1])
                });

                binanceJsonClient = new BinanceClient(new BinanceClientOptions
                {
                    ApiCredentials = new ApiCredentials(data[0], data[1]),
                    OutputOriginalData = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Market API
        /// <summary>
        /// 선물 심볼이름만 가져오기
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFuturesSymbolNames()
        {
            var usdFuturesSymbolData = binanceClient.UsdFuturesApi.ExchangeData.GetExchangeInfoAsync();
            usdFuturesSymbolData.Wait();

            return usdFuturesSymbolData.Result.Data.Symbols
                .Where(s => s.Name.EndsWith("USDT") && !s.Name.Equals("LINKUSDT") && !s.Name.StartsWith("1"))
                .Select(s => s.Name)
                .ToList();
        }

        /// <summary>
        /// 선물 심볼 정보 가져오기
        /// </summary>
        /// <returns></returns>
        public static List<FuturesSymbol> GetFuturesSymbols()
        {
            var usdFuturesSymbolData = binanceClient.UsdFuturesApi.ExchangeData.GetExchangeInfoAsync();
            usdFuturesSymbolData.Wait();

            return usdFuturesSymbolData.Result.Data.Symbols
                .Where(s => s.Name.EndsWith("USDT") && !s.Name.Equals("LINKUSDT") && !s.Name.StartsWith("1"))
                .Select(s => new FuturesSymbol(s.Name, s.LiquidationFee, s.ListingDate, s.PriceFilter.MaxPrice, s.PriceFilter.MinPrice, s.PriceFilter.TickSize, s.LotSizeFilter.MaxQuantity, s.LotSizeFilter.MinQuantity, s.LotSizeFilter.StepSize, s.PricePrecision, s.QuantityPrecision, s.UnderlyingType))
                .ToList();
        }
        #endregion

        #region Chart API
        /// <summary>
        /// 하루 동안의 차트 데이터 가져오기
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="startTime"></param>
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
                path: GResource.BinanceFuturesDataPath.Down("1m", symbol, $"{symbol}_{startTime:yyyy-MM-dd}.csv"),
                contents: builder.ToString()
                );
        }

        /// <summary>
        /// 봉 데이터 가져오기
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static List<Quote> GetQuotes(string symbol, KlineInterval interval, DateTime startTime, DateTime endTime, int limit)
        {
            var result = binanceClient.UsdFuturesApi.ExchangeData.GetKlinesAsync(symbol, interval, startTime, endTime, limit);
            result.Wait();

            var quotes = new List<Quote>();

            foreach (var data in result.Result.Data)
            {
                quotes.Add(new Quote
                {
                    Date = data.OpenTime,
                    Open = data.OpenPrice,
                    High = data.HighPrice,
                    Low = data.LowPrice,
                    Close = data.ClosePrice,
                    Volume = data.Volume
                });
            }

            return quotes;
        }
        #endregion

        #region Account API
        /// <summary>
        /// 선물 계좌 정보 가져오기
        /// </summary>
        /// <returns></returns>
        public static FuturesAccount GetFuturesAccountInfo()
        {
            var accountInfo = binanceClient.UsdFuturesApi.Account.GetAccountInfoAsync();
            accountInfo.Wait();

            var info = accountInfo.Result.Data;

            return new FuturesAccount
            {
                Assets = info.Assets.Where(x => x.WalletBalance > 0).ToList(),
                Positions = info.Positions.Where(x => x.Symbol.EndsWith("USDT") && !x.Symbol.Equals("LINKUSDT")).ToList(),
                AvailableBalance = info.AvailableBalance,
                TotalMarginBalance = info.TotalMarginBalance,
                TotalUnrealizedProfit = info.TotalUnrealizedProfit,
                TotalWalletBalance = info.TotalWalletBalance
            };
        }

        /// <summary>
        /// 초기 레버리지 배율 바꾸기
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="leverage"></param>
        /// <returns></returns>
        public static bool ChangeInitialLeverage(string symbol, int leverage)
        {
            var changeInitialLeverage = binanceClient.UsdFuturesApi.Account.ChangeInitialLeverageAsync(symbol, leverage);
            changeInitialLeverage.Wait();

            return changeInitialLeverage.Result.Success;
        }

        /// <summary>
        /// 마진 타입 바꾸기
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool ChangeMarginType(string symbol, FuturesMarginType type)
        {
            var changeMarginType = binanceClient.UsdFuturesApi.Account.ChangeMarginTypeAsync(symbol, type);
            changeMarginType.Wait();

            return changeMarginType.Result.Success;
        }

        /// <summary>
        /// 전체 포지션 가져오기
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static List<FuturesPosition> GetPositionInformation(string? symbol = null)
        {
            var positionInformation = binanceClient.UsdFuturesApi.Account.GetPositionInformationAsync(symbol);
            positionInformation.Wait();

            return positionInformation.Result.Data
                .Where(x => x.Symbol.EndsWith("USDT") && !x.Symbol.Equals("LINKUSDT"))
                .Select(x=> new FuturesPosition
                {
                    Symbol = x.Symbol,
                    MarginType = x.MarginType,
                    Leverage = x.Leverage,
                    PositionSide = x.PositionSide,
                    Quantity = x.Quantity,
                    EntryPrice = x.EntryPrice,
                    MarkPrice = x.MarkPrice,
                    UnrealizedPnl = x.UnrealizedPnl,
                    LiquidationPrice = x.LiquidationPrice
                })
                .ToList();
        }

        /// <summary>
        /// 현재 포지션 가져오기
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static List<FuturesPosition> GetPositioningInformation(string? symbol = null)
        {
            var positionInformation = binanceClient.UsdFuturesApi.Account.GetPositionInformationAsync(symbol);
            positionInformation.Wait();

            return positionInformation.Result.Data.Where(x => x.Symbol.EndsWith("USDT") && !x.Symbol.Equals("LINKUSDT") && x.Quantity != 0)
                .Select(x => new FuturesPosition
                {
                    Symbol = x.Symbol,
                    MarginType = x.MarginType,
                    Leverage = x.Leverage,
                    PositionSide = x.PositionSide,
                    Quantity = x.Quantity,
                    EntryPrice = x.EntryPrice,
                    MarkPrice = x.MarkPrice,
                    UnrealizedPnl = x.UnrealizedPnl,
                    LiquidationPrice = x.LiquidationPrice
                })
                .ToList();
        }

        /// <summary>
        /// 현재 잔고 가져오기
        /// </summary>
        /// <returns></returns>
        public static List<FuturesBalance> GetBalance()
        {
            var balance = binanceClient.UsdFuturesApi.Account.GetBalancesAsync();
            balance.Wait();

            return balance.Result.Data.Where(x => x.Asset.Equals("USDT") || x.Asset.Equals("BNB"))
                .Select(x => new FuturesBalance
                {
                    AssetName = x.Asset,
                    Wallet = x.WalletBalance,
                    Available = x.AvailableBalance,
                    UnrealizedPnl = x.CrossUnrealizedPnl
                })
                .ToList();
        }
        #endregion

        #region Trading API
        /// <summary>
        /// 바이낸스 주문
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="side"></param>
        /// <param name="type"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public static void Order(string symbol, OrderSide side, FuturesOrderType type, decimal quantity, decimal? price = null)
        {
            var placeOrder = binanceClient.UsdFuturesApi.Trading.PlaceOrderAsync(symbol, side, type, quantity, price);
            placeOrder.Wait();
        }

        /// <summary>
        /// 매수 주문, Long
        /// 가격을 지정하면 지정가
        /// 지정하지 않으면 시장가
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public static void Buy(string symbol, double quantity, double? price = null)
        {
            var type = price == null ? FuturesOrderType.Market : FuturesOrderType.Limit;
            var placeOrder = binanceClient.UsdFuturesApi.Trading.PlaceOrderAsync(symbol, OrderSide.Buy, type, quantity.Convert<decimal>(), price?.Convert<decimal>());
        }

        /// <summary>
        /// 매도 주문, Short
        /// 가격을 지정하면 지정가
        /// 지정하지 않으면 시장가
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public static void Sell(string symbol, double quantity, double? price = null)
        {
            var type = price == null ? FuturesOrderType.Market : FuturesOrderType.Limit;
            var placeOrder = binanceClient.UsdFuturesApi.Trading.PlaceOrderAsync(symbol, OrderSide.Sell, type, quantity.Convert<decimal>(), price?.Convert<decimal>());
        }
        #endregion
    }
}
