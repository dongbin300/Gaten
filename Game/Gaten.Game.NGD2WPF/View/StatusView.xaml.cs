using Gaten.Net.GameRule.NGD2;

using System.Windows.Controls;

namespace Gaten.Game.NGD2WPF.View
{
    /// <summary>
    /// StatusView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatusView : UserControl
    {
        public StatusView()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            PowerText.Text = "" + Character.Effect.PowerSum;
            AttackSpeedText.Text = "" + Character.Effect.AttackSpeed + "(" + Character.Effect.AttackSpeedIM + "ms)";
            CriticalRateText.Text = Character.Effect.CriticalRateIM + "%";
            CriticalDamageText.Text = Character.Effect.CriticalDamageMultiple + "%";
            MpMaxText.Text = "" + Character.Effect.MpMax;
            MpRegenText.Text = "" + Character.Effect.MpRegen;
            SpiritDropRateText.Text = Character.Effect.SpiritDropRateIM + "%";
            SpiritDropText.Text = "" + Character.Effect.SpiritDrop;
            SkillCardDropRateText.Text = Character.Effect.SkillCardDropRateIM + "%";
        }
    }
}
