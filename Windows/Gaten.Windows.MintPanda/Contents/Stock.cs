using Gaten.Net.Diagnostics;
using Gaten.Net.Network;

using System;
using System.Reflection;

namespace Gaten.Windows.MintPanda.Contents
{
    internal class Stock
    {
        public static string Get()
        {
            try
            {
                return string.Empty;
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(Stock), MethodBase.GetCurrentMethod()?.Name, ex);
            }

            return string.Empty;
        }
    }
}
