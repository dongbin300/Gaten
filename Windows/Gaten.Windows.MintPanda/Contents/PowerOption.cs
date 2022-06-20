namespace Gaten.Windows.MintPanda.Contents
{
    public enum PowerType
    {
        Balance,
        Save
    }

    internal class PowerOption
    {
        public static PowerScheme? Get()
        {
            PowerScheme? powerScheme = null;
            var activeScheme = Net.Windows.Cmd.Run("powercfg /getactivescheme");

            var guid = activeScheme.Split(':', '(')[1].Trim();

            if (activeScheme.Contains("균형 조정"))
            {
                powerScheme = new PowerScheme(PowerType.Balance, guid);
            }
            else if (activeScheme.Contains("절전"))
            {
                powerScheme = new PowerScheme(PowerType.Save, guid);
            }

            return powerScheme;
        }
    }

    internal record PowerScheme(PowerType Type, string Guid);
}
