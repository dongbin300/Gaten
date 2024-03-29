﻿using Gaten.Net.Diagnostics;
using Gaten.Net.Network;

using System;
using System.Reflection;

namespace Gaten.Windows.MintPanda.Contents
{
    internal class Unse
    {
        public static string Get()
        {
            try
            {
                WebCrawler.SetUrl($"https://www.ytn.co.kr/_ln/0121_{DateTime.Now:yyyyMMdd}0000000001");

                string[] splitSource = WebCrawler.Source.Substring(WebCrawler.Source.IndexOf("[개띠]"), 500).Split(new string[] { "<br />" }, StringSplitOptions.RemoveEmptyEntries);

                var allDog = splitSource[1].Replace("\r\n", "").Replace("\n", "");
                var dog94 = splitSource[6].Replace("1994년생, ", "").Replace("\r\n", "").Replace("\n", "");

                return allDog + Environment.NewLine + dog94;
            }
            catch(Exception ex)
            {
                GLogger.Log(nameof(Unse), MethodBase.GetCurrentMethod()?.Name, ex);
                return "Error";
            }
        }
    }
}
