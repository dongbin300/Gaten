using Gaten.GameTool.NGD.NFDManager.Frame;

namespace Gaten.GameTool.NGD.NFDManager
{
    public partial class MainForm : Form
    {
        public enum Type
        {
            Dungeon,
            Monster,
            Material,
            Equipment,
            Potion
        }

        public Type _Type;

        public List<Dungeon> dungeons;
        public List<Monster> monsters;
        public List<Item> materials;
        public List<Item> equipments;
        public List<Item> potions;

        public MainForm()
        {
            InitializeComponent();
            TabControl.SizeMode = TabSizeMode.Fixed;
            TabControl.ItemSize = new Size(0, 1);
        }

        private void dungeonButton_Click(object sender, EventArgs e)
        {
            dungeons = NFDFileReader.ReadDungeon();

            listBox.Items.Clear();
            foreach (Dungeon d in dungeons)
            {
                listBox.Items.Add(d.Name);
            }

            _Type = Type.Dungeon;
            TabControl.SelectedIndex = 5;
        }

        private void monsterButton_Click(object sender, EventArgs e)
        {
            monsters = NFDFileReader.ReadMonster();

            listBox.Items.Clear();
            foreach (Monster m in monsters)
            {
                listBox.Items.Add(m.Name);
            }

            _Type = Type.Monster;
            TabControl.SelectedIndex = 0;
        }

        private void materialButton_Click(object sender, EventArgs e)
        {
            materials = NFDFileReader.ReadMaterial();

            listBox.Items.Clear();
            foreach (Item i in materials)
            {
                listBox.Items.Add(i.Name);
            }

            _Type = Type.Material;
            TabControl.SelectedIndex = 1;
        }

        private void equipmentButton_Click(object sender, EventArgs e)
        {
            equipments = NFDFileReader.ReadEquipment();

            listBox.Items.Clear();
            foreach (Item i in equipments)
            {
                listBox.Items.Add(i.Name);
            }

            _Type = Type.Equipment;
            TabControl.SelectedIndex = 3;
        }

        private void potionButton_Click(object sender, EventArgs e)
        {
            potions = NFDFileReader.ReadPotion();

            listBox.Items.Clear();
            foreach (Item i in potions)
            {
                listBox.Items.Add(i.Name);
            }

            _Type = Type.Potion;
            TabControl.SelectedIndex = 2;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
                return;

            switch (_Type)
            {
                case Type.Dungeon:
                    var selectedDungeon = dungeons.Find(d => d.Name.Equals(listBox.SelectedItem.ToString()));
                    string[] dInfo = selectedDungeon.FormattedDungeonInfo.Split('/');
                    dungeonNameTextBox.Text = selectedDungeon.Name;
                    waveCountTextBox.Text = dInfo[0];
                    dungeonMonsterTextBox.Text = dInfo[1];
                    monsterCountMinTextBox.Text = dInfo[2].Split('~')[0];
                    monsterCountMaxTextBox.Text = dInfo[2].Split('~')[1];
                    TabControl.SelectedIndex = 5;
                    break;

                case Type.Monster:
                    var selectedMonster = monsters.Find(d => d.Name.Equals(listBox.SelectedItem.ToString()));
                    monsterNameTextBox.Text = selectedMonster.Name;
                    monsterExpTextBox.Text = selectedMonster.Exp;
                    monsterGoldTextBox.Text = selectedMonster.Gold;
                    monsterPowerTextBox.Text = selectedMonster.Power;
                    monsterStaminaTextBox.Text = selectedMonster.Stamina;
                    monsterIntelliTextBox.Text = selectedMonster.Intelli;
                    monsterWillpowerTextBox.Text = selectedMonster.Willpower;
                    monsterConcentrationTextBox.Text = selectedMonster.Concentration;
                    monsterAgilityTextBox.Text = selectedMonster.Agility;
                    monsterDropItemTextBox.Text = selectedMonster.DropItemFormattedInfo;
                    break;

                case Type.Material:
                    var selectedMaterial = materials.Find(d => d.Name.Equals(listBox.SelectedItem.ToString()));
                    materialNameTextBox.Text = selectedMaterial.Name;
                    materialRankTextBox.Text = selectedMaterial.Rank;
                    materialValueTextBox.Text = selectedMaterial.Value;
                    materialLevelTextBox.Text = selectedMaterial.Level;
                    materialDescriptionTextBox.Text = selectedMaterial.Description;
                    break;

                case Type.Equipment:
                    var selectedEquipment = equipments.Find(d => d.Name.Equals(listBox.SelectedItem.ToString()));
                    equipmentNameTextBox.Text = selectedEquipment.Name;
                    equipmentRankTextBox.Text = selectedEquipment.Rank;
                    equipmentLevelTextBox.Text = selectedEquipment.Level;
                    equipmentTypeTextBox.Text = selectedEquipment.EqType;
                    equipmentFormattedEffectTextBox.Text = selectedEquipment.formattedEquipmentEffect;
                    break;
            }
        }

        private void registButton_Click(object sender, EventArgs e)
        {
            switch (_Type)
            {
                case Type.Dungeon:
                    RegistDungeon(new Dungeon()
                    {
                        Name = dungeonNameTextBox.Text,
                        FormattedDungeonInfo = $"{waveCountTextBox.Text}/{dungeonMonsterTextBox.Text}/{monsterCountMinTextBox.Text}~{monsterCountMaxTextBox.Text}"
                    });

                    NFDFileWriter.WriteDungeon(dungeons);
                    dungeonButton_Click(sender, e);
                    break;

                case Type.Monster:
                    RegistMonster(new Monster()
                    {
                        Name = monsterNameTextBox.Text,
                        Exp = monsterExpTextBox.Text,
                        Gold = monsterGoldTextBox.Text,
                        Power = monsterPowerTextBox.Text,
                        Stamina = monsterStaminaTextBox.Text,
                        Intelli = monsterIntelliTextBox.Text,
                        Willpower = monsterWillpowerTextBox.Text,
                        Concentration = monsterConcentrationTextBox.Text,
                        Agility = monsterAgilityTextBox.Text,
                        DropItemFormattedInfo = monsterDropItemTextBox.Text
                    });

                    NFDFileWriter.WriteMonster(monsters);
                    monsterButton_Click(sender, e);
                    break;

                case Type.Material:
                    RegistMaterial(new Item()
                    {
                        Name = materialNameTextBox.Text,
                        Rank = materialRankTextBox.Text,
                        Description = materialDescriptionTextBox.Text,
                        Value = materialValueTextBox.Text,
                        Level = materialLevelTextBox.Text
                    });

                    NFDFileWriter.WriteMaterial(materials);
                    materialButton_Click(sender, e);
                    break;

                case Type.Equipment:
                    RegistEquipment(new Item()
                    {
                        Name = equipmentNameTextBox.Text,
                        EqType = equipmentTypeTextBox.Text,
                        Rank = equipmentRankTextBox.Text,
                        formattedEquipmentEffect = equipmentFormattedEffectTextBox.Text,
                        Level = equipmentLevelTextBox.Text
                    });

                    NFDFileWriter.WriteEquipment(equipments);
                    equipmentButton_Click(sender, e);
                    break;
            }
        }

        void RegistMonster(Monster monster)
        {
            var _monster = monsters.Find(d => d.Name.Equals(monster.Name));

            if (_monster != null)
            {
                monsters.Remove(monsters.Find(d => d.Name.Equals(_monster.Name)));
            }
            monsters.Add(monster);
        }

        void RegistDungeon(Dungeon dungeon)
        {
            var _dungeon = dungeons.Find(d => d.Name.Equals(dungeon.Name));

            if (_dungeon != null)
            {
                dungeons.Remove(dungeons.Find(d => d.Name.Equals(_dungeon.Name)));
            }
            dungeons.Add(dungeon);
        }

        void RegistMaterial(Item material)
        {
            var _material = materials.Find(d => d.Name.Equals(material.Name));

            if (_material != null)
            {
                materials.Remove(materials.Find(d => d.Name.Equals(_material.Name)));
            }
            materials.Add(material);
        }

        void RegistEquipment(Item equipment)
        {
            var _equipment = equipments.Find(d => d.Name.Equals(equipment.Name));

            if (_equipment != null)
            {
                equipments.Remove(equipments.Find(d => d.Name.Equals(_equipment.Name)));
            }
            equipments.Add(equipment);
        }

        void RegistPotion(Item potion)
        {
            var _potion = potions.Find(d => d.Name.Equals(potion.Name));

            if (_potion != null)
            {
                potions.Remove(potions.Find(d => d.Name.Equals(_potion.Name)));
            }
            potions.Add(potion);
        }
    }
}