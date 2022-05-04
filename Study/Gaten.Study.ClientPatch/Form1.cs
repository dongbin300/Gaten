using System.Diagnostics;

namespace Gaten.Study.ClientPatch
{
    public partial class Form1 : Form
    {
        string PatchKeyword = "patch";
        string currentProgram = Path.GetFileName(Environment.GetCommandLineArgs()[0]);

        public Form1()
        {
            InitializeComponent();

            versionLabel.Text = "V1.0";
        }

        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currentDirectory = Environment.CurrentDirectory;
            var patchDirectory = Path.Combine(currentDirectory, PatchKeyword);

            if (versionLabel.Text.Equals("V1.0"))
            {
                // �������� �ֽŹ��� ���� �ٿ�ε�(patch ���丮)
                Directory.CreateDirectory(patchDirectory);
                var latestFiles = Directory.GetFiles(@"C:\Server\ClientPatch");
                foreach (string latestFile in latestFiles)
                {
                    File.Copy(
                        latestFile,
                        Path.Combine(patchDirectory, Path.GetFileName(latestFile))
                        );
                }

                string newFileName = Path.Combine(patchDirectory, currentProgram);
                var newFile = new FileInfo(newFileName);
                while (IsFileLocked(newFile))
                {

                }

                // patch ���丮 ���� exe���� ����
                Process.Start(newFileName);

                // ���� ������ ���μ��� ����
                var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(currentProgram));
                var earlyProcess = processes.Aggregate((min, x) => (min == null || x.StartTime.Ticks < min.StartTime.Ticks ? x : min));
                earlyProcess.Kill();
            }
            else
            {
                MessageBox.Show("�̹� �ֽŹ����Դϴ�.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var currentDirectory = Environment.CurrentDirectory;
            var patchDirecotry = Directory.GetDirectories(currentDirectory).Where(dir => Path.GetFileName(dir).Equals(PatchKeyword)).ToList();

            // patch ���丮 �ȿ��� �����ߴٸ� ��ġ���� Ŭ���̾�Ʈ
            if (Path.GetFileName(currentDirectory).Equals(PatchKeyword))
            {
                // ��ġ ���丮�� �ִ� ��� ������ ���� ���丮�� ����
                File.Copy(
                    Path.Combine(currentDirectory, currentProgram), // .../patch/ClientPatch.exe
                    Path.Combine(Path.GetDirectoryName(currentDirectory), currentProgram) // .../ClientPatch.exe
                    );

                // ���� ���丮�� �ִ� ����� exe���� ����
                Process.Start(Path.Combine(Path.GetDirectoryName(currentDirectory), currentProgram));

                // ����
                Application.Exit();
            }
            // patch ���丮�� �����ϸ� ���� ����
            else if (patchDirecotry != null && patchDirecotry.Count > 0)
            {
                Thread.Sleep(1000);
                Directory.Delete(patchDirecotry[0], true);
            }
        }
    }
}