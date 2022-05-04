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
         * NOWNIZ 도라 프레임3 줄48 마진20 720p 29.97f
         * GM-JAYO 기타/베이스 프레임8 줄16 마진20 720p 30f
         */

        /* * * * * * * *
            영상 & 게임
         * * * * * * * */
        // 몇프레임마다 이미지를 붙힐건지
        // *도라
        // 1~3 - Zero Noize
        // 4 - 빔 거의 안보임
        // 5~7 - 빔 약간 보임
        // 8 - 빔이 조금 많이 보임
        // 9 - 판정약간보이고, 빔 많이보임
        // 10 - 판정 잘 보임
        // *기타
        // 8
        //int frame;

        /* * * * * * * *
            스크린샷
         * * * * * * * */

        public enum Mode { Drum, Guitar, Bass };

        public enum Version { gd, odtbtbr, mat, exc }

        //readonly string[] VERSIONS = { "gd", "odtbtbr", "mat", "exc" };
        //readonly string[] MODES = { Modes.Drum, Modes.Guitar, Modes.Bass };
        //readonly int[] GEAR_STARTS_DRUM = { 302, 304, 296 };
        //readonly int[] GEAR_WIDTHS_DRUM = { 510, 512, 518 };
        //readonly int[] GEAR_STARTS_GUITAR = { 524, 600, 600 };
        //readonly int[] GEAR_WIDTHS_GUITAR = { 235, 300, 300 };
        // 배속 표시 좌표 [0]-drum, [1]-guitar, [2]-bass
        //readonly int[] SPEED_STARTS_X = { 800, 510, 510 };
        //readonly int[] SPEED_STARTS_Y = { 510, 20, 20 };
        // 버전
        private Version version;

        // 모드 인덱스
        //int modeI;
        // 기어 시작점
        private int gearStart;

        // 기어 폭
        private int gearWidth;

        // 스크린샷 디렉토리
        private string screenShotDirectory;

        // 스크린샷 파일
        private FileInfo[] files;

        // 이미지 개수
        private int bCount;

        // 한 프레임의 비트맵의 높이
        /* BPM 배속 height
         * 250 4.0 27
         * 144 5.5 37
         * 250 5.5 37
         */
        private int height;

        // 배속별 height
        // 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5, 6.0, 6.5, 7.0, 7.5
        // 0, 1, 2, 3, 4, 5
        // /0.5 -1
        // 노트 1개가 2개로 보이면 줄이고
        // 노트가 잘려보이면 늘리고
        //readonly int[] current.heights = { 3, 7, 10, 14, 17, 21, 24, 27, 30, 34, 37, 41, 44, 47, 50 };
        //readonly int[] current.heights = { 2, 4, 6, 9, 11, 13, 15, 17, 19, 22, 24, 26, 28, 30, 32 };
        // 시작 이미지 인덱스
        private int startScreenShotIndex;

        // 끝 이미지 인덱스
        private int endScreenShotIndex;

        // 생성해야할 보면 그룹화
        private List<string> fileId = new List<string>();

        /* * * * * * * *
             비트맵
         * * * * * * * */

        // 한 줄에 몇 개의 프레임을 붙힐건지
        //int oneColumnCount;
        // 줄과 줄 사이의 간격
        //int margin;
        // 줄 개수
        private int cCount;

        /* * * * * * * *
             시스템
         * * * * * * * */

        // 현재 이미지 인덱스
        private int bI;

        // 현재 처리중인 보면 인덱스
        private int fI;

        // 보면 생성 완료 플래그
        private bool complete;

        // 기어 시작 좌표 체크 플래그
        private bool gearStartCheck;

        // 체크 시 보여줄 스크린샷 인덱스
        //int scI = 200;
        // 현재 처리작업
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
            // 플레이어 초기화
            player[0] = new Player("NOWNIZ", Mode.Drum, 3, 48, 20, new int[] { 3, 7, 10, 14, 17, 21, 24, 27, 30, 34, 37, 41, 44, 47, 50 }, new int[] { 302, 304, 296 }, new int[] { 510, 512, 518 }, 800, 630, 0, 500, 300, 20, 20);
            player[1] = new Player("GM-JAYO", Mode.Guitar, 8, 16, 20, new int[] { 2, 4, 6, 9, 11, 13, 15, 17, 19, 22, 24, 26, 28, 30, 32 }, new int[] { 524, 524, 524 }, new int[] { 235, 235, 235 }, 510, 20, 620 - 300, 300, 100, 3, 20, 620);
            player[2] = new Player("SakamotoNeko(G)", Mode.Guitar, 8, 16, 20, new int[] { 2, 4, 6, 9, 11, 13, 15, 17, 19, 22, 24, 26, 28, 30, 32 }, new int[] { 188, 188, 188 }, new int[] { 235, 235, 235 }, 510, 20, 660 - 300, 300, 100, 20, 30, 660); // speed x6.0
            player[3] = new Player("SakamotoNeko(B)", Mode.Guitar, 8, 16, 20, new int[] { 2, 4, 6, 9, 11, 13, 15, 17, 19, 22, 24, 26, 28, 30, 32 }, new int[] { 856, 856, 856 }, new int[] { 235, 235, 235 }, 510, 20, 660 - 300, 300, 100, 20, 30, 660); // speed x6.0
            player[4] = new Player("DTX", Mode.Drum, 3, 48, 20, new int[] { 0, 3, 7, 10, 14, 17, 21, 23, 27, 30, 34, 37, 41, 44, 47 }, new int[] { 302, 304, 296 }, new int[] { 510, 512, 518 }, 800, 630, 0, 500, 300, 20, 20);
            foreach (Player p in player)
                playerListBox.Items.Add(p.name);

            // 플레이어 deafult
            playerListBox.SelectedIndex = 4;

            // 디렉토리 로드
            using (FileStream fs = new FileStream("dir.ini", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    screenShotDirectory = sr.ReadLine().Split('\"')[1];
                    fumenDirectory = sr.ReadLine().Split('\"')[1];
                    videoDirectory = sr.ReadLine().Split('\"')[1];
                }
            }

            // 보면 제목 grouping
            files = new DirectoryInfo(screenShotDirectory).GetFiles("*.bmp");
            foreach (FileInfo fi in files)
            {
                string fileIdStr = fi.Name.Substring(0, fi.Name.Length - 19);
                if (!fileId.Contains(fileIdStr))
                    fileId.Add(fileIdStr);
            }

            // CheckedListBox에 보면 리스트 추가
            int ip = 0;
            selectFumenCheckedListBox.Items.Add("전체 선택");
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
            // 처음으로 검정색 화면 나오는 인덱스 찾기
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

            // 처음으로 10프레임 연속 검정색 화면 나오는 인덱스 찾기
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

            // bCount / cCount 재계산
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

                // 가장 높은 일치도가 그 버전이 됨
                if (max < sameDegree)
                {
                    max = sameDegree;
                    maxI = i;
                }
            }

            // 버전 찾기 완료
            switch (maxI)
            {
                case 0: version = Version.gd; break;
                case 1: version = Version.odtbtbr; break;
                case 2: version = Version.mat; break;
                case 3: version = Version.exc; break;
            }

            // 버전에 맞게 기어 시작점, 넓이 설정
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

            // gear와 speeed를 체크 하기 위해서 미리보기 이미지를 보여줌
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

                // 가장 높은 일치도가 그 속도가 됨
                if (max < sameDegree)
                {
                    max = sameDegree;
                    maxI = i;
                }
            }

            // 속도에 맞게 height 설정
            height = heights[int.Parse(speedImageFiles[maxI].Name.Split('.')[0].Replace(VERSIONS[versionI], "")) / 5 - 1];
        }*/

        private void MakeButton_Click(object sender, EventArgs e)
        {
            Delegater.EnableSet(makeButton, false);
            complete = false;

            Thread viewWorker = new Thread(new ThreadStart(Proceed));
            makeWorker1 = new Thread(new ThreadStart(MakeFumen1));

            // 현재 작업상황 출력
            viewWorker.Start();

            // 보면 제작 시작
            makeWorker1.Start();
        }

        private void Proceed()
        {
            while (!complete)
            {
                switch (proceed1)
                {
                    case Proceedings.LoadImage:
                        Delegater.TextSet(proceedLabel, "이미지 불러오는 중..");
                        break;

                    case Proceedings.VersionCheck:
                        Delegater.TextSet(proceedLabel, "버전 체크하는 중..");
                        break;

                    case Proceedings.Trim:
                        Delegater.TextSet(proceedLabel, "불필요한 이미지 제거하는 중..");
                        break;

                    case Proceedings.Create:
                        Delegater.TextSet(proceedLabel, "만드는 중..");
                        break;

                    case Proceedings.Merge:
                        //'모두 선택'이 체크되어있으면 체크 개수 -1
                        int allCheck = selectFumenCheckedListBox.GetItemCheckState(0) == CheckState.Checked ? 1 : 0;

                        Delegater.ProgressBarSetValue(makeProgressBar, bI + 1);
                        Delegater.TextSet(mergeFileCountLabel, $"{fI + 1} / {selectFumenCheckedListBox.CheckedItems.Count - allCheck}");
                        Delegater.TextSet(mergeLabel, string.Format("{0} / {1} ({2:0.0}%)", bI + 1, bCount, Math.Round((double)(bI + 1) / bCount * 100.0, 1)));
                        Delegater.TextSet(fileNameLabel, files[startScreenShotIndex + bI].Name.Substring(files[startScreenShotIndex + bI].Name.Length - 14));
                        Delegater.TextSet(proceedLabel, "합치는 중..");
                        break;

                    case Proceedings.Parse:
                        Delegater.TextSet(proceedLabel, "분석하는 중..");
                        break;

                    case Proceedings.Save:
                        Delegater.TextSet(proceedLabel, "저장하는 중..");
                        break;

                    case Proceedings.Complete:
                        Delegater.TextSet(proceedLabel, "완료.");
                        break;
                }
            }
        }

        /*
        [Obsolete]
        private void MakeFumen2()
        {
            // 메인 스레드가 merge작업을 할 때까지 대기
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
            // 메인 스레드가 merge작업을 할 때까지 대기
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
            // 메인 스레드가 merge작업을 할 때까지 대기
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
            // 보면 출력 타입
            // 1 - One Line
            // 2 - Multi Line
            int fumenPrintType = lineORadioButton.Checked ? 1 : 2;

            // 보면 반환파일 타입
            // 1 - ImageFile
            // 2 - ParsedTextFile(fumenPrintType을 무조건 1로 설정해야함)
            int fumenReturnFileType = imageRadioButton.Checked ? 1 : 2;

            // 체크한 보면 중 몇번째 보면을 처리하고 있는지
            int fp = 0;

            for (int i = 0; i < fileId.Count; i++)
            {
                if (selectFumenCheckedListBox.GetItemCheckState(i + 1) == CheckState.Unchecked) continue;
                fI = fp++;
                complete = false;

                // 현재 처리 보면 선택
                Delegater.ListBoxSelect(selectFumenCheckedListBox, i + 1);

                // 그룹별로 보면 생성
                proceed1 = Proceedings.LoadImage;
                files = new DirectoryInfo(screenShotDirectory).GetFiles($"{fileId[i]}*.bmp");
                bCount = files.Length;

                // 버전 체크 후 기어 정보 입력
                proceed1 = Proceedings.VersionCheck;
                CheckVersion();

                // 스크린샷의 시작과 끝 정리
                proceed1 = Proceedings.Trim;
                if (current.mode == Mode.Drum)
                    TrimScreenShot(0);
                else
                    TrimScreenShot(43);

                // 보면 생성
                proceed1 = Proceedings.Create;
                Bitmap outputBitmap = fumenPrintType == 1 ?
                new Bitmap(current.margin * 2 + gearWidth, height * current.frame * bCount) :
                new Bitmap(current.margin + (gearWidth + current.margin) * cCount, height * current.frame * current.oneColumnCount);
                g = Graphics.FromImage(outputBitmap);

                // 스크린샷 붙이기
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
                bI = bCount - 1; // bI가 bCount가 되는 동시에 크로스 스레딩 참조가 돼서 값 고정


                if (fumenReturnFileType == 1)
                {
                    // 보면 저장
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
                    // 보면 분석
                    proceed1 = Proceedings.Parse;
                    //Bitmap resizedBitmap = ImageHelper.ResizeBitmap(outputBitmap, 1.0f, InterpolationMode.HighQualityBicubic);
                    //FumenParse fumenParse = new FumenParse(resizedBitmap);
                    FumenParse fumenParse = new FumenParse(outputBitmap);
                    List<Path> paths = fumenParse.Parse();

                    // Path에서 음수가 발견됨 => 비정상적인 경우
                    if (paths == null)
                    {
                        MessageBox.Show("음수 발견!");
                        return;
                    }

                    // 보면 저장
                    proceed1 = Proceedings.Save;
                    WriteTextFile(paths, $@"{fumenDirectory}\{fileId[i]}.txt");
                }

                outputBitmap.Dispose();

                proceed1 = Proceedings.Complete;
            }

            // 모든 작업 완료
            complete = true;
            Delegater.EnableSet(makeButton, true);

            // "완료하고 종료하기" 체크되어 있으면 종료
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
                                if (path.holdLength != 0) // 홀드노트
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

        private void 정보iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GITADORA Music Score Maker(GDMSM)");
        }

        private void 사이트SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://기타도라넷");
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

            // "완료하고 종료하기" 체크되어 있으면 종료
            if (exitCheckBox.Checked)
                Application.Exit();
        }

        private void textRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // 텍스트 출력은 반드시 라인 1로 설정
            if (textRadioButton.Checked)
            {
                lineORadioButton.Checked = true;
            }
        }
    }
}