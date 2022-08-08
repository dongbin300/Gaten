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
        /// 디스어셈블리를 화면에 표시
        /// 1. PE File을 분석해서 시작주소와 디스어셈블리바이트를 얻음(GetPEFileDisassembly)
        /// 2. 디스어셈블리바이트를 분석해서 디스어셈블리를 주소 / 바이트값 / 디스어셈블리 구조로 작성(MakeInstructionTable)
        /// 3. 화면에 표시
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadDisassembly(string fileName)
        {
            // 1. PE File을 분석해서 시작주소와 디스어셈블리바이트를 얻음
            var peFileDisassembly = PEFile.GetPEFileDisassembly(fileName);

            // 2. 디스어셈블리바이트를 분석해서 디스어셈블리를 주소 / 바이트값 / 디스어셈블리 구조로 작성
            var instructions = DisassemblyHelper.MakeInstructionTable(peFileDisassembly);

            // [임시] 진행도 표시
            dataGrid.Rows.Add(new string[]
            {
                DisassemblyHelper.Success.ToString(),
                (DisassemblyHelper.Success + DisassemblyHelper.Fail).ToString(),
                string.Format("{0:F2}%", (double)DisassemblyHelper.Success / (DisassemblyHelper.Success + DisassemblyHelper.Fail) * 100)
            });

            // 3. 화면에 표시
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