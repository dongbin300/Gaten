using DecimalMath;

using Gaten.Net.IO;
using Gaten.Net.Math;

using SMath = System.Math;

namespace Gaten.Net.Windows.KakaoTalk.Game.StockGame
{
    /// <summary>
    /// TODO LIST
    /// </summary>
    public class StockGameEngine
    {
        private static SmartRandom r = new();
        public static string ProfileFilePath => GPath.Desktop.Down("sg_profile.txt");
        public static string StockItemFilePath => GPath.Desktop.Down("sg_item.txt");
        public static string MarketFilePath => GPath.Desktop.Down("sg_market.txt");

        public static StockGameProfile GmProfile = default!;
        public static List<StockGameProfile> Profiles = new();
        public static List<StockItem> StockItems = new();
        public static List<IndexItem> IndexItems = new();
        private static string Version = "v2.4.1.59";
        private static decimal InitMoney = 1000000;
        private static string latestCurrentMessage = string.Empty;
        public static decimal Fee = 1.0M;
        private static decimal LimitUpDown = 80M;

        /// <summary>
        /// 시장 관심도
        /// 새로고침때마다 -2,-1,0,+1,+2 중 랜덤으로 진행
        /// 높을수록 주가 +% 뜰 확률이 높아짐
        /// </summary>
        public static int MarketInterestDegree = 50;

        /// <summary>
        /// 시장 과열도
        /// 새로고침때마다 투자자 매매 거래대금에 따라 값이 높아짐
        /// 높을수록 주가 변동폭이 높아짐
        /// </summary>
        public static decimal MarketFireDegree = 0;
        public static decimal TransactionAmount = 100M;

        public static string Init()
        {
            // market data load
            var marketData = GFile.ReadToArray(MarketFilePath);
            MarketInterestDegree = int.Parse(marketData[0]);
            var prevIrispi = decimal.Parse(marketData[1]);

            // stockitem data load
            var itemData = GFile.ReadToArray(StockItemFilePath);
            StockItems.Clear();
            foreach (var item in itemData)
            {
                var data = item.Split(',', StringSplitOptions.RemoveEmptyEntries);
                StockItems.Add(new StockItem(data[0], data[1], data[2]));
            }

            // init index items
            IndexItems.Add(new IndexItem("101", "RISPI", CalcRispi()));
            IndexItems.Add(new IndexItem("102", "iRISPI", prevIrispi));

            // profile data load
            var profileData = GFile.ReadToArray(ProfileFilePath);
            Profiles.Clear();
            foreach (var profile in profileData)
            {
                var assets = new List<Asset>();
                var data = profile.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (data.Length > 2)
                {
                    for (int i = 2; i < data.Length; i += 3)
                    {
                        assets.Add(new Asset(data[i], data[i + 1], data[i + 2]));
                    }
                }
                Profiles.Add(new StockGameProfile(data[0], decimal.Parse(data[1]), assets));
            }

            // init latest current message
            var messages = new List<string>();
            foreach(var item in IndexItems)
            {
                var itemName = item.Name + new string(' ', 15 - item.Name.Length * 2);
                messages.Add($"{item.Code,-2} {itemName} {item.Price,-8:#,###}");
            }
            foreach (var item in StockItems)
            {
                var itemName = item.Name + new string(' ', 15 - item.Name.Length * 2);
                messages.Add($"{item.Code,-2} {itemName} {item._Price,-8:#,###}");
            }
            latestCurrentMessage = string.Join("\n", messages);

            // init transaction amount
            TransactionAmount = 100M;

            // init GM profile
            GmProfile = Profiles.Find(x => x.Name.Equals("리다")) ?? default!;

            return $"리다증권 시장 개시되었습니다.\n{Version}\n시장관심도: {MarketInterestDegree}\nRISPI: {GetCurrentRispi()}\niRISPI: {GetCurrentIrispi()}\n종목수: {StockItems.Count}\n회원수: {Profiles.Count}";
        }

        public static string Save()
        {
            // market save
            var contents = new List<string>
            {
                MarketInterestDegree.ToString(),
                GetCurrentIrispi().ToString()
            };
            GFile.WriteByArray(MarketFilePath, contents);

            // stockitem save
            contents = new List<string>();
            foreach (var item in StockItems)
            {
                contents.Add($"{item.Code},{item.Name},{SMath.Round(item._Price)}");
            }
            GFile.WriteByArray(StockItemFilePath, contents);

            // profile save
            contents = new List<string>();
            foreach (var profile in Profiles)
            {
                var baseString = $"{profile.Name},{SMath.Round(profile.Money)}";
                var assetString = string.Empty;
                foreach (var asset in profile.Assets)
                {
                    assetString += $",{asset.Code},{SMath.Round(asset._Quantity)},{SMath.Round(asset._Amount)}";
                }
                contents.Add(baseString + assetString);
            }
            GFile.WriteByArray(ProfileFilePath, contents);

            return "저장이 완료되었습니다.";
        }

        public static string New(string name)
        {
            if (Profiles.Find(x => x.Name == name) != null)
            {
                return $"{name}님은 이미 개설하셨습니다.";
            }

            Profiles.Add(new StockGameProfile(name, InitMoney, new()));

            return $"환영합니다!\n{name}님의 계좌가 개설되었습니다.\n개설축하금: {InitMoney}";
        }

        public static string Refresh()
        {
            var prevRispi = GetCurrentRispi();
            var prevIrispi = GetCurrentIrispi();

            // 시장 과열도 0~4
            MarketFireDegree = SMath.Clamp(DecimalEx.Log(TransactionAmount, 4) / 10, 0, 4);
            TransactionAmount = 100;
            // 시장 과열도 값 3~7
            var marketFireDegreeValue = 7M - MarketFireDegree;
            var widthRatio = LimitUpDown / marketFireDegreeValue; // 상하한가 80%

            // 시장 관심도 25~80 , MarketInterestDegree 25~80
            MarketInterestDegree += r.Next(100) switch
            {
                < 11 => -2,
                < 44 => -1,
                < 63 => 0,
                < 92 => 1,
                _ => 2
            };
            MarketInterestDegree = SMath.Clamp(MarketInterestDegree, 15, 80);

            // set stock items recalc
            var messages = new List<string>();
            foreach (var item in StockItems)
            {
                var num = r.Next(1095) + 1;
                // 등락률
                var percent = SMath.Round((marketFireDegreeValue - DecimalEx.Log(num)) * widthRatio, 2);
                if (r.Next(100) >= MarketInterestDegree)
                {
                    percent *= -1;
                }
                var percentString = percent > 0 ? "+" + percent + "%" : percent + "%";
                var prevPrice = item._Price;
                item.Price = (item._Price * (100 + percent) / 100).ToString();
                var gap = item._Price - prevPrice;
                var gapString =
                    percent == LimitUpDown ? "↑" + gap.ToString("#,###") :
                    percent == -LimitUpDown ? "↓" + (-gap).ToString("#,###") :
                    gap > 0 ? "▲" + gap.ToString("#,###") :
                    gap == 0 ? "◆" :
                    "▼" + (-gap).ToString("#,###");
                var itemName = item.Name + new string(' ', 15 - item.Name.Length * 2);
                var message = $"{item.Code,-2} {itemName} {item._Price,-8:#,###} {gapString,-8:#,###} {percentString,-8}";
                messages.Add(message);
            }

            // set index items recalc by stock items
            SetRispi();
            SetIrispi(prevRispi, prevIrispi);
            var rispiGap = GetCurrentRispi() - prevRispi;
            var irispiGap = GetCurrentIrispi() - prevIrispi;
            var rispiGapString = rispiGap > 0 ? "▲" + rispiGap : rispiGap == 0 ? "◆" : "▼" + (-rispiGap);
            var irispiGapString = irispiGap > 0 ? "▲" + irispiGap : irispiGap == 0 ? "◆" : "▼" + (-irispiGap);
            var rispiPercent = rispiGap > 0 ? "+" + (rispiGap / prevRispi).ToString("P") : (rispiGap / prevRispi).ToString("P");
            var irispiPercent = irispiGap > 0 ? "+" + (irispiGap / prevIrispi).ToString("P") : (irispiGap / prevIrispi).ToString("P");

            latestCurrentMessage = $"{DateTime.Now:yyyy년MM월dd일 HH시mm분} 시장관심도 {MarketInterestDegree}\n" +
                $"{"101",-2} {"RISPI",-6} {GetCurrentRispi()} {rispiGapString} {rispiPercent}\n" +
                $"{"102",-2} {"iRISPI",-6} {GetCurrentIrispi()} {irispiGapString} {irispiPercent}\n" +
                $"" + string.Join("\n", messages);

            return latestCurrentMessage;
        }

        public static decimal CalcRispi() =>
            SMath.Round(StockItems.Average(x => DecimalEx.Log(x._Price, 4) * 1000));

        public static decimal CalcIrispi(decimal prevRispi, decimal prevIrispi) =>
            SMath.Round(prevIrispi * (2 * prevRispi - GetCurrentRispi()) / prevRispi);

        public static void SetRispi() =>
           (IndexItems.Find(x => x.Code.Equals("101")) ?? default!).Price = CalcRispi();

        public static void SetIrispi(decimal prevRispi, decimal prevIrispi) =>
           (IndexItems.Find(x => x.Code.Equals("102")) ?? default!).Price = CalcIrispi(prevRispi, prevIrispi);

        public static decimal GetCurrentRispi() =>
            (IndexItems.Find(x => x.Code.Equals("101")) ?? default!).Price;

        public static decimal GetCurrentIrispi() =>
           (IndexItems.Find(x => x.Code.Equals("102")) ?? default!).Price;

        public static string Tax()
        {
            var messages = new List<string>();
            foreach (var profile in Profiles)
            {
                if (profile.Name.Equals("리다"))
                {
                    continue;
                }

                decimal tax = 0M;
                var asset = _CalcSumAsset(profile.Name);
                var indexAsset = _CalcSumIndexAsset(profile.Name);
                // 세금 -10~50%
                if(asset < 100000000)
                {
                    tax = 0;
                }
                else if (indexAsset < 100)
                {
                    tax = SMath.Round(asset * 0.5M);
                }
                else
                {
                    var indexAssetRatio = indexAsset / asset;
                    var taxPer = SMath.Clamp(0.5M - indexAssetRatio / 165M, -0.1M, 0.5M);
                    tax = SMath.Round(asset * taxPer);
                }

                profile.Money -= tax;
                messages.Add($"{profile.Name}  세금 {tax:#,###}");
            }
            return $"{DateTime.Now:yyyy년MM월dd일 HH시mm분} 세금 납세\n" + string.Join("\n", messages);
        }

        public static string Reward()
        {
            var messages = new List<string>();
            foreach (var profile in Profiles)
            {
                var sumAsset = _CalcSumAsset(profile.Name);
                var reward = SMath.Round(sumAsset * 0.005M);
                profile.Money += reward;

                var sumIndexAsset = _CalcSumIndexAsset(profile.Name);
                var indexReward = SMath.Round(sumIndexAsset * 0.0075M);
                profile.Money += indexReward;

                if(indexReward > 0)
                {
                    messages.Add($"{profile.Name}  현금+ {reward+indexReward:#,###} ({reward:#,###}+ 인덱스:{indexReward:#,###})");
                }
                else
                {
                    messages.Add($"{profile.Name}  현금+ {reward:#,###}");
                }
            }
            return $"{DateTime.Now:yyyy년MM월dd일 HH시mm분} 이자 지급\n" + string.Join("\n", messages);
        }

        public static string Help() =>
            $"매매 수수료 {Fee}% 주말 0.5%\n" +
            "이자 0.5%, 인덱스이자 0.75%\n" +
            "\n" +
            ".도움말, .?  -  도움말을 확인합니다.\n" +
            ".계좌개설  -  계좌를 개설합니다.\n" +
            ".정보, .나, .  -  나의 계좌정보를 확인합니다.\n" +
            ".매매  -  매매와 관련된 도움말을 확인합니다.\n" +
            ".현재  -  주식의 현재가를 확인합니다.\n" +
            ".랭킹  -  자산 랭킹을 확인합니다.";

        public static string HelpTrading() =>
            "매매 도움말\n\n" +
            ".매수 종목코드 수량  -  주식을 매수합니다.\n" +
            ".매수 종목코드 비율.  -  주식을 현금비율로 매수합니다.\n" +
            ".ㅅ 종목코드  -  주식을 전량매수합니다.\n" +
            "\n" +
            ".매도 종목코드 수량  -  주식을 매도합니다.\n" +
            ".매도 종목코드 비율.  -  주식을 보유비율로 매도합니다.\n" +
            ".ㄷ 종목코드  -  주식을 전량매도합니다.\n" +
            "\n" +
            ".롱 비율.  -  보유중인 iRISPI를 전량매도하고 RISPI를 현금비율로 매수합니다.\n" +
            ".숏 비율.  -  보유중인 RISPI를 전량매도하고 iRISPI를 현금비율로 매수합니다.\n";

        public static string Current() => latestCurrentMessage;

        /// <summary>
        /// 수량으로 매수
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="userName"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static string Buy(string itemCode, string userName, decimal quantity)
        {
            var item = StockItems.Find(x => x.Code == itemCode);
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            if (quantity < 1)
            {
                return "0 이하의 수량은 매수할 수 없습니다.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            if (user.Money < item._Price * quantity)
            {
                return "매수금이 부족합니다.";
            }

            return _Buy(item, user, quantity);
        }

        /// <summary>
        /// 비율로 매수
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="userName"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static string BuyPer(string itemCode, string userName, int percent)
        {
            var item = StockItems.Find(x => x.Code == itemCode);
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            if (percent < 1 || percent > 100)
            {
                return "1~100의 정수를 입력해 주세요.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var quantity = user.Money / item._Price * percent / 100;
            if (quantity < 1)
            {
                return "매수금이 부족합니다.";
            }

            return _Buy(item, user, quantity);
        }

        public static string BuyIndex(string itemCode, string userName, decimal quantity)
        {
            var item = IndexItems.Find(x => x.Code == itemCode);
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            if (user.Money < item.Price * quantity)
            {
                return "매수금이 부족합니다.";
            }

            return _BuyIndex(item, user, quantity);
        }

        public static string BuyIndexPer(string itemCode, string userName, int percent)
        {
            var item = IndexItems.Find(x => x.Code == itemCode);
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            if (percent < 1 || percent > 100)
            {
                return "1~100의 정수를 입력해 주세요.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var quantity = user.Money / item.Price * percent / 100;
            if (quantity < 1)
            {
                return "매수금이 부족합니다.";
            }

            return _BuyIndex(item, user, quantity);
        }

        private static string _Buy(StockItem item, StockGameProfile user, decimal quantity)
        {
            user.Money -= item._Price * quantity;
            var userAsset = user.Assets.Find(x => x.Code == item.Code);
            if (userAsset == null)
            {
                var asset = new Asset(item.Code, "0", "0");
                user.Assets.Add(asset);
                userAsset = asset;
            }
            userAsset.Quantity = (userAsset._Quantity + quantity).ToString();
            userAsset.Amount = (userAsset._Amount + item._Price * quantity).ToString();
            TransactionAmount += item._Price * quantity;

            return $"{user.Name}님의 매수 주문이 체결되었습니다.\n종목명: {item.Name}\n체결단가: {item._Price:#,###}\n수량: {quantity:#,###}";
        }

        private static string _BuyIndex(IndexItem item, StockGameProfile user, decimal quantity)
        {
            user.Money -= item.Price * quantity;
            var userAsset = user.Assets.Find(x => x.Code == item.Code);
            if (userAsset == null)
            {
                var asset = new Asset(item.Code, "0", "0");
                user.Assets.Add(asset);
                userAsset = asset;
            }
            userAsset.Quantity = (userAsset._Quantity + quantity).ToString();
            userAsset.Amount = (userAsset._Amount + item.Price * quantity).ToString();

            return $"{user.Name}님의 매수 주문이 체결되었습니다.\n종목명: {item.Name}\n체결단가: {item.Price:#,###}\n수량: {quantity:#,###}";
        }

        public static string Sell(string itemCode, string userName, decimal quantity)
        {
            var item = StockItems.Find(x => x.Code == itemCode);
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            if (quantity < 1)
            {
                return "0 이하의 수량은 매도할 수 없습니다.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var userAsset = user.Assets.Find(x => x.Code == itemCode);
            if (userAsset == null)
            {
                var asset = new Asset(item.Code, "0", "0");
                user.Assets.Add(asset);
                userAsset = asset;
            }

            return _Sell(item, user, userAsset, quantity);
        }

        public static string SellPer(string itemCode, string userName, int percent)
        {
            var item = StockItems.Find(x => x.Code == itemCode);
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            if (percent < 1 || percent > 100)
            {
                return "1~100의 정수를 입력해 주세요.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var userAsset = user.Assets.Find(x => x.Code == itemCode);
            if (userAsset == null)
            {
                var asset = new Asset(item.Code, "0", "0");
                user.Assets.Add(asset);
                userAsset = asset;
            }

            var quantity = userAsset._Quantity * percent / 100;
            if (quantity < 1)
            {
                return "매도수량이 부족합니다.";
            }

            return _Sell(item, user, userAsset, quantity);
        }

        public static string SellIndex(string itemCode, string userName, decimal quantity)
        {
            var item = IndexItems.Find(x => x.Code == itemCode);
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var userAsset = user.Assets.Find(x => x.Code == itemCode);
            if (userAsset == null)
            {
                var asset = new Asset(item.Code, "0", "0");
                user.Assets.Add(asset);
                userAsset = asset;
            }

            return _SellIndex(item, user, userAsset, quantity);
        }

        public static string SellIndexPer(string itemCode, string userName, int percent)
        {
            var item = IndexItems.Find(x => x.Code == itemCode);
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            if (percent < 1 || percent > 100)
            {
                return "1~100의 정수를 입력해 주세요.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var userAsset = user.Assets.Find(x => x.Code == itemCode);
            if (userAsset == null)
            {
                var asset = new Asset(item.Code, "0", "0");
                user.Assets.Add(asset);
                userAsset = asset;
            }

            var quantity = userAsset._Quantity * percent / 100;
            if (quantity < 1)
            {
                return "매도수량이 부족합니다.";
            }

            return _SellIndex(item, user, userAsset, quantity);
        }

        public static string _Sell(StockItem item, StockGameProfile user, Asset userAsset, decimal quantity)
        {
            if (userAsset._Quantity < quantity)
            {
                return "매도수량이 부족합니다.";
            }
            else if (userAsset._Quantity == quantity)
            {
                userAsset.Amount = "0";
                userAsset.Quantity = "0";
            }
            else
            {
                var averagePrice = userAsset._Amount / userAsset._Quantity;
                userAsset.Amount = (userAsset._Amount - averagePrice * quantity).ToString();
                userAsset.Quantity = (userAsset._Quantity - quantity).ToString();
            }

            var feeAmount = SMath.Round(item._Price * quantity * Fee / 100M);
            user.Money += item._Price * quantity - feeAmount;
            TransactionAmount += item._Price * quantity;

            return $"{user.Name}님의 매도 주문이 체결되었습니다.\n종목명: {item.Name}\n체결단가: {item._Price:#,###}\n수량: {quantity:#,###}";
        }

        public static string _SellIndex(IndexItem item, StockGameProfile user, Asset userAsset, decimal quantity)
        {
            if (userAsset._Quantity < quantity)
            {
                return "매도수량이 부족합니다.";
            }
            else if (userAsset._Quantity == quantity)
            {
                userAsset.Amount = "0";
                userAsset.Quantity = "0";
            }
            else
            {
                var averagePrice = userAsset._Amount / userAsset._Quantity;
                userAsset.Amount = (userAsset._Amount - averagePrice * quantity).ToString();
                userAsset.Quantity = (userAsset._Quantity - quantity).ToString();
            }

            user.Money += item.Price * quantity;

            return $"{user.Name}님의 매도 주문이 체결되었습니다.\n종목명: {item.Name}\n체결단가: {item.Price:#,###}\n수량: {quantity:#,###}";
        }

        public static string Long(string userName, int percent)
        {
            string result = string.Empty;

            var item = IndexItems.Find(x => x.Code.Equals("101"));
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            if (percent < 1 || percent > 100)
            {
                return "1~100의 정수를 입력해 주세요.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var inverseIndex = user.Assets.Find(x => x.Code.Equals("102"));
            if(inverseIndex != null)
            {
                if(inverseIndex._Quantity > 0)
                {
                    result += SellIndexPer("102", user.Name, 100);
                    result += Environment.NewLine;
                    result += Environment.NewLine;
                }
            }

            var quantity = user.Money / item.Price * percent / 100;
            if (quantity < 1)
            {
                return "매수금이 부족합니다.";
            }

            result += _BuyIndex(item, user, quantity);
            return result;
        }

        public static string Short(string userName, int percent)
        {
            string result = string.Empty;

            var item = IndexItems.Find(x => x.Code.Equals("102"));
            if (item == null)
            {
                return "존재하지 않는 종목코드입니다.";
            }

            if (percent < 1 || percent > 100)
            {
                return "1~100의 정수를 입력해 주세요.";
            }

            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var index = user.Assets.Find(x => x.Code.Equals("101"));
            if (index != null)
            {
                if(index._Quantity > 0)
                {
                    result += SellIndexPer("101", user.Name, 100);
                    result += Environment.NewLine;
                    result += Environment.NewLine;
                }
            }

            var quantity = user.Money / item.Price * percent / 100;
            if (quantity < 1)
            {
                return "매수금이 부족합니다.";
            }

            result += _BuyIndex(item, user, quantity);
            return result;
        }

        private static string CalcSumAsset(string userName)
        {
            var user = Profiles.Find(x => x.Name == userName);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var sum = _CalcSumAsset(userName);
            return $"{userName}  {sum}";
        }

        /// <summary>
        /// 인덱스 자산만 계산
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private static decimal _CalcSumIndexAsset(string userName)
        {
            var user = Profiles.Find(x => x.Name == userName);

            decimal sum = 0;
            foreach (var asset in user.Assets)
            {
                var item = IndexItems.Find(x => x.Code == asset.Code);
                if (item == null)
                {
                    continue;
                }

                sum += item.Price * asset._Quantity;
            }
            return sum;
        }

        /// <summary>
        /// 현금자산 + 주식자산 + 인덱스자산 총합을 계산
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private static decimal _CalcSumAsset(string userName)
        {
            var user = Profiles.Find(x => x.Name == userName);

            decimal sum = 0;
            foreach (var asset in user.Assets)
            {
                var item = StockItems.Find(x => x.Code == asset.Code);
                if (item == null)
                {
                    var item2 = IndexItems.Find(x => x.Code == asset.Code);
                    if (item2 == null)
                    {
                        continue;
                    }
                    sum += item2.Price * asset._Quantity;
                    continue;
                }

                sum += item._Price * asset._Quantity;
            }
            sum += user.Money;
            return sum;
        }

        public static string AssetRanking()
        {
            var rankings = new List<AssetRankingClass>();
            foreach (var profile in Profiles)
            {
                rankings.Add(new AssetRankingClass(profile.Name, _CalcSumAsset(profile.Name)));
            }

            var list = rankings.OrderByDescending(x => x.SumAsset).ToList();
            var baseString = "-리다증권 자산 랭킹\n\n";
            var strings = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                strings.Add($"{i + 1}. {list[i].Name}  {list[i].SumAsset:#,###}");
            }

            return baseString + string.Join("\n", strings);
        }

        public static string Info(string name)
        {
            var user = Profiles.Find(x => x.Name == name);
            if (user == null)
            {
                return "존재하지 않는 계좌입니다.\n계좌개설을 진행해 주세요.";
            }

            var baseString =
                $"￣￣￣￣￣￣￣￣{user.Name} 님 잔고￣￣￣￣￣￣￣￣\n";
            var assetStrings = new List<string>();
            foreach (var asset in user.Assets)
            {
                if (asset._Quantity == 0)
                {
                    continue;
                }

                var item = StockItems.Find(x => x.Code == asset.Code);
                if (item == null)
                {
                    var item2 = IndexItems.Find(x => x.Code == asset.Code);
                    if (item2 == null)
                    {
                        continue;
                    }
                    else
                    {
                        var indexAveragePrice = asset._Amount / asset._Quantity;
                        var indexCurrentAmount = asset._Quantity * item2.Price;
                        var indexEarn = indexCurrentAmount - asset._Amount;
                        var indexPoe = SMath.Round(indexEarn / asset._Amount * 100M, 2);

                        var indexEarnString = indexEarn > 0 ? "+" + indexEarn.ToString("#,###") : indexEarn == 0 ? "+0" : indexEarn.ToString("#,###");
                        var indexPoeString = indexPoe > 0 ? "+" + indexPoe : indexPoe.ToString();

                        var indexAssetString = $"{item2.Code} {item2.Name}({asset._Quantity:#,###})  {indexAveragePrice:#,###}  {indexEarnString}  {indexPoeString}%";
                        assetStrings.Add(indexAssetString);
                        continue;
                    }
                }

                var averagePrice = asset._Amount / asset._Quantity;
                var currentAmount = asset._Quantity * item._Price;
                var earn = currentAmount - asset._Amount;
                var poe = SMath.Round(earn / asset._Amount * 100M, 2);

                var earnString = earn > 0 ? "+" + earn.ToString("#,###") : earn == 0 ? "+0" : earn.ToString("#,###");
                var poeString = poe > 0 ? "+" + poe : poe.ToString();

                var assetString = $"{item.Code} {item.Name}({asset._Quantity:#,###})  {averagePrice:#,###}  {earnString}  {poeString}%";
                assetStrings.Add(assetString);
            }

            var moneyString = $"\n현금자산 [ {user.Money:#,###} ]";
            var sumAssetString = $"\n추정자산 [ {_CalcSumAsset(user.Name):#,###} ]";

            return baseString + string.Join("\n", assetStrings) + moneyString + sumAssetString;
        }
    }
}
