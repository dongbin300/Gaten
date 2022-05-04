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
            if (MessageBox.Show("정말 덩어리를 포기하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                case 0: // 전투 scene
                    LogListBox.Items.Clear();
                    runAwayTryCount = 0;

                    PlayerImage.Image = game.Player.Picture;
                    PlayerStats.Items.Clear();
                    PlayerStats.Items.Add("[" + game.Player.Name + "]");
                    PlayerStats.Items.Add("레벨: " + game.Player.Level);
                    PlayerStats.Items.Add("HP: " + game.Player.CurrentHitPoints);
                    PlayerStats.Items.Add("데미지: " + game.Player.BaseDamage);

                    int dungeonLevel = 1;
                    int newMobLevel = game.Player.CurrentDungeon.GetNewMobLevel(dungeonLevel);
                    var newMobProto = game.Mobs[newMobLevel][r.Next(0, game.Mobs[newMobLevel].Count)];
                    var newMob = new GameRule.Mob(newMobProto.Name, newMobProto.Picture, newMobProto.Level, newMobProto.BaseHitPoints, newMobProto.BaseDamage, newMobProto.Equips);
                    MobImage.Image = newMob.Picture;
                    MobStats.Items.Clear();
                    MobStats.Items.Add("[" + newMob.Name + "]");
                    MobStats.Items.Add("레벨: " + newMob.Level);
                    MobStats.Items.Add("HP: " + newMob.CurrentHitPoints);
                    MobStats.Items.Add("데미지: " + newMob.BaseDamage);

                    game.Player.CurrentDungeon.CurrentMob = newMob;
                    break;

                case 1: // 메인 scene
                    break;

                case 2: // Select Dungeon scene
                    DungeonListBox.Items.Clear();
                    foreach (var dungeon in game.Dungeons)
                    {
                        DungeonListBox.Items.Add(dungeon.Key);
                    }

                    game.Player.RestoreAllHitPoints();

                    PlayerNameText.Text = "이름: " + game.Player.Name;
                    PlayerLevelText.Text = "레벨: " + game.Player.Level;
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
            PlayerInfo.Items.Add("- 유저 정보");
            PlayerInfo.Items.Add("이름: " + game.Player.Name);
            PlayerInfo.Items.Add("레벨: " + game.Player.Level);
            PlayerInfo.Items.Add("HP: " + game.Player.CurrentHitPoints + "/" + game.Player.GetMaxHitPoints());
            PlayerInfo.Items.Add("EXP: " + game.Player.CurrentExp);

            DungeonInfo.Items.Clear();
            DungeonInfo.Items.Add("- 던전 정보");
            DungeonInfo.Items.Add("이름: " + game.Player.CurrentDungeon.Name);
            DungeonInfo.Items.Add("레벨: " + game.Player.CurrentDungeonLevel);
#if DEBUG
            DungeonInfo.Items.Add("좌표: (" + game.Player.CurrentCoordX + ", " + game.Player.CurrentCoordY + ")");
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
            return r.Next(5) <= 1; // 확률 : 2/5
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
                MessageBox.Show("전투에서 패배하였다! 던전 공략 실패... 덩어리 ㅠㅠ", "전투 패배");
                SceneControl.SelectedIndex = 2;
            }
            else if (mobHitPoints == 0)
            {
                MessageBox.Show("전투에서 승리하였다!", "전투 승리");
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
                LogListBox.Items.Add("도망허기에 실패했다! (시도 횟수: " + ++runAwayTryCount + ")");

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

            LogListBox.Items.Add(mobName + "을(를) " + userFinalDamage + "만큼 덩어리화 (내 HP: " + userHitPoints + ", 몹 HP: " + mobHitPoints + ")");

            return CheckAndProcessGameFinish(userHitPoints, mobHitPoints);
        }

        private bool AttackUser()
        {
            Dictionary<string, int> getHitResult = game.Player.CurrentDungeon.CurrentMob.Attack(game.Player);
            string mobName = game.Player.CurrentDungeon.CurrentMob.Name;
            int mobFinalDamage = getHitResult["myFinalDamage"];
            int userHitPoints = getHitResult["finalTargetHitPoints"];
            int mobHitPoints = getHitResult["myHitPoints"];

            LogListBox.Items.Add(mobName + "에게 " + mobFinalDamage + "만큼 덩어리화 (내 HP: " + userHitPoints + ", 몹 HP: " + mobHitPoints + ")");

            return CheckAndProcessGameFinish(userHitPoints, mobHitPoints);
        }
    }
}