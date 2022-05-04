using Gaten.Net.GameRule.GITADORA;

using Path = Gaten.Net.GameRule.GITADORA.Path;

namespace Gaten.GameTool.GITADORA.Dtx2Fumen
{
    public class FumenParse
    {
        public List<string> Data;
        public List<DtxObject> PhraseTable = new();
        public List<DtxObject> BpmTable = new();
        public List<DtxObject> NoteTable = new();

        List<Path> paths = new();
        List<Path> bpPaths = new();
        List<Path> spPaths = new();
        List<Path> noPaths = new();

        bool parseStart;
        bool phraseComplete;
        bool bpmComplete;

        const double StartBigPhraseTiming = 96.0;
        const double BigPhraseGap = 700.0;

        public FumenParse()
        {

        }

        public FumenParse(List<string> data)
        {
            Data = data;
        }

        public List<Path> Parse()
        {
            ParseToDTXObject2();

            MakePath();

            return paths;
        }

        public void ParseToDTXObject()
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].StartsWith("#AVIZZ"))
                {
                    parseStart = true;
                    continue;
                }

                if (parseStart)
                {
                    if (!phraseComplete)
                    {
                        if (Data[i].StartsWith("#BPM"))
                        {
                            phraseComplete = true;

                            string[] b = Data[i].Split(':');
                            BpmTable.Add(new DtxObject()
                            {
                                Num = b[0].Replace("#BPM", ""),
                                Value = b[1].Trim()
                            });
                        }
                        else if (Data[i].StartsWith("#"))
                        {
                            string[] p = Data[i].Split(':');
                            PhraseTable.Add(new DtxObject()
                            {
                                Num = p[0].Replace("#", ""),
                                Value = p[1].Trim()
                            });
                        }
                    }
                    else if (!bpmComplete)
                    {
                        if (Data[i].StartsWith("#BPM"))
                        {
                            string[] b = Data[i].Split(':');
                            BpmTable.Add(new DtxObject()
                            {
                                Num = b[0].Replace("#BPM", ""),
                                Value = b[1].Trim()
                            });
                        }
                        else if (Data[i].StartsWith("#"))
                        {
                            bpmComplete = true;

                            string[] n = Data[i].Split(':');
                            NoteTable.Add(new DtxObject()
                            {
                                Num = n[0].Replace("#", ""),
                                Value = n[1].Trim()
                            });
                        }
                    }
                    else if (Data[i].Length > 2)
                    {
                        string[] n = Data[i].Split(':');
                        NoteTable.Add(new DtxObject()
                        {
                            Num = n[0].Replace("#", ""),
                            Value = n[1].Trim()
                        });
                    }
                    else
                    {
                        break;
                    }
                }
            }

            List<string> nums = new List<string>();

            foreach (DtxObject obj in NoteTable)
            {
                nums.Add(obj.Num.Substring(3, 2));
            }

            nums = nums.Distinct().ToList();
        }

        public void ParseToDTXObject2()
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Contains("#00001"))
                {
                    parseStart = true;
                }

                if (parseStart)
                {
                    if (Data[i].Length < 2) break;

                    string[] n = Data[i].Split(':');

                    if (n[0].Substring(4, 2) == "02")
                    {
                        string[] p = Data[i].Split(':');
                        PhraseTable.Add(new DtxObject()
                        {
                            Num = p[0].Replace("#", ""),
                            Value = p[1].Trim()
                        });
                    }
                    else
                    {
                        NoteTable.Add(new DtxObject()
                        {
                            Num = n[0].Replace("#", ""),
                            Value = n[1].Trim()
                        });
                    }
                }
            }
        }

        public void MakePath()
        {
            MakePhrase();
            MakeNote();

            MergePath();
        }

        public void MakePhrase()
        {
            int bigPhraseCount = int.Parse(NoteTable[NoteTable.Count - 1].Num.Substring(0, 3));
            int smallPhraseCount = 4; // 기본 4박 (소절선 그을때는 3개만 긋는다)

            for (int i = 0; i < bigPhraseCount; i++)
            {
                bpPaths.Add(new Path()
                {
                    type = Path.Type.BigPhrase,
                    timing = GetBigPhraseTiming(i + 1)
                });

                List<DtxObject> changePhrase = PhraseTable.Where(p => p.Num.Equals($"{To3(i + 1)}02")).ToList();

                if (changePhrase.Count > 0)
                {
                    smallPhraseCount = (int)(double.Parse(changePhrase[0].Value) * 4);
                }

                for (int j = 1; j < smallPhraseCount; j++)
                {
                    spPaths.Add(new Path()
                    {
                        type = Path.Type.SmallPhrase,
                        timing = GetBigPhraseTiming(i + 1) + j * BigPhraseGap / smallPhraseCount
                    });
                }
            }

            bpPaths.Add(new Path()
            {
                type = Path.Type.BigPhrase,
                timing = GetBigPhraseTiming(bigPhraseCount + 1)
            });
        }

        public void MakeNote()
        {
            Dictionary<string, int> noteCodes = new Dictionary<string, int>()
            {
                { "1A", 1 },
                { "11", 2 },
                { "1B", 3 }, {"1C", 3 },
                { "12", 4 },
                { "14", 5 },
                { "13", 6 },
                { "15", 7 },
                { "17", 8 },
                { "16", 9 },
            };

            foreach (DtxObject obj in NoteTable)
            {
                int phraseNumber = int.Parse(obj.Num.Substring(0, 3));

                // 0번 마디는 노트가 아님
                if (phraseNumber == 0) continue;

                List<string> noteSymbols = new List<string>();

                // 두 글자씩 쪼개기
                for (int j = 0; j < obj.Value.Length; j += 2)
                    noteSymbols.Add(obj.Value.Substring(j, 2));

                double symbolGap = BigPhraseGap / noteSymbols.Count;

                // 노트 파싱
                for (int j = 0; j < noteSymbols.Count; j++)
                {
                    // "00"이 아니면 노트임
                    if (noteSymbols[j] != "00")
                    {
                        int value;
                        int noteNum = noteCodes.TryGetValue(obj.Num.Substring(3, 2), out value) ? value : 0;

                        if (noteNum != 0)
                        {
                            noPaths.Add(new Path()
                            {
                                type = Path.Type.Note,
                                timing = GetBigPhraseTiming(phraseNumber) + j * symbolGap,
                                noteNum = noteNum
                            });
                        }
                    }
                }
            }
        }

        public void MergePath()
        {
            paths.AddRange(bpPaths);
            paths.AddRange(spPaths);
            paths.AddRange(noPaths);
        }

        /// <summary>
        /// 정수를 3글자 문자열로 변환
        /// 37 => "037"
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string To3(int num)
        {
            return num < 10 ? $"00{num}" : num < 100 ? $"0{num}" : $"{num}";
        }

        /// <summary>
        /// 마디 번호를 넣으면 대절선 시작타이밍 반환
        /// 1 => 96.0
        /// </summary>
        /// <param name="phraseNumber"></param>
        /// <returns></returns>
        public double GetBigPhraseTiming(int phraseNumber)
        {
            return StartBigPhraseTiming + (phraseNumber - 1) * BigPhraseGap;
        }
    }
}
