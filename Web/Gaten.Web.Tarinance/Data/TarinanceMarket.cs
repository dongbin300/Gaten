using Gaten.Web.Tarinance.Models;
using Gaten.Web.Tarinance.Models.Market;

namespace Gaten.Web.Tarinance.Data
{
    public class TarinanceMarket
    {
        public List<Coin> Coins { get; set; } = new List<Coin>();
        public List<Account> Users { get; set; } = new List<Account>();

        public TarinanceMarket()
        {
            Database.Initialize();
            LoadMarketAsync().Wait();
        }

        public async Task LoadMarketAsync()
        {
            Coins = await Database.Select<Coin>("CRYPTO");
            Users = await Database.Select<Account>("ACCOUNT");
            foreach (var user in Users)
            {
                user.DeserializeAsset();
            }
        }

        public string Login(string id)
        {
            var user = Users.Find(x => x.Id.Equals(id));

            if (user == null)
            {
                return "존재하지 않는 계정입니다.";
            }

            return string.Empty;
        }
    }
}
