using Gaten.Net.Diagnostics;

using System;
using System.Reflection;

namespace Gaten.Windows.MintPanda.Contents
{
    internal class Clock
    {
        public static string Get()
        {
            try
            {
                return $"{DateTime.Now:yyyy'년' MMM d'일' dddd tt hh:mm:ss}";
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Clock), MethodBase.GetCurrentMethod()?.Name, ex);
            }

            return $"{DateTime.Now:yyyy'년' MMM d'일' dddd tt hh:mm:ss}";
        }
    }
}
