using Gaten.Net.Windows.PE.Disassembly;
using Gaten.Net.Extensions;

namespace Gaten.Windows.SaturnDecompiler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDisassembly("test3.exe");

            TopMost = true;

            int index = 2450;

            dataGrid.FirstDisplayedScrollingRowIndex = index;
            dataGrid.Rows[index].Selected = true;
        }

        /// <summary>
        /// �𽺾������ ȭ�鿡 ǥ��
        /// 1. PE File�� �м��ؼ� �����ּҿ� �𽺾��������Ʈ�� ����(GetPEFileDisassembly)
        /// 2. �𽺾��������Ʈ�� �м��ؼ� �𽺾������ �ּ� / ����Ʈ�� / �𽺾���� ������ �ۼ�(MakeInstructionTable)
        /// 3. ȭ�鿡 ǥ��
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadDisassembly(string fileName)
        {
            // 1. PE File�� �м��ؼ� �����ּҿ� �𽺾��������Ʈ�� ����
            var peFileDisassembly = PEFile.GetPEFileDisassembly(fileName);

            // 2. �𽺾��������Ʈ�� �м��ؼ� �𽺾������ �ּ� / ����Ʈ�� / �𽺾���� ������ �ۼ�
            var instructions = DisassemblyHelper.MakeInstructionTable(peFileDisassembly);

            // [�ӽ�] ���൵ ǥ��
            dataGrid.Rows.Add(new string[]
            {
                DisassemblyHelper.Success.ToString(),
                (DisassemblyHelper.Success + DisassemblyHelper.Fail).ToString(),
                string.Format("{0:F2}%", (double)DisassemblyHelper.Success / (DisassemblyHelper.Success + DisassemblyHelper.Fail) * 100)
            });

            // 3. ȭ�鿡 ǥ��
            foreach (Instruction i in instructions)
            {
                string addressString = BitConverter.GetBytes(i.Address).ToHexString(true);
                string byteString = i.Bytes.ToHexString();
                string disassemblyString = i.Disassembly;

                dataGrid.Rows.Add(new string[]
                {
                    addressString, byteString, disassemblyString
                });
            }
        }
    }
}