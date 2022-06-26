//using Gaten.Stock.MockTrader.BinanceTrade;
//using Gaten.Stock.MockTrader.Chart;

//using static Gaten.Stock.MockTrader.BinanceTrade.TradeMarket;

//namespace Gaten.Stock.MockTrader.Strategies
//{
//    internal class CommonStrategy
//    {
//        static bool loFlag, upFlag, entryFlag;

//        public static Trade? Rsi_1(string symbol, Candle candle, double? rsi, ref int rsiFlag, ref int combo)
//        {
//            Trade? trade = null;

//            if (rsi < 30)
//            {
//                int quantity = 0;
//                if (rsiFlag == 2)
//                {
//                    quantity = (int)Assets.AbsoluteSize(symbol);
//                    combo = 0;
//                }
//                else
//                {
//                    quantity = (int)(Assets.EvaluatedAmount(symbol, candle) / candle.Close / Assets.DivisionRate);
//                    combo++;
//                }

//                rsiFlag = 1;
//                trade = Buy(symbol, candle, quantity);
//            }
//            else if (rsi > 70)
//            {
//                int quantity = 0;
//                if (rsiFlag == 1)
//                {
//                    quantity = (int)Assets.AbsoluteSize(symbol);
//                    combo = 0;
//                }
//                else
//                {
//                    quantity = (int)(Assets.EvaluatedAmount(symbol, candle) / candle.Close / Assets.DivisionRate);
//                    combo++;
//                }

//                rsiFlag = 2;
//                trade = Sell(symbol, candle, quantity);
//            }
//            else if (combo >= 5)
//            {
//                if (rsi < 45 && !Assets.IsLongPosition(symbol))
//                {
//                    int quantity = (int)Assets.AbsoluteSize(symbol);
//                    combo = 0;
//                    trade = Buy(symbol, candle, quantity);
//                }
//                else if (rsi > 55 && Assets.IsLongPosition(symbol))
//                {
//                    int quantity = (int)Assets.AbsoluteSize(symbol);
//                    combo = 0;
//                    trade = Sell(symbol, candle, quantity);
//                }
//            }

//            return trade;
//        }

//        public static Trade? Rsi_2(string symbol, Candle candle, double? rsi, ref int rsiFlag)
//        {
//            Trade? trade = null;

//            if (rsi < 35)
//            {
//                if (rsiFlag != 1)
//                {
//                    int quantity = Assets.CoinSize[symbol] < 0 ?
//                        (int)Assets.AbsoluteSize(symbol) :
//                        (int)(Assets.EvaluatedAmount(symbol, candle) / candle.Close / Assets.DivisionRate);
//                    trade = Buy(symbol, candle, quantity);
//                }
//                rsiFlag = 1;
//            }
//            else if (rsi > 65)
//            {
//                if (rsiFlag != 2)
//                {
//                    int quantity = Assets.CoinSize[symbol] > 0 ?
//                        (int)Assets.AbsoluteSize(symbol) :
//                        (int)(Assets.EvaluatedAmount(symbol, candle) / candle.Close / Assets.DivisionRate);
//                    trade = Sell(symbol, candle, quantity);
//                }
//                rsiFlag = 2;
//            }

//            return trade;
//        }

//        public static Trade? Rsi_general(string symbol, Candle candle, double? rsi, double rsiUp, double rsiDown, ref int rsiFlag)
//        {
//            Trade? trade = null;

//            if (rsi < rsiDown)
//            {
//                if (rsiFlag != 1)
//                {
//                    int quantity = Assets.CoinSize[symbol] < 0 ?
//                        (int)Assets.AbsoluteSize(symbol) :
//                        (int)(Assets.EvaluatedAmount(symbol, candle) / candle.Close / Assets.DivisionRate);
//                    trade = Buy(symbol, candle, quantity);
//                }
//                rsiFlag = 1;
//            }
//            else if (rsi > rsiUp)
//            {
//                if (rsiFlag != 2)
//                {
//                    int quantity = Assets.CoinSize[symbol] > 0 ?
//                        (int)Assets.AbsoluteSize(symbol) :
//                        (int)(Assets.EvaluatedAmount(symbol, candle) / candle.Close / Assets.DivisionRate);
//                    trade = Sell(symbol, candle, quantity);
//                }
//                rsiFlag = 2;
//            }

//            return trade;
//        }

//        public static Trade? Bb_1(string symbol, Candle candle, double bb1up, double bb1lo, double bb2up, double bb2lo)
//        {
//            Trade? trade = null;

//            if (candle.Low < bb1lo)
//            {
//                if (upFlag)
//                {
//                    Assets.ClosePosition(symbol, candle);
//                    upFlag = false;
//                    entryFlag = false;
//                }

//                loFlag = true;
//            }
//            else if (candle.High > bb1up)
//            {
//                if (loFlag)
//                {
//                    Assets.ClosePosition(symbol, candle);
//                    loFlag = false;
//                    entryFlag = false;
//                }

//                upFlag = true;
//            }
//            else if (loFlag && candle.Close > bb2lo && !entryFlag)
//            {
//                int quantity = (int)(Assets.EvaluatedAmount(symbol, candle) / candle.Close / Assets.DivisionRate);
//                trade = Buy(symbol, candle, quantity);
//                entryFlag = true;
//            }
//            else if (upFlag && candle.Close < bb2up && !entryFlag)
//            {
//                int quantity = (int)(Assets.EvaluatedAmount(symbol, candle) / candle.Close / Assets.DivisionRate);
//                trade = Sell(symbol, candle, quantity);
//                entryFlag = true;
//            }

//            return trade;
//        }
//    }
//}
