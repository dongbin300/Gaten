using Gaten.Net.Diagnostics;

using System;
using System.Reflection;
using System.Windows;

namespace Gaten.Windows.MintPanda.Contents
{
    /// <summary>
    /// ColorPick.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ColorPick : Window
    {
        public ColorPick()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                GLogger.Log(nameof(ColorPick), MethodBase.GetCurrentMethod()?.Name, ex);
            }
        }
    }
}
