using Gaten.Net.GameRule.Saki.Skill;

namespace Gaten.GameTool.Saki.SkillCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SkillManager.Initialize();

            for (int i = 0; i <= 4; i++)
            {
                string str = i == 0 ? "명함" : i + "각";
                CCAcomboBox.Items.Add(str);
                DBAcomboBox.Items.Add(str);
                SuggestionCCAcomboBox.Items.Add(str);
                SuggestionDBAcomboBox.Items.Add(str);
            }

            for (int i = 0; i <= 15; i++)
            {
                string str = i + "해방";
                CCRcomboBox.Items.Add(str);
                DBRcomboBox.Items.Add(str);
                SuggestionCCRcomboBox.Items.Add(str);
                SuggestionDBRcomboBox.Items.Add(str);
            }

            CCAcomboBox.SelectedIndex = 0;
            CCRcomboBox.SelectedIndex = 0;
            DBAcomboBox.SelectedIndex = 0;
            DBRcomboBox.SelectedIndex = 0;
            SuggestionCCAcomboBox.SelectedIndex = 0;
            SuggestionCCRcomboBox.SelectedIndex = 0;
            SuggestionDBAcomboBox.SelectedIndex = 0;
            SuggestionDBRcomboBox.SelectedIndex = 0;
        }

        static int CalculatePower(int celestialContractAwakeningLevel, int celestialContractReleaseLevel, int darkHolyBoomAwakeningLevel, int darkHolyBoomReleaseLevel)
        {
            var dbPower = DarkHolyBoom.GetPower(darkHolyBoomAwakeningLevel, darkHolyBoomReleaseLevel);
            var ccPower = CelestialContract.GetPower(celestialContractAwakeningLevel, celestialContractReleaseLevel);

            var power = (int)Math.Round(dbPower * (1 + ccPower / 100.0), 0);

            return power;
        }

        static int CalculateEfficiency(int celestialContractAwakeningLevel, int celestialContractReleaseLevel, int darkHolyBoomAwakeningLevel, int darkHolyBoomReleaseLevel, int changedIndex)
        {
            //var prePower = CalculatePower(celestialContractAwakeningLevel, celestialContractReleaseLevel, darkHolyBoomAwakeningLevel, darkHolyBoomReleaseLevel);

            if (
                changedIndex == 0 && celestialContractAwakeningLevel >= CelestialContract.Awakening.Max ||
                changedIndex == 1 && celestialContractReleaseLevel >= CelestialContract.Release.Max ||
                changedIndex == 2 && darkHolyBoomAwakeningLevel >= DarkHolyBoom.Awakening.Max ||
                changedIndex == 3 && darkHolyBoomReleaseLevel >= DarkHolyBoom.Release.Max)
            {
                return 0;
            }

            var efficiency = changedIndex switch
            {
                0 => CalculatePower(celestialContractAwakeningLevel + CelestialContract.Awakening.Benchmark, celestialContractReleaseLevel, darkHolyBoomAwakeningLevel, darkHolyBoomReleaseLevel),
                1 => CalculatePower(celestialContractAwakeningLevel, celestialContractReleaseLevel + CelestialContract.Release.Benchmark, darkHolyBoomAwakeningLevel, darkHolyBoomReleaseLevel),
                2 => CalculatePower(celestialContractAwakeningLevel, celestialContractReleaseLevel, darkHolyBoomAwakeningLevel + DarkHolyBoom.Awakening.Benchmark, darkHolyBoomReleaseLevel),
                3 => CalculatePower(celestialContractAwakeningLevel, celestialContractReleaseLevel, darkHolyBoomAwakeningLevel, darkHolyBoomReleaseLevel + DarkHolyBoom.Release.Benchmark),
                _ => 0
            };

            //var efficiency = changedIndex switch
            //{
            //    0 => ((double)CalculatePower(celestialContractAwakeningLevel + 1, celestialContractReleaseLevel, darkHolyBoomAwakeningLevel, darkHolyBoomReleaseLevel) / prePower - 1) / CelestialContract.Awakening.Cost,
            //    1 => ((double)CalculatePower(celestialContractAwakeningLevel, celestialContractReleaseLevel + 1, darkHolyBoomAwakeningLevel, darkHolyBoomReleaseLevel) / prePower - 1) / CelestialContract.Release.Cost,
            //    2 => ((double)CalculatePower(celestialContractAwakeningLevel, celestialContractReleaseLevel, darkHolyBoomAwakeningLevel + 1, darkHolyBoomReleaseLevel) / prePower - 1) / DarkHolyBoom.Awakening.Cost,
            //    3 => ((double)CalculatePower(celestialContractAwakeningLevel, celestialContractReleaseLevel, darkHolyBoomAwakeningLevel, darkHolyBoomReleaseLevel + 1) / prePower - 1) / DarkHolyBoom.Release.Cost,
            //    _ => 0
            //};

            return efficiency;
        }

        private void PowerCalButton_Click(object sender, EventArgs e)
        {
            var power = CalculatePower(CCAcomboBox.SelectedIndex, CCRcomboBox.SelectedIndex, DBAcomboBox.SelectedIndex, DBRcomboBox.SelectedIndex);

            SkillDamageTextBox.Text = power.ToString();
        }

        private void SuggestionSkillButton_Click(object sender, EventArgs e)
        {
            List<int> levels = new();
            levels.Add(SuggestionCCAcomboBox.SelectedIndex);
            levels.Add(SuggestionCCRcomboBox.SelectedIndex);
            levels.Add(SuggestionDBAcomboBox.SelectedIndex);
            levels.Add(SuggestionDBRcomboBox.SelectedIndex);

            List<int> efficiencies = new();
            for (int i = 0; i < levels.Count; i++)
            {
                var efficiency = CalculateEfficiency(levels[0], levels[1], levels[2], levels[3], i);
                efficiencies.Add(efficiency);
            }

            var suggestionIndex = efficiencies.IndexOf(efficiencies.Max());

            SuggestionTextBox.Text = suggestionIndex switch
            {
                0 => CelestialContract.ToString(levels[0] + 1, levels[1]),
                1 => CelestialContract.ToString(levels[0], levels[1] + 1),
                2 => DarkHolyBoom.ToString(levels[2] + 1, levels[3]),
                3 => DarkHolyBoom.ToString(levels[2], levels[3] + 1),
                _ => "오류"
            };
        }

        static string GetSuggestionSkillTreeString()
        {
            string treeString = string.Empty;
            List<int> levels = new()
            {
                0,0,4,0
            };

            List<double> efficiencies = new();
            while (
                levels[0] < CelestialContract.Awakening.Max ||
                levels[1] < CelestialContract.Release.Max ||
                levels[2] < DarkHolyBoom.Awakening.Max ||
                levels[3] < DarkHolyBoom.Release.Max)
            {
                efficiencies.Clear();

                for (int i = 0; i < levels.Count; i++)
                {
                    var efficiency = CalculateEfficiency(levels[0], levels[1], levels[2], levels[3], i);
                    efficiencies.Add(efficiency);
                }

                var suggestionIndex = efficiencies.IndexOf(efficiencies.Max());

                treeString += suggestionIndex switch
                {
                    0 => CelestialContract.ToString(++levels[0], levels[1]),
                    1 => CelestialContract.ToString(levels[0], ++levels[1]),
                    2 => DarkHolyBoom.ToString(++levels[2], levels[3]),
                    3 => DarkHolyBoom.ToString(levels[2], ++levels[3]),
                    _ => "오류"
                };
                treeString += "\r\n";
            }

            return treeString;
        }

        private void SuggestionSkillTreeCalButton_Click(object sender, EventArgs e)
        {
            SuggestionSkillTreeTextBox.Text = GetSuggestionSkillTreeString();
        }
    }
}