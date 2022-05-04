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
                // 서버에서 최신버전 파일 다운로드(patch 디렉토리)
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

                // patch 디렉토리 안의 exe파일 실행
                Process.Start(newFileName);

                // 먼저 실행한 프로세스 종료
                var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(currentProgram));
                var earlyProcess = processes.Aggregate((min, x) => (min == null || x.StartTime.Ticks < min.StartTime.Ticks ? x : min));
                earlyProcess.Kill();
            }
            else
            {
                MessageBox.Show("이미 최신버전입니다.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var currentDirectory = Environment.CurrentDirectory;
            var patchDirecotry = Directory.GetDirectories(currentDirectory).Where(dir => Path.GetFileName(dir).Equals(PatchKeyword)).ToList();

            // patch 디렉토리 안에서 실행했다면 패치진행 클라이언트
            if (Path.GetFileName(currentDirectory).Equals(PatchKeyword))
            {
                // 패치 디렉토리에 있는 모든 파일을 원래 디렉토리에 복사
                File.Copy(
                    Path.Combine(currentDirectory, currentProgram), // .../patch/ClientPatch.exe
                    Path.Combine(Path.GetDirectoryName(currentDirectory), currentProgram) // .../ClientPatch.exe
                    );

                // 원래 디렉토리에 있는 복사된 exe파일 실행
                Process.Start(Path.Combine(Path.GetDirectoryName(currentDirectory), currentProgram));

                // 종료
                Application.Exit();
            }
            // patch 디렉토리가 존재하면 전부 삭제
            else if (patchDirecotry != null && patchDirecotry.Count > 0)
            {
                Thread.Sleep(1000);
                Directory.Delete(patchDirecotry[0], true);
            }
        }
    }
}