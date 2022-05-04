using Gaten.Net.GameRule.NGD2.AbilitySystem;
using Gaten.Net.GameRule.NGD2.UISystem;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gaten.Game.NGD2WPF.View
{
    /// <summary>
    /// SpiritView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SpiritView : UserControl
    {
        public SpiritView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        void Refresh()
        {
            PowerTitle.Text = $"Lv {Spirit.Power.Level}";
            PowerText.Text = $"+{Spirit.Power.TotalValue}";
            PowerSpiritText.Text = Spirit.Power.TotalPrice.ToString();

            MpMaxTitle.Text = $"Lv {Spirit.MpMax.Level}";
            MpMaxText.Text = $"+{Spirit.MpMax.TotalValue}";
            MpMaxSpiritText.Text = Spirit.MpMax.TotalPrice.ToString();

            MpRegenTitle.Text = $"Lv {Spirit.MpRegen.Level}";
            MpRegenText.Text = $"+{Spirit.MpRegen.TotalValue}";
            MpRegenSpiritText.Text = Spirit.MpRegen.TotalPrice.ToString();

            CriticalRateTitle.Text = $"Lv {Spirit.CriticalRate.Level}";
            CriticalRateText.Text = $"+{Spirit.CriticalRate.TotalValue / 100}%";
            CriticalRateSpiritText.Text = Spirit.CriticalRate.TotalPrice.ToString();

            CriticalDamageTitle.Text = $"Lv {Spirit.CriticalDamage.Level}";
            CriticalDamageText.Text = $"+{Spirit.CriticalDamage.TotalValue}%";
            CriticalDamageSpiritText.Text = Spirit.CriticalDamage.TotalPrice.ToString();
        }

        private void PowerBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Spirit.Power.Level >= Spirit.Power.MaxLevel)
            {
                LogQueue.Set("마스터 레벨입니다.");
                return;
            }

            if (Spirit.Value < Spirit.Power.TotalPrice)
            {
                LogQueue.Set("근성의 징표가 부족합니다.");
                return;
            }

            Spirit.Value -= Spirit.Power.TotalPrice;
            Spirit.Power.Level++;
            LogQueue.Set($"{Spirit.Power.Name} Lv {Spirit.Power.Level - 1} -> Lv {Spirit.Power.Level}");
            Refresh();
        }

        private void MpMaxBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Spirit.MpMax.Level >= Spirit.MpMax.MaxLevel)
            {
                LogQueue.Set("마스터 레벨입니다.");
                return;
            }

            if (Spirit.Value < Spirit.MpMax.TotalPrice)
            {
                LogQueue.Set("근성의 징표가 부족합니다.");
                return;
            }

            Spirit.Value -= Spirit.MpMax.TotalPrice;
            Spirit.MpMax.Level++;
            LogQueue.Set($"{Spirit.MpMax.Name} Lv {Spirit.MpMax.Level - 1} -> Lv {Spirit.MpMax.Level}");
            Refresh();
        }

        private void MpRegenBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Spirit.MpRegen.Level >= Spirit.MpRegen.MaxLevel)
            {
                LogQueue.Set("마스터 레벨입니다.");
                return;
            }

            if (Spirit.Value < Spirit.MpRegen.TotalPrice)
            {
                LogQueue.Set("근성의 징표가 부족합니다.");
                return;
            }

            Spirit.Value -= Spirit.MpRegen.TotalPrice;
            Spirit.MpRegen.Level++;
            LogQueue.Set($"{Spirit.MpRegen.Name} Lv {Spirit.MpRegen.Level - 1} -> Lv {Spirit.MpRegen.Level}");
            Refresh();
        }

        private void CriticalRateBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Spirit.CriticalRate.Level >= Spirit.CriticalRate.MaxLevel)
            {
                LogQueue.Set("마스터 레벨입니다.");
                return;
            }

            if (Spirit.Value < Spirit.CriticalRate.TotalPrice)
            {
                LogQueue.Set("근성의 징표가 부족합니다.");
                return;
            }

            Spirit.Value -= Spirit.CriticalRate.TotalPrice;
            Spirit.CriticalRate.Level++;
            LogQueue.Set($"{Spirit.CriticalRate.Name} Lv {Spirit.CriticalRate.Level - 1} -> Lv {Spirit.CriticalRate.Level}");
            Refresh();
        }

        private void CriticalDamageBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Spirit.CriticalDamage.Level >= Spirit.CriticalDamage.MaxLevel)
            {
                LogQueue.Set("마스터 레벨입니다.");
                return;
            }

            if (Spirit.Value < Spirit.CriticalDamage.TotalPrice)
            {
                LogQueue.Set("근성의 징표가 부족합니다.");
                return;
            }

            Spirit.Value -= Spirit.CriticalDamage.TotalPrice;
            Spirit.CriticalDamage.Level++;
            LogQueue.Set($"{Spirit.CriticalDamage.Name} Lv {Spirit.CriticalDamage.Level - 1} -> Lv {Spirit.CriticalDamage.Level}");
            Refresh();
        }
    }
}
