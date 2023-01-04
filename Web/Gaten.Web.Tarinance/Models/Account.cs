using Gaten.Web.Tarinance.Models.Market;

using Newtonsoft.Json;

namespace Gaten.Web.Tarinance.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string RegisterDate { get; set; }
        public string Balance { get; set; }
        public string AssetData { get; set; }
        public IList<Asset> Assets { get; set; }

        public Account()
        {

        }

        public Account(string id, string password, string nickname, string registerDate, string balance, string assetData)
        {
            Id = id;
            Password = password;
            Nickname = nickname;
            RegisterDate = registerDate;
            Balance = balance;
            AssetData = assetData;
        }

        public void SerializeAsset()
        {
            AssetData = JsonConvert.SerializeObject(Assets);
        }

        public void DeserializeAsset()
        {
            Assets = JsonConvert.DeserializeObject<List<Asset>>(AssetData) ?? new List<Asset>();
        }
    }
}
