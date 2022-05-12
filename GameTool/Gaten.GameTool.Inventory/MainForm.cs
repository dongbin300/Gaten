namespace Gaten.GameTool.Inventory
{
    public partial class MainForm : Form
    {
        public Inventory inventory = new Inventory(4, 6);
        public List<ItemObject> objects = new List<ItemObject>();

        public MainForm()
        {
            InitializeComponent();

            InitObject();
        }

        void InitObject()
        {
            objects.Add(new ItemObject(1, 1, "���� ����", 1, 1, 10, 5));
            objects.Add(new ItemObject(2, 2, "��� ����", 1, 1, 10, 5));
            //objects.Add(new Object(3, 3, "������", 1, 1, 10000, 10));
            //objects.Add(new Object(4, 4, "�� ����", 1, 1, 10000, 100));
            //objects.Add(new Object(5, 5, "��� ����", 1, 1, 10000, 100));
            //objects.Add(new Object(6, 6, "���ϱ� ��ȭ��", 1, 1, 10000, 100));
            //objects.Add(new Object(7, 7, "�콼 ö ����", 1, 1, 10000, 100));
            //objects.Add(new Object(8, 8, "���� ť�� ����", 1, 1, 10000, 100));
            //objects.Add(new Object(9, 9, "û�� ť�� ����", 1, 1, 10000, 100));
            //objects.Add(new Object(10, 10, "Ȳ�� ť�� ����", 1, 1, 10000, 100));
        }

        new void Refresh()
        {
            inventoryView.Clear();
            foreach (Slot slot in inventory.Slots)
            {
                if (slot.Object == new NullObject())
                {
                    inventoryView.Items.Add("  ");
                }
                else
                {
                    inventoryView.Items.Add($"{slot.Object.Name}({slot.Count})");
                }
            }
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            inventory.GetObject(objects[new Random().Next(objects.Count)]);

            Refresh();
        }

        private void ThrowButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < inventoryView.SelectedItems.Count; i++)
                inventory.ThrowObject(inventory.Slots.Find(s => s.Index.Equals(inventoryView.SelectedItems[i].Index)));

            Refresh();
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {

        }
    }
}