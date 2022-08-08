using Gaten.Net.Windows;
using Gaten.Net.Windows.Forms;

namespace Gaten.Game.Dung_Eo_Ri
{
    public partial class MainForm : Form
    {
        private UserActivityHook hook;
        private Thread thread;
        private readonly GameRule.Game game = new();
        private readonly Random r = new();
        private int runAwayTryCount;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            hook = new UserActivityHook();
            thread = new Thread(new ThreadStart(Key));
            thread.Start();

            ChangeSceneTo(GameRule.Game.Scene.Main);
        }

        private bool IsActive(IntPtr handle)
        {
            IntPtr activeHandle = WinApi.GetForegroundWindow();
            return activeHandle == handle;
        }

        private void Key()
        {
            hook.KeyUp += (sender, e) =>
            {
                if (IsActive(Handle))
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Escape:
                            switch (GetCurrentScene())
                            {
                                case GameRule.Game.Scene.DungeonSelection:
                                    ChangeSceneTo(GameRule.Game.Scene.Main);
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
            ChangeSceneTo(GameRule.Game.Scene.DungeonSelection);
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
            if (DungeonListBox.SelectedItem == null)
            {
                return;
            }

            ChangeSceneTo(GameRule.Game.Scene.InDungeon);
        }

        private void SceneControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (GetCurrentScene())
            {
                case GameRule.Game.Scene.Battle:
                    PlayerStats.Items.Clear();
                    PlayerImage.Image = null;
                    MobStats.Items.Clear();
                    MobImage.Image = null;
                    LogListBox.Items.Clear();
                    runAwayTryCount = 0;

                    PlayerImage.Image = game.Player.Picture;
                    _ = PlayerStats.Items.Add("[" + game.Player.Name + "]");
                    _ = PlayerStats.Items.Add("����: " + game.Player.Level);
                    _ = PlayerStats.Items.Add("HP: " + game.Player.CurrentHitPoints);
                    _ = PlayerStats.Items.Add("������: " + game.Player.BaseDamage);

                    int dungeonLevel = game.Player.CurrentDungeonLevel;
                    GameRule.Mob newMob;
                    if (IsBossFloor())
                    {
                        newMob = game.Player.CurrentDungeon.BossMob;
                        _ = MessageBox.Show($"������ {newMob.Name}�� �������ϴ�!");
                    }
                    else
                    {
                        int newMobLevel = game.Player.CurrentDungeon.GetNewMobLevel(dungeonLevel);
                        GameRule.Mob? newMobProto = game.Mobs[newMobLevel][r.Next(0, game.Mobs[newMobLevel].Count)];
                        newMob = new GameRule.Mob(newMobProto.Name, newMobProto.Picture, newMobProto.Level, newMobProto.BaseHitPoints, newMobProto.BaseDamage, newMobProto.Equips);
                    }

                    MobImage.Image = newMob.Picture;
                    _ = MobStats.Items.Add("[" + newMob.Name + "]");
                    _ = MobStats.Items.Add("����: " + newMob.Level);
                    _ = MobStats.Items.Add("HP: " + newMob.CurrentHitPoints);
                    _ = MobStats.Items.Add("������: " + newMob.BaseDamage);
                    _ = MobStats.Items.Add("����ġ: " + newMob.RewardExp);

                    game.Player.CurrentDungeon.CurrentMob = newMob;
                    break;

                case GameRule.Game.Scene.Main:
                    break;

                case GameRule.Game.Scene.DungeonSelection:
                    DungeonListBox.Items.Clear();
                    foreach (KeyValuePair<string, GameRule.Dungeon> dungeon in game.Dungeons)
                    {
                        _ = DungeonListBox.Items.Add(dungeon.Key);
                    }

                    game.Player.RestoreAllHitPoints();

                    PlayerNameText.Text = "�̸�: " + game.Player.Name;
                    PlayerLevelText.Text = "����: " + game.Player.Level;
                    PlayerHitPointsText.Text = "HP: " + game.Player.GetMaxHitPoints();

                    game.Player.CurrentDungeon = null;
                    break;

                case GameRule.Game.Scene.InDungeon:
                    if (DungeonListBox.SelectedItem == null)
                    {
                        break;
                    }

                    string dungeonName = DungeonListBox.SelectedItem.ToString();

                    if (game.Player.CurrentDungeon == null)
                    {
                        game.Player.EnterDungeon(game.Dungeons[dungeonName]);
                    }
                    RefreshDungeonStatus();
                    break;
            }
        }

        private void GiveUpButton_Click(object sender, EventArgs e)
        {
            game.Player.GiveUpDungeon();
            ChangeSceneTo(GameRule.Game.Scene.DungeonSelection);
        }

        private void CheckAvailableDirections()
        {
            UpButton.Enabled = game.Player.CanGoUp();
            DownButton.Enabled = game.Player.CanGoDown();
            LeftButton.Enabled = game.Player.CanGoLeft();
            RightButton.Enabled = game.Player.CanGoRight();
        }

        private void RefreshDungeonStatus()
        {
            CheckAvailableDirections();

            PlayerInfo.Items.Clear();
            PlayerInfo.Items.Add("- ���� ����");
            PlayerInfo.Items.Add("�̸�: " + game.Player.Name);
            PlayerInfo.Items.Add("����: " + game.Player.Level);
            PlayerInfo.Items.Add("HP: " + game.Player.CurrentHitPoints + "/" + game.Player.GetMaxHitPoints());
            PlayerInfo.Items.Add("����ġ: " + game.Player.CurrentExp + "/" + game.Player.GetLevelUpExp());

            DungeonInfo.Items.Clear();
            DungeonInfo.Items.Add("- ���� ����");
            DungeonInfo.Items.Add("�̸�: " + game.Player.CurrentDungeon.Name);
            DungeonInfo.Items.Add("����: " + game.Player.CurrentDungeonLevel);
#if DEBUG
            DungeonInfo.Items.Add("��ǥ: (" + game.Player.CurrentCoordX + ", " + game.Player.CurrentCoordY + ")");
#endif

            DescendButton.Visible =
                game.Player.CurrentDungeon.DungeonLevels[game.Player.CurrentDungeonLevel - 1].StairX == game.Player.CurrentCoordX &&
                game.Player.CurrentDungeon.DungeonLevels[game.Player.CurrentDungeonLevel - 1].StairY == game.Player.CurrentCoordY;

        }

        private void RefreshBattleStatus()
        {
            LogListBox.TopIndex = LogListBox.Items.Count - 1;
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            game.Player.MoveUp();
            RefreshDungeonStatus();
            ProcessBattle();
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            game.Player.MoveDown();
            RefreshDungeonStatus();
            ProcessBattle();
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            game.Player.MoveLeft();
            RefreshDungeonStatus();
            ProcessBattle();
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            game.Player.MoveRight();
            RefreshDungeonStatus();
            ProcessBattle();
        }

        private void ProcessBattle()
        {
            if (IsBossFloor() || IsMobThere())
            {
                StartBattle();
            }
        }

        private bool IsBossFloor()
        {
            // ���� �� == �ش� ������ ������
            return game.Player.CurrentDungeonLevel == game.Player.CurrentDungeon.DungeonLevels.Count;
        }

        private bool IsMobThere()
        {
            return r.Next(5) <= 1; // Ȯ�� : 2/5
        }

        private void StartBattle()
        {
            ChangeSceneTo(GameRule.Game.Scene.Battle);
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            bool isMobDefeated = AttackMob();
            if (isMobDefeated)
            {
                return;
            }

            bool isUserDefeated = AttackUser();
            if (isUserDefeated)
            {
                return;
            }

            RefreshBattleStatus();
        }

        private bool CheckAndProcessGameFinish(int userHitPoints, int mobHitPoints)
        {
            if (userHitPoints == 0)
            {
                _ = MessageBox.Show("�������� �й��Ͽ���! ���� ���� ����... ��� �Ф�", "���� �й�");
                game.Player.ApplyEndGameDefeatStatus();
                ChangeSceneTo(GameRule.Game.Scene.DungeonSelection);
            }
            else if (mobHitPoints == 0)
            {
                _ = MessageBox.Show("�������� �¸��Ͽ���!", "���� �¸�");
                game.Player.CurrentExp += game.Player.CurrentDungeon.CurrentMob.RewardExp;
                game.Player.CurrentDungeon.AccumulatedRewardExp += game.Player.CurrentDungeon.CurrentMob.RewardExp;

                if (game.Player.CurrentDungeon.CurrentMob == game.Player.CurrentDungeon.BossMob)
                {
                    int accumulatedRewardExp = game.Player.CurrentDungeon.AccumulatedRewardExp;
                    int previousLevel = game.Player.Level;
                    game.Player.ApplyEndGameVictoryStatus();
                    int currentLevel = game.Player.Level;
                    _ = MessageBox.Show($"������ ��ҽ��ϴ�!\n{game.Player.CurrentDungeon.Name} Ŭ����!\n�� ȹ�� ����ġ: {accumulatedRewardExp}\n���� {previousLevel} -> {currentLevel}");
                    ChangeSceneTo(GameRule.Game.Scene.DungeonSelection);
                    return true;
                }

                ChangeSceneTo(GameRule.Game.Scene.InDungeon);
                return true;
            }

            return false;
        }

        private void RunAwayButton_Click(object sender, EventArgs e)
        {
            if (IsBossBattle())
            {
                _ = MessageBox.Show("������������ ������� �Ұ� �Ф�");
                return;
            }

            int maxRate = 80;
            int rate;
            int baseValue = game.Player.CurrentDungeon.CurrentMob.Level - game.Player.Level + 2;
            rate = baseValue <= 0 ? 0 : Math.Min(baseValue * 5, maxRate);

            if (r.Next(0, 100) < rate)
            {
                ChangeSceneTo(GameRule.Game.Scene.InDungeon);
            }
            else
            {
                _ = LogListBox.Items.Add("������⿡ �����ߴ�! (�õ� Ƚ��: " + ++runAwayTryCount + ")");

                bool isUserDefeated = AttackUser();
                if (isUserDefeated)
                {
                    return;
                }

                RefreshBattleStatus();
            }
        }

        private bool IsBossBattle()
        {
            return IsBossFloor() && GetCurrentScene() == GameRule.Game.Scene.Battle;
        }

        private bool AttackMob()
        {
            Dictionary<string, int> attackResult = game.Player.Attack(game.Player.CurrentDungeon.CurrentMob);
            string mobName = game.Player.CurrentDungeon.CurrentMob.Name;
            int userFinalDamage = attackResult["myFinalDamage"];
            int mobHitPoints = attackResult["finalTargetHitPoints"];
            int userHitPoints = attackResult["myHitPoints"];

            _ = LogListBox.Items.Add(mobName + "��(��) " + userFinalDamage + "��ŭ ���ȭ (�� HP: " + userHitPoints + ", �� HP: " + mobHitPoints + ")");

            return CheckAndProcessGameFinish(userHitPoints, mobHitPoints);
        }

        private bool AttackUser()
        {
            Dictionary<string, int> getHitResult = game.Player.CurrentDungeon.CurrentMob.Attack(game.Player);
            string mobName = game.Player.CurrentDungeon.CurrentMob.Name;
            int mobFinalDamage = getHitResult["myFinalDamage"];
            int userHitPoints = getHitResult["finalTargetHitPoints"];
            int mobHitPoints = getHitResult["myHitPoints"];

            _ = LogListBox.Items.Add(mobName + "���� " + mobFinalDamage + "��ŭ ���ȭ (�� HP: " + userHitPoints + ", �� HP: " + mobHitPoints + ")");

            return CheckAndProcessGameFinish(userHitPoints, mobHitPoints);
        }

        private void DescendButton_Click(object sender, EventArgs e)
        {
            game.Player.DescendDungeonLevel();
            RefreshDungeonStatus();
        }

        private GameRule.Game.Scene GetCurrentScene()
        {
            return SceneControl.SelectedIndex == -1
                ? throw new ArgumentException("�̷� ���� �߻����� �ʾƾ� �ϴ¸�")
                : (GameRule.Game.Scene)SceneControl.SelectedIndex;
        }

        private void ChangeSceneTo(GameRule.Game.Scene targetScene)
        {
            SceneControl.SelectedIndex = (int)targetScene;
        }
    }
}