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
                _ = listBox.Items.Add(d.Name);
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
                _ = listBox.Items.Add(m.Name);
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
                _ = listBox.Items.Add(i.Name);
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
                _ = listBox.Items.Add(i.Name);
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
                _ = listBox.Items.Add(i.Name);
            }

            _Type = Type.Potion;
            TabControl.SelectedIndex = 2;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                return;
            }

            switch (_Type)
            {
                case Type.Dungeon:
                    Dungeon? selectedDungeon = dungeons.Find(d => d.Name.Equals(listBox.SelectedItem.ToString()));
                    string[] dInfo = selectedDungeon.FormattedDungeonInfo.Split('/');
                    dungeonNameTextBox.Text = selectedDungeon.Name;
                    waveCountTextBox.Text = dInfo[0];
                    dungeonMonsterTextBox.Text = dInfo[1];
                    monsterCountMinTextBox.Text = dInfo[2].Split('~')[0];
                    monsterCountMaxTextBox.Text = dInfo[2].Split('~')[1];
                    TabControl.SelectedIndex = 5;
                    break;

                case Type.Monster:
                    Monster? selectedMonster = monsters.Find(d => d.Name.Equals(listBox.SelectedItem.ToString()));
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
                    Item? selectedMaterial = materials.Find(d => d.Name.Equals(listBox.SelectedItem.ToString()));
                    materialNameTextBox.Text = selectedMaterial.Name;
                    materialRankTextBox.Text = selectedMaterial.Rank;
                    materialValueTextBox.Text = selectedMaterial.Value;
                    materialLevelTextBox.Text = selectedMaterial.Level;
                    materialDescriptionTextBox.Text = selectedMaterial.Description;
                    break;

                case Type.Equipment:
                    Item? selectedEquipment = equipments.Find(d => d.Name.Equals(listBox.SelectedItem.ToString()));
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

        private void RegistMonster(Monster monster)
        {
            Monster? _monster = monsters.Find(d => d.Name.Equals(monster.Name));

            if (_monster != null)
            {
                _ = monsters.Remove(monsters.Find(d => d.Name.Equals(_monster.Name)));
            }
            monsters.Add(monster);
        }

        private void RegistDungeon(Dungeon dungeon)
        {
            Dungeon? _dungeon = dungeons.Find(d => d.Name.Equals(dungeon.Name));

            if (_dungeon != null)
            {
                _ = dungeons.Remove(dungeons.Find(d => d.Name.Equals(_dungeon.Name)));
            }
            dungeons.Add(dungeon);
        }

        private void RegistMaterial(Item material)
        {
            Item? _material = materials.Find(d => d.Name.Equals(material.Name));

            if (_material != null)
            {
                _ = materials.Remove(materials.Find(d => d.Name.Equals(_material.Name)));
            }
            materials.Add(material);
        }

        private void RegistEquipment(Item equipment)
        {
            Item? _equipment = equipments.Find(d => d.Name.Equals(equipment.Name));

            if (_equipment != null)
            {
                _ = equipments.Remove(equipments.Find(d => d.Name.Equals(_equipment.Name)));
            }
            equipments.Add(equipment);
        }

        private void RegistPotion(Item potion)
        {
            Item? _potion = potions.Find(d => d.Name.Equals(potion.Name));

            if (_potion != null)
            {
                _ = potions.Remove(potions.Find(d => d.Name.Equals(_potion.Name)));
            }
            potions.Add(potion);
        }
    }
}