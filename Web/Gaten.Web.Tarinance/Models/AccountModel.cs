namespace Gaten.Web.Tarinance.Models
{
    public class AccountModel
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string RegisterDate { get; set; }
        public string Balance { get; set; }
        /// <summary>
        /// _ 수정해야함
        /// </summary>
        public string AssetData { get; set; }


        public AccountModel(string id, string password, string nickname, string registerDate, string balance, string assetData)
        {
            Id = id;
            Password = password;
            Nickname = nickname;
            RegisterDate = registerDate;
            Balance = balance;
            AssetData = assetData;
        }
    }
}
