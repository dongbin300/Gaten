namespace Gaten.Windows.MintPandaConsole.Models
{
    internal class WeatherModel
    {
        public string Temperature { get; set; }
        public string Weather { get; set; }
        public string Mise { get; set; }
        public string Chomise { get; set; }

        public WeatherModel(string temperature, string weather, string mise, string chomise)
        {
            Temperature = temperature;
            Weather = weather;
            Mise = mise;
            Chomise = chomise;
        }
    }
}
