namespace Gaten.Windows.MintPandaConsole.Models
{
    internal class Account
    {
        public string Platform { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
        public string SecondPassword { get; set; }
        public string AdditionalDescription { get; set; }
        public string SerialData => $"{Platform}${Description}${ID}${Password}${SecondPassword}${AdditionalDescription}";

        public Account(string platform = " ", string description = " ", string id = " ", string password = " ", string secondPassword = " ", string additionalDescription = " ")
        {
            Platform = platform;
            Description = description;
            ID = id;
            Password = password;
            SecondPassword = secondPassword;
            AdditionalDescription = additionalDescription;
        }
    }
}
