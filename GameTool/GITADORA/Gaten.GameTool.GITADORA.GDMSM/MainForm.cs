using Gaten.Net.Extension;
using Gaten.Net.Image;
using Gaten.Net.Windows.Forms;
using Path = Gaten.Net.GameRule.GITADORA.Path;

using System.Text;

namespace Gaten.GameTool.GITADORA.GDMSM
{
    public partial class MainForm : Form
    {
        /*
         * NOWNIZ ���� ������3 ��48 ����20 720p 29.97f
         * GM-JAYO ��Ÿ/���̽� ������8 ��16 ����20 720p 30f
         */

        /* * * * * * * *
            ���� & ����
         * * * * * * * */
        // �������Ӹ��� �̹����� ��������
        // *����
        // 1~3 - Zero Noize
        // 4 - �� ���� �Ⱥ���
        // 5~7 - �� �ణ ����
        // 8 - ���� ���� ���� ����
        // 9 - �����ణ���̰�, �� ���̺���
        // 10 - ���� �� ����
        // *��Ÿ
        // 8
        //int frame;

        /* * * * * * * *
            ��ũ����
         * * * * * * * */

        public enum Mode { Drum, Guitar, Bass };

        public enum Version { gd, odtbtbr, mat, exc }

        //readonly string[] VERSIONS = { "gd", "odtbtbr", "mat", "exc" };
        //readonly string[] MODES = { Modes.Drum, Modes.Guitar, Modes.Bass };
        //readonly int[] GEAR_STARTS_DRUM = { 302, 304, 296 };
        //readonly int[] GEAR_WIDTHS_DRUM = { 510, 512, 518 };
        //readonly int[] GEAR_STARTS_GUITAR = { 524, 600, 600 };
        //readonly int[] GEAR_WIDTHS_GUITAR = { 235, 300, 300 };
        // ��� ǥ�� ��ǥ [0]-drum, [1]-guitar, [2]-bass
        //readonly int[] SPEED_STARTS_X = { 800, 510, 510 };
        //readonly int[] SPEED_STARTS_Y = { 510, 20, 20 };
        // ����
        private Version version;

        // ��� �ε���
        //int modeI;
        // ��� ������
        private int gearStart;

        // ��� ��
        private int gearWidth;

        // ��ũ���� ���丮
        private string screenShotDirectory;

        // ��ũ���� ����
        private FileInfo[] files;

        // �̹��� ����
        private int bCount;

        // �� �������� ��Ʈ���� ����
        /* BPM ��� height
         * 250 4.0 27
         * 144 5.5 37
         * 250 5.5 37
         */
        private int height;

        // ��Ӻ� height
        // 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5, 6.0, 6.5, 7.0, 7.5
        // 0, 1, 2, 3, 4, 5
        // /0.5 -1
        // ��Ʈ 1���� 2���� ���̸� ���̰�
        // ��Ʈ�� �߷����̸� �ø���
        //readonly int[] current.heights = { 3, 7, 10, 14, 17, 21, 24, 27, 30, 34, 37, 41, 44, 47, 50 };
        //readonly int[] current.heights = { 2, 4, 6, 9, 11, 13, 15, 17, 19, 22, 24, 26, 28, 30, 32 };
        // ���� �̹��� �ε���
        private int startScreenShotIndex;

        // �� �̹��� �ε���
        private int endScreenShotIndex;

        // �����ؾ��� ���� �׷�ȭ
        private List<string> fileId = new List<string>();

        /* * * * * * * *
             ��Ʈ��
         * * * * * * * */

        // �� �ٿ� �� ���� �������� ��������
        //int oneColumnCount;
        // �ٰ� �� ������ ����
        //int margin;
        // �� ����
        private int cCount;

        /* * * * * * * *
             �ý���
         * * * * * * * */

        // ���� �̹��� �ε���
        private int bI;

        // ���� ó������ ���� �ε���
        private int fI;

        // ���� ���� �Ϸ� �÷���
        private bool complete;

        // ��� ���� ��ǥ üũ �÷���
        private bool gearStartCheck;

        // üũ �� ������ ��ũ���� �ε���
        //int scI = 200;
        // ���� ó���۾�
        private enum Proceedings
        { LoadImage, VersionCheck, Trim, Create, Merge, Parse, Save, Complete }

        private Proceedings proceed1;

        private Graphics g;
        private Thread makeWorker1;

        private Player current;
        private Player[] player = new Player[5];

        private string fumenDirectory;
        private string videoDirectory;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // �÷��̾� �ʱ�ȭ
            player[0] = new Player("NOWNIZ", Mode.Drum, 3, 48, 20, new int[] { 3, 7, 10, 14, 17, 21, 24, 27, 30, 34, 37, 41, 44, 47, 50 }, new int[] { 302, 304, 296 }, new int[] { 510, 512, 518 }, 800, 630, 0, 500, 300, 20, 20);
            player[1] = new Player("GM-JAYO", Mode.Guitar, 8, 16, 20, new int[] { 2, 4, 6, 9, 11, 13, 15, 17, 19, 22, 24, 26, 28, 30, 32 }, new int[] { 524, 524, 524 }, new int[] { 235, 235, 235 }, 510, 20, 620 - 300, 300, 100, 3, 20, 620);
            player[2] = new Player("SakamotoNeko(G)", Mode.Guitar, 8, 16, 20, new int[] { 2, 4, 6, 9, 11, 13, 15, 17, 19, 22, 24, 26, 28, 30, 32 }, new int[] { 188, 188, 188 }, new int[] { 235, 235, 235 }, 510, 20, 660 - 300, 300, 100, 20, 30, 660); // speed x6.0
            player[3] = new Player("SakamotoNeko(B)", Mode.Guitar, 8, 16, 20, new int[] { 2, 4, 6, 9, 11, 13, 15, 17, 19, 22, 24, 26, 28, 30, 32 }, new int[] { 856, 856, 856 }, new int[] { 235, 235, 235 }, 510, 20, 660 - 300, 300, 100, 20, 30, 660); // speed x6.0
            player[4] = new Player("DTX", Mode.Drum, 3, 48, 20, new int[] { 0, 3, 7, 10, 14, 17, 21, 23, 27, 30, 34, 37, 41, 44, 47 }, new int[] { 302, 304, 296 }, new int[] { 510, 512, 518 }, 800, 630, 0, 500, 300, 20, 20);
            foreach (Player p in player)
                playerListBox.Items.Add(p.name);

            // �÷��̾� deafult
            playerListBox.SelectedIndex = 4;

            // ���丮 �ε�
            using (FileStream fs = new FileStream("dir.ini", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    screenShotDirectory = sr.ReadLine().Split('\"')[1];
                    fumenDirectory = sr.ReadLine().Split('\"')[1];
                    videoDirectory = sr.ReadLine().Split('\"')[1];
                }
            }

            // ���� ���� grouping
            files = new DirectoryInfo(screenShotDirectory).GetFiles("*.bmp");
            foreach (FileInfo fi in files)
            {
                string fileIdStr = fi.Name.Substring(0, fi.Name.Length - 19);
                if (!fileId.Contains(fileIdStr))
                    fileId.Add(fileIdStr);
            }

            // CheckedListBox�� ���� ����Ʈ �߰�
            int ip = 0;
            selectFumenCheckedListBox.Items.Add("��ü ����");
            selectFumenCheckedListBox.SetItemCheckState(ip++, CheckState.Checked);

            foreach (string str in fileId)
            {
                files = new DirectoryInfo(screenShotDirectory).GetFiles($"{str}*.bmp");

                selectFumenCheckedListBox.Items.Add($"{str.Replace("Gitadora ", "").Replace("GITADORA ", "").Replace(" drum", "").Replace(" guitar", "").Replace(" bass", "")} ({files.Length}) {string.Format("{0:0.00%}/{1:0.00%}", Util.DislocationRatio(files, 1.2, current.frame), Util.DislocationRatio(files, 1.5, current.frame))}");
                selectFumenCheckedListBox.SetItemCheckState(ip++, CheckState.Checked);
            }
        }

        private void TrimScreenShot(int cut)
        {
            // ó������ ������ ȭ�� ������ �ε��� ã��
            for (int i = 0; i < bCount; i++)
            {
                Image image = Image.FromFile(files[i].FullName);
                byte[] screenShotRGB = image.CropImage(new Rectangle(gearStart, current.trimScreenShotStartY, gearWidth - cut, current.trimScreenShotLengthY)).GetPixelData();

                if (screenShotRGB.RGBAverage() < current.startThreshold)
                {
                    startScreenShotIndex = i;
                    break;
                }
            }

            // ó������ 10������ ���� ������ ȭ�� ������ �ε��� ã��
            int life = 0;
            for (int i = bCount - 1; i >= startScreenShotIndex; i--)
            {
                Image image = Image.FromFile(files[i].FullName);
                byte[] screenShotRGB = image.CropImage(new Rectangle(gearStart, current.trimScreenShotStartY, gearWidth - cut, current.trimScreenShotLengthY)).GetPixelData();

                life = screenShotRGB.RGBAverage() < current.endThreshold ? life + 1 : 0;

                if (life >= 10)
                {
                    endScreenShotIndex = i + 10;
                    break;
                }
            }

            //endScreenShotIndex = 500;

            // bCount / cCount ����
            bCount = endScreenShotIndex - startScreenShotIndex;
            cCount = bCount / current.oneColumnCount + 1;
            Delegater.ProgressBarSetMax(makeProgressBar, bCount);
        }

        private void CheckVersion()
        {
            double max = 0.0;
            int maxI = 0;

            byte[] screenShotRGB = new Bitmap(files[0].FullName).GetPixelData();
            FileInfo[] versionImageFiles = new DirectoryInfo("version").GetFiles("*.bmp");
            for (int i = 0; i < versionImageFiles.Length; i++)
            {
                byte[] versionImageRGB = new Bitmap(versionImageFiles[i].FullName).GetPixelData();
                double sameDegree = screenShotRGB.SameDegree(versionImageRGB);

                // ���� ���� ��ġ���� �� ������ ��
                if (max < sameDegree)
                {
                    max = sameDegree;
                    maxI = i;
                }
            }

            // ���� ã�� �Ϸ�
            switch (maxI)
            {
                case 0: version = Version.gd; break;
                case 1: version = Version.odtbtbr; break;
                case 2: version = Version.mat; break;
                case 3: version = Version.exc; break;
            }

            // ������ �°� ��� ������, ���� ����
            switch (version)
            {
                case Version.gd:
                    gearStart = current.gearStarts[0];
                    gearWidth = current.gearWidths[0];
                    break;

                case Version.odtbtbr:
                    gearStart = current.gearStarts[1];
                    gearWidth = current.gearWidths[1];
                    break;

                case Version.mat:
                    gearStart = current.gearStarts[2];
                    gearWidth = current.gearWidths[2];
                    break;

                case Version.exc:
                    gearStart = current.gearStarts[2];
                    gearWidth = current.gearWidths[2];
                    break;
            }

            // gear�� speeed�� üũ �ϱ� ���ؼ� �̸����� �̹����� ������
            gearStartCheck = true;
            while (gearStartCheck)
            {
                Bitmap gearBitmap = null;
                switch (current.mode)
                {
                    case Mode.Drum:
                        gearBitmap = new Bitmap(files[current.scI].FullName).CropImage(new Rectangle(gearStart, 720 - gearWidth, gearWidth, gearWidth));
                        break;

                    case Mode.Guitar:
                    case Mode.Bass:
                        gearBitmap = new Bitmap(files[current.scI].FullName).CropImage(new Rectangle(gearStart, 0, gearWidth, gearWidth));
                        break;
                }
                Bitmap speedBitmap = new Bitmap(files[current.scI].FullName).CropImage(new Rectangle(current.speedStartsX, current.speedStartsY, 128, 64));
                checkPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                checkPictureBox.BackgroundImage = gearBitmap;
                speedPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                speedPictureBox.BackgroundImage = speedBitmap;
                Thread.Sleep(500);
            }
            checkPictureBox.BackgroundImage = null;
            speedPictureBox.BackgroundImage = null;
        }

        /*void CheckSpeed()
        {
            double max = 0.0;
            int maxI = 0;

            if (handOperateCheckBox.Checked)
            {
                speedStartX = int.Parse(speedXTextBox.Text);
                speedStartY = int.Parse(speedYTextBox.Text);
            }
            else
            {
                switch (VERSIONS[versionI])
                {
                    case "gd":
                        speedStartX = SPEED_STARTX[0];
                        speedStartY = SPEED_STARTY[0];
                        break;

                    case "odtbtbr":
                        speedStartX = SPEED_STARTX[1];
                        speedStartY = SPEED_STARTY[1];
                        break;

                    case "mat":
                    case "exc":
                        speedStartX = SPEED_STARTX[2];
                        speedStartY = SPEED_STARTY[2];
                        break;
                }
            }

            speedCheck = true;
            while (speedCheck)
            {
                Bitmap speedBitmap = CropImage(new Bitmap(files[scI].FullName), new Rectangle(speedStartX, speedStartY, SPEED_SIZE, SPEED_SIZE));
                checkPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                checkPictureBox.BackgroundImage = speedBitmap;
            }

            byte[] screenShotRGB = GetPixelData(b, speedStartX, speedStartY, SPEED_SIZE, SPEED_SIZE);
            screenShotRGB = FitByteArray(screenShotRGB, b.Width, SPEED_SIZE, SPEED_SIZE, SPEED_SIZE, false);

            FileInfo[] speedImageFiles = new DirectoryInfo("speed").GetFiles($"{VERSIONS[versionI]}*.bmp");

            for (int i = 0; i < speedImageFiles.Length; i++)
            {
                Bitmap sb = new Bitmap(speedImageFiles[i].FullName);
                byte[] speedImageRGB = GetPixelData(sb);
                speedImageRGB = FitByteArray(speedImageRGB, sb.Width, SPEED_SIZE, SPEED_SIZE, SPEED_SIZE, false);
                double sameDegree = SameDegree(screenShotRGB, speedImageRGB);

                // ���� ���� ��ġ���� �� �ӵ��� ��
                if (max < sameDegree)
                {
                    max = sameDegree;
                    maxI = i;
                }
            }

            // �ӵ��� �°� height ����
            height = heights[int.Parse(speedImageFiles[maxI].Name.Split('.')[0].Replace(VERSIONS[versionI], "")) / 5 - 1];
        }*/

        private void MakeButton_Click(object sender, EventArgs e)
        {
            Delegater.EnableSet(makeButton, false);
            complete = false;

            Thread viewWorker = new Thread(new ThreadStart(Proceed));
            makeWorker1 = new Thread(new ThreadStart(MakeFumen1));

            // ���� �۾���Ȳ ���
            viewWorker.Start();

            // ���� ���� ����
            makeWorker1.Start();
        }

        private void Proceed()
        {
            while (!complete)
            {
                switch (proceed1)
                {
                    case Proceedings.LoadImage:
                        Delegater.TextSet(proceedLabel, "�̹��� �ҷ����� ��..");
                        break;

                    case Proceedings.VersionCheck:
                        Delegater.TextSet(proceedLabel, "���� üũ�ϴ� ��..");
                        break;

                    case Proceedings.Trim:
                        Delegater.TextSet(proceedLabel, "���ʿ��� �̹��� �����ϴ� ��..");
                        break;

                    case Proceedings.Create:
                        Delegater.TextSet(proceedLabel, "����� ��..");
                        break;

                    case Proceedings.Merge:
                        //'��� ����'�� üũ�Ǿ������� üũ ���� -1
                        int allCheck = selectFumenCheckedListBox.GetItemCheckState(0) == CheckState.Checked ? 1 : 0;

                        Delegater.ProgressBarSetValue(makeProgressBar, bI + 1);
                        Delegater.TextSet(mergeFileCountLabel, $"{fI + 1} / {selectFumenCheckedListBox.CheckedItems.Count - allCheck}");
                        Delegater.TextSet(mergeLabel, string.Format("{0} / {1} ({2:0.0}%)", bI + 1, bCount, Math.Round((double)(bI + 1) / bCount * 100.0, 1)));
                        Delegater.TextSet(fileNameLabel, files[startScreenShotIndex + bI].Name.Substring(files[startScreenShotIndex + bI].Name.Length - 14));
                        Delegater.TextSet(proceedLabel, "��ġ�� ��..");
                        break;

                    case Proceedings.Parse:
                        Delegater.TextSet(proceedLabel, "�м��ϴ� ��..");
                        break;

                    case Proceedings.Save:
                        Delegater.TextSet(proceedLabel, "�����ϴ� ��..");
                        break;

                    case Proceedings.Complete:
                        Delegater.TextSet(proceedLabel, "�Ϸ�.");
                        break;
                }
            }
        }

        /*
        [Obsolete]
        private void MakeFumen2()
        {
            // ���� �����尡 merge�۾��� �� ������ ���
            while (proceed1 != Proceedings.Merge) { }

            proceed2 = Proceedings.Merge;

            for (bI2 = bCount / 4; bI2 < bCount * 2 / 4; bI2++)
            {
                Image image = CropImage(Image.FromFile(files[startScreenShotIndex + bI2].FullName), new Rectangle(gearStart, 0, gearWidth, height * frame));
                while (UsingGraphics) { }
                UsingGraphics = true;
                while (makeWorker1.ThreadState != ThreadState.Running) { }
                makeWorker1.Suspend();
                while (makeWorker3.ThreadState != ThreadState.Running) { }
                while (makeWorker4.ThreadState != ThreadState.Running) { }
                makeWorker3.Suspend();
                makeWorker4.Suspend();
                g.DrawImage(image, margin + (gearWidth + margin) * (int)(bI2 / oneColumnCount), height * frame * (oneColumnCount - bI2 % oneColumnCount - 1));
                while (makeWorker1.ThreadState != ThreadState.Suspended) { }
                makeWorker1.Resume();
                while (makeWorker3.ThreadState != ThreadState.Suspended) { }
                makeWorker3.Resume();
                while (makeWorker4.ThreadState != ThreadState.Suspended) { }
                makeWorker4.Resume();
                UsingGraphics = false;
                image.Dispose();
            }

            proceed2 = Proceedings.Save;
        }

        [Obsolete]
        private void MakeFumen3()
        {
            // ���� �����尡 merge�۾��� �� ������ ���
            while (proceed1 != Proceedings.Merge) { }

            proceed3 = Proceedings.Merge;

            for (bI3 = bCount * 2 / 4; bI3 < bCount * 3 / 4; bI3++)
            {
                Image image = CropImage(Image.FromFile(files[startScreenShotIndex + bI3].FullName), new Rectangle(gearStart, 0, gearWidth, height * frame));
                while (UsingGraphics) { }
                UsingGraphics = true;
                while (makeWorker1.ThreadState != ThreadState.Running) { }
                makeWorker1.Suspend();
                while (makeWorker2.ThreadState != ThreadState.Running) { }
                makeWorker2.Suspend();
                while (makeWorker4.ThreadState != ThreadState.Running) { }
                makeWorker4.Suspend();
                g.DrawImage(image, margin + (gearWidth + margin) * (int)(bI3 / oneColumnCount), height * frame * (oneColumnCount - bI3 % oneColumnCount - 1));
                while (makeWorker1.ThreadState != ThreadState.Suspended) { }
                makeWorker1.Resume();
                while (makeWorker2.ThreadState != ThreadState.Suspended) { }
                makeWorker2.Resume();
                while (makeWorker4.ThreadState != ThreadState.Suspended) { }
                makeWorker4.Resume();
                UsingGraphics = false;
                image.Dispose();
            }

            proceed3 = Proceedings.Save;
        }

        [Obsolete]
        private void MakeFumen4()
        {
            // ���� �����尡 merge�۾��� �� ������ ���
            while (proceed1 != Proceedings.Merge) { }

            proceed4 = Proceedings.Merge;

            for (bI4 = bCount * 3 / 4; bI4 < bCount; bI4++)
            {
                Image image = CropImage(Image.FromFile(files[startScreenShotIndex + bI4].FullName), new Rectangle(gearStart, 0, gearWidth, height * frame));
                while (UsingGraphics) { }
                UsingGraphics = true;
                while(makeWorker1.ThreadState != ThreadState.Running) { }
                makeWorker1.Suspend();
                while(makeWorker2.ThreadState != ThreadState.Running) { }
                makeWorker2.Suspend();
                while(makeWorker3.ThreadState != ThreadState.Running) { }
                makeWorker3.Suspend();
                g.DrawImage(image, margin + (gearWidth + margin) * (int)(bI4 / oneColumnCount), height * frame * (oneColumnCount - bI4 % oneColumnCount - 1));
                while(makeWorker1.ThreadState != ThreadState.Suspended) { }
                makeWorker1.Resume();
                while(makeWorker2.ThreadState != ThreadState.Suspended) { }
                makeWorker2.Resume();
                while(makeWorker3.ThreadState != ThreadState.Suspended) { }
                makeWorker3.Resume();
                UsingGraphics = false;
                image.Dispose();
            }

            proceed4 = Proceedings.Save;
        }
        */

        private void MakeFumen1()
        {
            // ���� ��� Ÿ��
            // 1 - One Line
            // 2 - Multi Line
            int fumenPrintType = lineORadioButton.Checked ? 1 : 2;

            // ���� ��ȯ���� Ÿ��
            // 1 - ImageFile
            // 2 - ParsedTextFile(fumenPrintType�� ������ 1�� �����ؾ���)
            int fumenReturnFileType = imageRadioButton.Checked ? 1 : 2;

            // üũ�� ���� �� ���° ������ ó���ϰ� �ִ���
            int fp = 0;

            for (int i = 0; i < fileId.Count; i++)
            {
                if (selectFumenCheckedListBox.GetItemCheckState(i + 1) == CheckState.Unchecked) continue;
                fI = fp++;
                complete = false;

                // ���� ó�� ���� ����
                Delegater.ListBoxSelect(selectFumenCheckedListBox, i + 1);

                // �׷캰�� ���� ����
                proceed1 = Proceedings.LoadImage;
                files = new DirectoryInfo(screenShotDirectory).GetFiles($"{fileId[i]}*.bmp");
                bCount = files.Length;

                // ���� üũ �� ��� ���� �Է�
                proceed1 = Proceedings.VersionCheck;
                CheckVersion();

                // ��ũ������ ���۰� �� ����
                proceed1 = Proceedings.Trim;
                if (current.mode == Mode.Drum)
                    TrimScreenShot(0);
                else
                    TrimScreenShot(43);

                // ���� ����
                proceed1 = Proceedings.Create;
                Bitmap outputBitmap = fumenPrintType == 1 ?
                new Bitmap(current.margin * 2 + gearWidth, height * current.frame * bCount) :
                new Bitmap(current.margin + (gearWidth + current.margin) * cCount, height * current.frame * current.oneColumnCount);
                g = Graphics.FromImage(outputBitmap);

                // ��ũ���� ���̱�
                proceed1 = Proceedings.Merge;

                for (bI = 0; bI < bCount; bI++)
                {
                    Image image = null;
                    switch (current.mode)
                    {
                        case Mode.Drum:
                            image = Image.FromFile(files[startScreenShotIndex + bI].FullName).CropImage(new Rectangle(gearStart, 0, gearWidth, height * current.frame));
                            break;

                        case Mode.Guitar:
                        case Mode.Bass:
                            image = Image.FromFile(files[startScreenShotIndex + bI].FullName).CropImage(new Rectangle(gearStart, current.guitarEndY - height * current.frame, gearWidth, height * current.frame));
                            image.RotateFlip(RotateFlipType.Rotate180FlipX);
                            break;
                    }
                    if (fumenPrintType == 1)
                        g.DrawImage(image, current.margin, height * current.frame * (bCount - bI - 1));
                    else
                        g.DrawImage(image, current.margin + (gearWidth + current.margin) * (int)(bI / current.oneColumnCount), height * current.frame * (current.oneColumnCount - bI % current.oneColumnCount - 1));
                    image.Dispose();
                }
                bI = bCount - 1; // bI�� bCount�� �Ǵ� ���ÿ� ũ�ν� ������ ������ �ż� �� ����


                if (fumenReturnFileType == 1)
                {
                    // ���� ����
                    proceed1 = Proceedings.Save;
                    if (current.name == "SakamotoNeko(G)")
                    {
                        if (fumenPrintType == 1)
                            outputBitmap.Save($@"{fumenDirectory}\{fileId[i]} GUITAR.png");
                        else
                            outputBitmap.Resize($@"{fumenDirectory}\{fileId[i]} GUITAR.png", 0.3f);
                    }
                    else if (current.name == "SakamotoNeko(B)")
                    {
                        if (fumenPrintType == 1)
                            outputBitmap.Save($@"{fumenDirectory}\{fileId[i]} BASS.png");
                        else
                            outputBitmap.Resize($@"{fumenDirectory}\{fileId[i]} BASS.png", 0.3f);
                    }
                    else
                    {
                        if (fumenPrintType == 1)
                            outputBitmap.Resize($@"{fumenDirectory}\{fileId[i]}.png", 0.7f);
                        else
                            outputBitmap.Resize($@"{fumenDirectory}\{fileId[i]}.png", 1.0f);
                    }
                }
                else if (fumenReturnFileType == 2)
                {
                    // ���� �м�
                    proceed1 = Proceedings.Parse;
                    //Bitmap resizedBitmap = ImageHelper.ResizeBitmap(outputBitmap, 1.0f, InterpolationMode.HighQualityBicubic);
                    //FumenParse fumenParse = new FumenParse(resizedBitmap);
                    FumenParse fumenParse = new FumenParse(outputBitmap);
                    List<Path> paths = fumenParse.Parse();

                    // Path���� ������ �߰ߵ� => ���������� ���
                    if (paths == null)
                    {
                        MessageBox.Show("���� �߰�!");
                        return;
                    }

                    // ���� ����
                    proceed1 = Proceedings.Save;
                    WriteTextFile(paths, $@"{fumenDirectory}\{fileId[i]}.txt");
                }

                outputBitmap.Dispose();

                proceed1 = Proceedings.Complete;
            }

            // ��� �۾� �Ϸ�
            complete = true;
            Delegater.EnableSet(makeButton, true);

            // "�Ϸ��ϰ� �����ϱ�" üũ�Ǿ� ������ ����
            if (exitCheckBox.Checked)
                Application.Exit();
        }

        public void WriteTextFile(List<Path> paths, string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.WriteLine($"CFG,{480},{(int)paths.Max(p => p.timing) + 100}");
                    foreach (Path path in paths)
                    {
                        switch (path.type)
                        {
                            case Path.Type.BigPhrase:
                                writer.WriteLine($"BP,{path.lineNum},{path.timing}");
                                break;
                            case Path.Type.SmallPhrase:
                                writer.WriteLine($"SP,{path.lineNum},{path.timing}");
                                break;
                            case Path.Type.Note:
                                if (path.holdLength != 0) // Ȧ���Ʈ
                                    writer.WriteLine($"NO,{path.lineNum},{path.timing},{path.noteNum},{path.holdLength}");
                                else
                                    writer.WriteLine($"NO,{path.lineNum},{path.timing},{path.noteNum}");
                                break;
                        }
                    }
                    writer.Flush();
                }
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mainContextMenuStrip.Show(new Point(MousePosition.X + 2, MousePosition.Y + 2));
            }
            else
            {
                mainContextMenuStrip.Hide();
            }
        }

        private void ����iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GITADORA Music Score Maker(GDMSM)");
        }

        private void ����ƮSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://��Ÿ�����");
        }

        private void SelectFumenCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                for (int i = 1; i < selectFumenCheckedListBox.Items.Count; i++)
                    selectFumenCheckedListBox.SetItemCheckState(i, e.CurrentValue == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
            }
        }

        private void GearStartButtonLeft_Click(object sender, EventArgs e)
        {
            gearStart -= 2;
        }

        private void GearStartButtonRight_Click(object sender, EventArgs e)
        {
            gearStart += 2;
        }

        private void ChangeScreenShotButton_Click(object sender, EventArgs e)
        {
            current.scI += 15;
        }

        private void GearWidthButtonWiden_Click(object sender, EventArgs e)
        {
            gearWidth += 2;
        }

        private void GearWidthButtonNarrow_Click(object sender, EventArgs e)
        {
            gearWidth -= 2;
        }

        private void WorkFolderButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(videoDirectory);
            System.Diagnostics.Process.Start(fumenDirectory);
            System.Diagnostics.Process.Start(screenShotDirectory);
        }

        private void PlayerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            current = player[playerListBox.SelectedIndex];
        }

        private void SpeedButtonClick(object sender, EventArgs e)
        {
            height = current.heights[int.Parse((sender as Button).Name.Substring((sender as Button).Name.Length - 2, 2)) / 5 - 1];
            gearStartCheck = false;
        }

        private void DeleteScreenShotButton_Click(object sender, EventArgs e)
        {
            FileInfo[] screenShotFiles = new DirectoryInfo(screenShotDirectory).GetFiles();
            foreach (FileInfo fi in screenShotFiles)
                fi.Delete();

            // "�Ϸ��ϰ� �����ϱ�" üũ�Ǿ� ������ ����
            if (exitCheckBox.Checked)
                Application.Exit();
        }

        private void textRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // �ؽ�Ʈ ����� �ݵ�� ���� 1�� ����
            if (textRadioButton.Checked)
            {
                lineORadioButton.Checked = true;
            }
        }
    }
}