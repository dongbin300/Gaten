using Gaten.Net.Windows;

using System;
using System.Linq;

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
            var activeScheme = Cmd.Run("powercfg /getactivescheme");

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

        public static void Switch()
        {
            var powerScheme = Get();
            var powerSchemeInfo = Cmd.Run("powercfg /l");

            switch (powerScheme?.Type)
            {
                case PowerType.Balance:
                    string? guid = powerSchemeInfo.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList().Find(s => s.Contains("절전"))?.Split(':', '(')[1].Trim();

                    Cmd.Run($"powercfg /s {guid}");
                    break;

                case PowerType.Save:
                    string? guid2 = powerSchemeInfo.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList().Find(s => s.Contains("균형 조정"))?.Split(':', '(')[1].Trim();

                    Cmd.Run($"powercfg /s {guid2}");
                    break;
            }
        }
    }

    internal record PowerScheme(PowerType Type, string Guid);
}
