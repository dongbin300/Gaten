using Gaten.Net.Windows;
using Gaten.Net.Windows.Forms;

namespace Gaten.Game.Dung_Eo_Ri
{
    public partial class MainForm : Form
    {
        UserActivityHook hook;
        Thread thread;
        GameRule.Game game = new GameRule.Game();
        Random r = new Random();
        int runAwayTryCount;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            hook = new UserActivityHook();
            thread = new Thread(new ThreadStart(Key));
            thread.Start();

            SceneControl.SelectedIndex = 1;
        }

        bool IsActive(IntPtr handle)
        {
            IntPtr activeHandle = WinAPI.GetForegroundWindow();
            return activeHandle == handle;
        }

        void Key()
        {
            hook.KeyUp += (sender, e) =>
            {
                if (IsActive(Handle))
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Escape:
                            switch (SceneControl.SelectedIndex)
                            {
                                case 2:
                                    SceneControl.SelectedIndex = 1;
                                    break;

                                default:
                                    break;
                            }
                            break;
                    }
                }
            };
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            SceneControl.SelectedIndex = 2;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("���� ����� �����Ͻðڽ��ϱ�?", "���", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DungeonListBox_DoubleClick(object sender, EventArgs e)
        {
            SceneControl.SelectedIndex = 3;
        }

        private void SceneControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SceneControl.SelectedIndex)
            {
                case 0: // ���� scene
                    LogListBox.Items.Clear();
                    runAwayTryCount = 0;

                    PlayerImage.Image = game.Player.Picture;
                    PlayerStats.Items.Clear();
                    PlayerStats.Items.Add("[" + game.Player.Name + "]");
                    PlayerStats.Items.Add("����: " + game.Player.Level);
                    PlayerStats.Items.Add("HP: " + game.Player.CurrentHitPoints);
                    PlayerStats.Items.Add("������: " + game.Player.BaseDamage);

                    int dungeonLevel = 1;
                    int newMobLevel = game.Player.CurrentDungeon.GetNewMobLevel(dungeonLevel);
                    var newMobProto = game.Mobs[newMobLevel][r.Next(0, game.Mobs[newMobLevel].Count)];
                    var newMob = new GameRule.Mob(newMobProto.Name, newMobProto.Picture, newMobProto.Level, newMobProto.BaseHitPoints, newMobProto.BaseDamage, newMobProto.Equips);
                    MobImage.Image = newMob.Picture;
                    MobStats.Items.Clear();
                    MobStats.Items.Add("[" + newMob.Name + "]");
                    MobStats.Items.Add("����: " + newMob.Level);
                    MobStats.Items.Add("HP: " + newMob.CurrentHitPoints);
                    MobStats.Items.Add("������: " + newMob.BaseDamage);

                    game.Player.CurrentDungeon.CurrentMob = newMob;
                    break;

                case 1: // ���� scene
                    break;

                case 2: // Select Dungeon scene
                    DungeonListBox.Items.Clear();
                    foreach (var dungeon in game.Dungeons)
                    {
                        DungeonListBox.Items.Add(dungeon.Key);
                    }

                    game.Player.RestoreAllHitPoints();

                    PlayerNameText.Text = "�̸�: " + game.Player.Name;
                    PlayerLevelText.Text = "����: " + game.Player.Level;
                    PlayerHitPointsText.Text = "HP: " + game.Player.GetMaxHitPoints();
                    break;

                case 3: // Dungeon scene
                    game.Player.EnterDungeon(game.Dungeons[DungeonListBox.SelectedItem.ToString()]);
                    RefreshDungeonStatus();
                    break;
            }
        }

        private void GiveUpButton_Click(object sender, EventArgs e)
        {
            SceneControl.SelectedIndex = 2;
            game.Player.GiveUpDungeon();
        }

        void CheckAvailableDirections()
        {
            UpButton.Enabled = game.Player.CanGoUp();
            DownButton.Enabled = game.Player.CanGoDown();
            LeftButton.Enabled = game.Player.CanGoLeft();
            RightButton.Enabled = game.Player.CanGoRight();
        }

        void RefreshDungeonStatus()
        {
            CheckAvailableDirections();

            PlayerInfo.Items.Clear();
            PlayerInfo.Items.Add("- ���� ����");
            PlayerInfo.Items.Add("�̸�: " + game.Player.Name);
            PlayerInfo.Items.Add("����: " + game.Player.Level);
            PlayerInfo.Items.Add("HP: " + game.Player.CurrentHitPoints + "/" + game.Player.GetMaxHitPoints());
            PlayerInfo.Items.Add("EXP: " + game.Player.CurrentExp);

            DungeonInfo.Items.Clear();
            DungeonInfo.Items.Add("- ���� ����");
            DungeonInfo.Items.Add("�̸�: " + game.Player.CurrentDungeon.Name);
            DungeonInfo.Items.Add("����: " + game.Player.CurrentDungeonLevel);
#if DEBUG
            DungeonInfo.Items.Add("��ǥ: (" + game.Player.CurrentCoordX + ", " + game.Player.CurrentCoordY + ")");
#endif
        }

        void RefreshBattleStatus()
        {

        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            game.Player.MoveUp();
            RefreshDungeonStatus();

            if (IsMobThere())
            {
                StartBattle();
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            game.Player.MoveDown();
            RefreshDungeonStatus();

            if (IsMobThere())
            {
                StartBattle();
            }
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            game.Player.MoveLeft();
            RefreshDungeonStatus();

            if (IsMobThere())
            {
                StartBattle();
            }
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            game.Player.MoveRight();
            RefreshDungeonStatus();

            if (IsMobThere())
            {
                StartBattle();
            }
        }

        private bool IsMobThere()
        {
            return r.Next(5) <= 1; // Ȯ�� : 2/5
        }

        private void StartBattle()
        {
            SceneControl.SelectedIndex = 0;
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            bool isMobDefeated = AttackMob();
            if (isMobDefeated) return;

            bool isUserDefeated = AttackUser();
            if (isUserDefeated) return;

            RefreshBattleStatus();
        }

        private bool CheckAndProcessGameFinish(int userHitPoints, int mobHitPoints)
        {
            if (userHitPoints == 0)
            {
                MessageBox.Show("�������� �й��Ͽ���! ���� ���� ����... ��� �Ф�", "���� �й�");
                SceneControl.SelectedIndex = 2;
            }
            else if (mobHitPoints == 0)
            {
                MessageBox.Show("�������� �¸��Ͽ���!", "���� �¸�");
                SceneControl.SelectedIndex = 3;
                return true;
            }

            return false;
        }

        private void RunAwayButton_Click(object sender, EventArgs e)
        {
            int maxRate = 80;
            int rate;
            int baseValue = (game.Player.CurrentDungeon.CurrentMob.Level - game.Player.Level) + 2;
            if (baseValue <= 0) rate = 0;
            else rate = Math.Min(baseValue * 5, maxRate);

            if (r.Next(0, 100) < rate)
            {
                SceneControl.SelectedIndex = 3;
            }
            else
            {
                LogListBox.Items.Add("������⿡ �����ߴ�! (�õ� Ƚ��: " + ++runAwayTryCount + ")");

                bool isUserDefeated = AttackUser();
                if (isUserDefeated) return;

                RefreshBattleStatus();
            }
        }

        private bool AttackMob()
        {
            Dictionary<string, int> attackResult = game.Player.Attack(game.Player.CurrentDungeon.CurrentMob);
            string mobName = game.Player.CurrentDungeon.CurrentMob.Name;
            int userFinalDamage = attackResult["myFinalDamage"];
            int mobHitPoints = attackResult["finalTargetHitPoints"];
            int userHitPoints = attackResult["myHitPoints"];

            LogListBox.Items.Add(mobName + "��(��) " + userFinalDamage + "��ŭ ���ȭ (�� HP: " + userHitPoints + ", �� HP: " + mobHitPoints + ")");

            return CheckAndProcessGameFinish(userHitPoints, mobHitPoints);
        }

        private bool AttackUser()
        {
            Dictionary<string, int> getHitResult = game.Player.CurrentDungeon.CurrentMob.Attack(game.Player);
            string mobName = game.Player.CurrentDungeon.CurrentMob.Name;
            int mobFinalDamage = getHitResult["myFinalDamage"];
            int userHitPoints = getHitResult["finalTargetHitPoints"];
            int mobHitPoints = getHitResult["myHitPoints"];

            LogListBox.Items.Add(mobName + "���� " + mobFinalDamage + "��ŭ ���ȭ (�� HP: " + userHitPoints + ", �� HP: " + mobHitPoints + ")");

            return CheckAndProcessGameFinish(userHitPoints, mobHitPoints);
        }
    }
}