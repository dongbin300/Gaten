using Gaten.Net.Extensions;
using Gaten.Net.Stock.MercuryTradingModel.Enums;
using Gaten.Net.Wpf.Models;
using Gaten.Stock.ChartManager.Charts;

using System;
using System.Text;

namespace Gaten.Stock.ChartManager.Bots
{
    /// <summary>
    /// 백테스트 봇으로 사용예정
    /// 트레이메뉴에 1분봉데이터, 5분봉데이터, 1일봉데이터.. 등등 여러개 추가
    /// 5분봉데이터는 1분봉데이터를 얻어오고 그걸 가공
    /// 
    /// </summary>
    internal class TempBot
    {
        public StringBuilder TradeLog = new();
        public Worker Worker = new();

        public TempBot(Worker worker)
        {
            Worker = worker;
        }

        /*
         * asset = 10000
         * period = 2022,7,17,0,0:0,0,7,0,0
         * interval = 5m
         * target = SOLUSDT
         * scenario1.strategy1.signal = rsi < 30
         * scenario1.strategy1.order = long,market,1.0
         * scenario1.strategy2.signal = rsi > 70
         * scenario1.strategy2.order = short,market,1.0
         * scenario1.strategy3.signal = SOLUSDT.poe < -20%
         * scenario1.strategy3.order = long,market,SOLUSDT.amount * 1
         */
        public string Run()
        {
            // 자산 초기화
            var asset = new TempAsset
            {
                Balance = 10000,
                Position = new TempPosition()
            };

            var dayCount = 7; // 2일 백테스팅
            var charts = ChartLoader.GetChartPack("SOLUSDT"); // SOLUSDT 타겟
            charts.Select(new DateTime(2022, 7, 17, 0, 0, 0)); // 2022년 7월 15일 부터 2일간
            Worker.SetProgressBar(1, dayCount * 288);
            int p = 0;
            for (int d = 0; d < dayCount; d++)
            {
                for (int i = 0; i < 288; i++)
                {
                    Worker.Progress(++p);
                    Worker.ProgressText($"{p} / {dayCount * 288}");

                    var info = charts.Next(); // 분봉의 정보를 가져옴
                    if (info.RSI.Rsi > 70) // RSI가 70이상이면 매도
                    {
                        var price = Convert.ToDecimal(info.Candle.Close);
                        var quantity = 1.0m;
                        asset.Sell(price, quantity);
                        var estimatedAsset = price * asset.Position.ToDecimal() + asset.Balance;
                        TradeLog.AppendLine($"{info.DateTime.ToStandardString()},Sell,{price},{quantity},현재 {asset.Balance} USDT, {asset.Position.ToString()} SOL ({estimatedAsset}USDT)");
                    }
                    else if (info.RSI.Rsi < 30) // RSI가 30미만이면 매수
                    {
                        var price = Convert.ToDecimal(info.Candle.Close);
                        var quantity = 1.0m;
                        asset.Buy(price, quantity);
                        var estimatedAsset = price * asset.Position.ToDecimal() + asset.Balance;
                        TradeLog.AppendLine($"{info.DateTime.ToStandardString()},Buy,{price},{quantity},현재 {asset.Balance} USDT, {asset.Position.ToString()} SOL ({estimatedAsset}USDT)");
                    }
                }
            }

            return TradeLog.ToString();
        }
    }

    internal class TempAsset
    {
        /// <summary>
        /// 현금 잔고
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 포지션
        /// </summary>
        public TempPosition Position { get; set; } = new();

        public void Buy(decimal price, decimal quantity)
        {
            Balance -= price;
            Position.Long(quantity);
        }

        public void Sell(decimal price, decimal quantity)
        {
            Balance += price;
            Position.Short(quantity);
        }
    }

    internal class TempPosition
    {
        public PositionSide Side { get; set; }
        public decimal Amount { get; set; }

        public void Long(decimal quantity)
        {
            if (Side == PositionSide.Long)
            {
                Amount += quantity;
            }
            else
            {
                Amount -= quantity;
                if (Amount < 0)
                {
                    Side = PositionSide.Long;
                    Amount = -Amount;
                }
            }
        }

        public void Short(decimal quantity)
        {
            if (Side == PositionSide.Short)
            {
                Amount += quantity;
            }
            else
            {
                Amount -= quantity;
                if (Amount < 0)
                {
                    Side = PositionSide.Short;
                    Amount = -Amount;
                }
            }
        }

        public decimal ToDecimal()
        {
            return decimal.Parse(ToString());
        }

        public override string ToString()
        {
            return (Side == PositionSide.Long ? "+" : "-") + Amount;
        }
    }
}
