using System;

namespace Gaten.Windows.MintPanda.Contents
{
    internal class Clock
    {
        public static string Get()
        {
            return $"{DateTime.Now:yyyy'년' MMM d'일' dddd tt hh:mm:ss}";
        }
    }
}
