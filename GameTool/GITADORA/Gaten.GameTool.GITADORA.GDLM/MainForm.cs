using Gaten.Net.GameRule.GITADORA;

using System.Text;

using Path = Gaten.Net.GameRule.GITADORA.Path;

namespace Gaten.GameTool.GITADORA.GDLM
{
    public partial class MainForm : Form
    {
        private string[] files;
        public List<Path> paths;
        public Bitmap bitmap;
        public int fumenWidth, fumenHeight;
        public double bitmapMultiplier = 0.5;
        public bool flip;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            files = (string[])e.Data.GetData(DataFormats.FileDrop);

            paths = LoadFumenTxtFile(files[0]);

            ReDisplay();
        }

        public List<Path> LoadFumenTxtFile(string fileName)
        {
            List<Path> paths = new List<Path>();

            bool drum = fileName.EndsWith("db.txt") || fileName.EndsWith("da.txt") || fileName.EndsWith("de.txt") || fileName.EndsWith("dm.txt");

            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string cfg = reader.ReadLine();
                    string[] cfgData = cfg.Split(',');
                    fumenWidth = int.Parse(cfgData[1]);
                    fumenHeight = int.Parse(cfgData[2]);

                    try
                    {
                        while (true)
                        {
                            string obj = reader.ReadLine();
                            string[] data = obj.Split(',');
                            switch (data[0])
                            {
                                case "BP":
                                    if (!ignoreLineCheckBox.Checked)
                                    {
                                        paths.Add(new Path()
                                        {
                                            type = Path.Type.BigPhrase,
                                            lineNum = int.Parse(data[1]),
                                            timing = double.Parse(data[2])
                                        });
                                    }
                                    break;
                                case "SP":
                                    if (!ignoreLineCheckBox.Checked)
                                    {
                                        paths.Add(new Path()
                                        {
                                            type = Path.Type.SmallPhrase,
                                            lineNum = int.Parse(data[1]),
                                            timing = double.Parse(data[2])
                                        });
                                    }
                                    break;
                                case "NO":
                                    paths.Add(new Path()
                                    {
                                        type = Path.Type.Note,
                                        lineNum = int.Parse(data[1]),
                                        timing = double.Parse(data[2]),
                                        noteNum = int.Parse(data[3]),
                                        holdLength = !drum && int.Parse(data[3]) >= 6 && int.Parse(data[3]) <= 10 ? double.Parse(data[4]) : 0
                                    });
                                    break;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }

            return paths;
        }

        public void DrawFumen()
        {
            bitmap = new Bitmap(fumenWidth + 120, (int)(fumenHeight * bitmapMultiplier));
            Brush[] b =
            {
                new SolidBrush(Color.FromArgb(246,79,141)),
                new SolidBrush(Color.FromArgb(65,156,214)),
                new SolidBrush(Color.FromArgb(230,87,143)),
                new SolidBrush(Color.FromArgb(249,220,113)),
                new SolidBrush(Color.FromArgb(132,241,142)),
                new SolidBrush(Color.FromArgb(154,138,238)),
                new SolidBrush(Color.FromArgb(234,96,96)),
                new SolidBrush(Color.FromArgb(231,168,123)),
                new SolidBrush(Color.FromArgb(94,166,224))
            };
            Brush bigPhraseb = new SolidBrush(Color.FromArgb(222, 222, 222));
            Brush smallPhraseb = new SolidBrush(Color.FromArgb(66, 66, 66));
            int[] width = { 65, 46, 50, 54, 47, 61, 46, 46, 64 };
            int[] xpos = { 0, 65, 111, 161, 215, 262, 323, 369, 415, 479 };
            int noteHeight = 10;
            int bigPhraseHeight = 4;
            int smallPhraseHeight = 2;

            Font font = new Font("¸¼Àº °íµñ", 40);
            Brush fontb = Brushes.White;
            int phraseCount = 0;

            using (var g = Graphics.FromImage(bitmap))
            {
                foreach (Path p in paths)
                {
                    int index = p.noteNum - 1;

                    switch (p.type)
                    {
                        case Path.Type.BigPhrase:
                            g.FillRectangle(bigPhraseb, new Rectangle(0, (int)(p.timing * bitmapMultiplier) - bigPhraseHeight / 2, 480, bigPhraseHeight));
                            g.DrawString(phraseCount++.ToString(), font, fontb, 490, (int)(p.timing * bitmapMultiplier) - 35);
                            break;
                        case Path.Type.SmallPhrase:
                            g.FillRectangle(smallPhraseb, new Rectangle(0, (int)(p.timing * bitmapMultiplier) - smallPhraseHeight / 2, 480, smallPhraseHeight));
                            break;
                        case Path.Type.Note:
                            g.FillRectangle(b[index], new Rectangle(xpos[index], (int)(p.timing * bitmapMultiplier) - noteHeight / 2, width[index], noteHeight));
                            break;
                    }
                }
            }

            if (flip)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            }

            Panel mainPanel = new Panel();
            mainPanel.Size = new Size(bitmap.Width, bitmap.Height);
            mainPanel.BackgroundImage = bitmap;
            fumenPanel.Controls.Add(mainPanel);

        }

        private void createPhraseButton_Click(object sender, EventArgs e)
        {
            //List<Path> ppaths = new List<Path>(); // Phrase Paths
            int phraseCount = int.Parse(phraseTextBox.Text);

            // big phrase
            for (double i = 96; i < fumenHeight; i += 700)
            {
                paths.Add(new Path()
                {
                    type = Path.Type.BigPhrase,
                    lineNum = 0,
                    timing = i
                });

                // small phrase
                for (int j = 1; j < phraseCount; j++)
                {
                    paths.Add(new Path()
                    {
                        type = Path.Type.SmallPhrase,
                        lineNum = 0,
                        timing = i + 700.0 * j / phraseCount
                    });
                }
            }

            Sort();
            ReDisplay();
        }

        private void zoomNumeric_ValueChanged(object sender, EventArgs e)
        {
            bitmapMultiplier = (double)zoomNumeric.Value;

            ReDisplay();
        }

        private void removePhraseButton_Click(object sender, EventArgs e)
        {
            paths.RemoveAll(p => p.type.Equals(Path.Type.BigPhrase));
            paths.RemoveAll(p => p.type.Equals(Path.Type.SmallPhrase));

            ReDisplay();
        }

        private void flipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            flip = flipCheckBox.Checked;

            ReDisplay();
        }

        private void replacePhraseButton_Click(object sender, EventArgs e)
        {
            int phraseNumber = int.Parse(phraseNumberTextBox.Text);
            int phraseCount = int.Parse(phraseDivisionTextBox.Text);

            paths.RemoveAll(p => p.type.Equals(Path.Type.SmallPhrase) && p.timing > (96 + 700 * phraseNumber) && p.timing < (96 + 700 * (phraseNumber + 1)));

            for (int j = 1; j < phraseCount; j++)
            {
                paths.Add(new Path()
                {
                    type = Path.Type.SmallPhrase,
                    lineNum = 0,
                    timing = 96 + 700.0 * (phraseNumber + (double)j / phraseCount)
                });
            }

            Sort();
            ReDisplay();
        }

        private void ReDisplay()
        {
            fumenPanel.Controls.Clear();
            DrawFumen();
        }

        private void addPhraseButton_Click(object sender, EventArgs e)
        {
            int phraseNumber = int.Parse(phraseNumberTextBox.Text);
            int phrasePosition = int.Parse(phrasePositionTextBox.Text);

            paths.Add(new Path()
            {
                type = Path.Type.SmallPhrase,
                lineNum = 0,
                timing = 96 + 700.0 * phraseNumber + phrasePosition
            });

            Sort();
            ReDisplay();
        }

        private void Sort()
        {
            List<Path> sortedPaths = new List<Path>();

            var bpPaths = paths.Where(p => p.type.Equals(Path.Type.BigPhrase)).ToList();
            bpPaths.Sort(new PathComparer());
            sortedPaths.AddRange(bpPaths);

            var spPaths = paths.Where(p => p.type.Equals(Path.Type.SmallPhrase)).ToList();
            spPaths.Sort(new PathComparer());
            sortedPaths.AddRange(spPaths);

            var noPaths = paths.Where(p => p.type.Equals(Path.Type.Note)).ToList();
            noPaths.Sort(new PathComparer());
            sortedPaths.AddRange(noPaths);

            paths = sortedPaths;
        }

        private void saveClipboardButton_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            foreach (Path path in paths)
            {
                switch (path.type)
                {
                    case Path.Type.BigPhrase:
                        str.AppendLine($"BP,{path.lineNum},{path.timing}");
                        break;
                    case Path.Type.SmallPhrase:
                        str.AppendLine($"SP,{path.lineNum},{path.timing}");
                        break;
                }
            }

            Clipboard.SetText(str.ToString());
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            string fileName = files[0].Replace("db.txt", "line.txt").Replace("da.txt", "line.txt").Replace("de.txt", "line.txt").Replace("dm.txt", "line.txt");

            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
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
                        }
                    }
                    writer.Flush();
                }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            new HelpForm().ShowDialog();
        }
    }
}