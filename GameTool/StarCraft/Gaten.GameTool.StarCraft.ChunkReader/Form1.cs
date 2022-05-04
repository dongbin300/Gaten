using System.Data;
using System.Text;

using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.GameTool.StarCraft.ChunkReader
{
    public partial class Form1 : Form
    {
        public byte[] bytes;
        public string str;

        public Form1()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ChunkListBox.Items.Clear();
            ReadChkFile();
        }

        public void ReadChkFile()
        {
            DataTable dt = new DataTable();

            try
            {
                using (FileStream stream = new FileStream("out.chk", FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(stream, Encoding.Default))
                    {
                        //dt.Columns.Add("Offset", typeof(string));
                        dt.Columns.Add("Hex", typeof(string));
                        dt.Columns.Add("Value", typeof(string));
                        dt.Columns.Add("Description", typeof(string));

                        while (true)
                        {
                            var chunkNameBytes = reader.ReadBytes(4);
                            var chuckNameString = GetHexString(chunkNameBytes);
                            var chunkNameValue = GetInt32(chunkNameBytes);
                            var chunkNameASCII = GetValue(chunkNameBytes);
                            dt.Rows.Add(new string[] { chuckNameString, chunkNameValue.ToString(), chunkNameASCII });

                            ChunkListBox.Items.Add(chunkNameASCII);

                            var chunkSizeBytes = reader.ReadBytes(4);
                            var chunkSizeString = GetHexString(chunkSizeBytes);
                            var chunkSizeValue = GetInt32(chunkSizeBytes);
                            var chunkSizeASCII = GetValue(chunkSizeBytes);
                            dt.Rows.Add(new string[] { chunkSizeString, chunkSizeValue.ToString(), chunkSizeASCII });

                            var chunkDataBytes = reader.ReadBytes(chunkSizeValue);
                            var chunkDataString = GetHexString(chunkDataBytes);

                            int p = 0;
                            switch (chunkNameASCII)
                            {
                                case "VER ":
                                    dt.Rows.Add(chunkDataString, GetInt16(chunkDataBytes).ToString(), "버전");
                                    break;
                                case "TYPE":
                                    dt.Rows.Add(chunkDataString, GetValue(chunkDataBytes).ToString(), "시나리오 종류");
                                    break;
                                case "IVE2":
                                    dt.Rows.Add(chunkDataString, GetInt16(chunkDataBytes).ToString(), "버전");
                                    break;
                                case "VCOD":
                                    dt.Rows.Add(chunkDataString, "(Seed+Hash)", "시드해시값");
                                    break;
                                case "IOWN":
                                    for (int i = 0; i < 12; i++)
                                    {
                                        dt.Rows.Add(chunkDataString.Substring(3 * i, 3), chunkDataBytes[i], $"플레이어{i + 1}");
                                    }
                                    break;
                                case "OWNR":
                                    for (int i = 0; i < 12; i++)
                                    {
                                        dt.Rows.Add(chunkDataString.Substring(3 * i, 3), chunkDataBytes[i], $"플레이어{i + 1}");
                                    }
                                    break;
                                case "SIDE":
                                    for (int i = 0; i < 12; i++)
                                    {
                                        dt.Rows.Add(chunkDataString.Substring(3 * i, 3), chunkDataBytes[i], $"플레이어{i + 1}");
                                    }
                                    break;
                                case "COLR":
                                    for (int i = 0; i < 8; i++)
                                    {
                                        dt.Rows.Add(chunkDataString.Substring(3 * i, 3), chunkDataBytes[i], $"플레이어{i + 1}");
                                    }
                                    break;
                                case "ERA ":
                                    dt.Rows.Add(chunkDataString, GetInt16(chunkDataBytes), "타일셋");
                                    break;
                                case "DIM ":
                                    var a = GetInt16(chunkDataBytes, p);
                                    dt.Rows.Add(GetHexString(a), a, "맵 가로 크기");
                                    p += 2;
                                    a = GetInt16(chunkDataBytes, p);
                                    dt.Rows.Add(GetHexString(a), a, "맵 세로 크기");
                                    break;
                                case "MTXM":
                                    break;
                                case "TILE":
                                    break;
                                case "ISOM":
                                    break;
                                case "UNIT":
                                    break;
                                case "PUNI":
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 228; j++)
                                        {
                                            var b = chunkDataBytes[p + 228 * i + j];
                                            dt.Rows.Add(GetHexString(b), b, $"플레이어{i + 1},생산제한,{Unit.IdString[j]}");
                                        }
                                    }
                                    p += 12 * 228;
                                    for (int j = 0; j < 228; j++)
                                    {
                                        var b = chunkDataBytes[p + j];
                                        dt.Rows.Add(GetHexString(b), b, $"디폴트생산제한,{Unit.IdString[j]}");
                                    }
                                    p += 228;
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 228; j++)
                                        {
                                            var b = chunkDataBytes[p + 228 * i + j];
                                            dt.Rows.Add(GetHexString(b), b, $"플레이어{i + 1},디폴트설정,{Unit.IdString[j]}");
                                        }
                                    }
                                    break;
                                case "UNIx": // UNIS
                                    for (int i = 0; i < 228; i++)
                                    {
                                        var b = chunkDataBytes[p + i];
                                        dt.Rows.Add(GetHexString(b), b, $"디폴트설정,{Unit.IdString[i]}");
                                    }
                                    p += 228;
                                    for (int i = 0; i < 228; i++)
                                    {
                                        var b = GetInt32(chunkDataBytes, p + 4 * i);
                                        dt.Rows.Add(GetHexString(b), b / 256, $"HP,{Unit.IdString[i]}");
                                    }
                                    p += 4 * 228;
                                    for (int i = 0; i < 228; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"쉴드,{Unit.IdString[i]}");
                                    }
                                    p += 2 * 228;
                                    for (int i = 0; i < 228; i++)
                                    {
                                        var b = chunkDataBytes[p + i];
                                        dt.Rows.Add(GetHexString(b), b, $"방어력,{Unit.IdString[i]}");
                                    }
                                    p += 228;
                                    for (int i = 0; i < 228; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"생산시간,{Unit.IdString[i]}");
                                    }
                                    p += 2 * 228;
                                    for (int i = 0; i < 228; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"미네랄,{Unit.IdString[i]}");
                                    }
                                    p += 2 * 228;
                                    for (int i = 0; i < 228; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"가스,{Unit.IdString[i]}");
                                    }
                                    p += 2 * 228;
                                    for (int i = 0; i < 228; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"스트링번호,{Unit.IdString[i]}");
                                    }
                                    p += 2 * 228;
                                    for (int i = 0; i < 130; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"무기공격력,{Weapon.IdString[i]}");
                                    }
                                    p += 2 * 130;
                                    for (int i = 0; i < 130; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"무기공격력+,{Weapon.IdString[i]}");
                                    }
                                    p += 2 * 130;
                                    break;
                                case "PUPx": // UPGR
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 61; j++)
                                        {
                                            var b = chunkDataBytes[p + 61 * i + j];
                                            dt.Rows.Add(GetHexString(b), b, $"플레이어{i + 1},Max레벨,{Upgrade.IdString[j]}");
                                        }
                                    }
                                    p += 12 * 61;
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 61; j++)
                                        {
                                            var b = chunkDataBytes[p + 61 * i + j];
                                            dt.Rows.Add(GetHexString(b), b, $"플레이어{i + 1},Start레벨,{Upgrade.IdString[j]}");
                                        }
                                    }
                                    p += 12 * 61;
                                    for (int i = 0; i < 61; i++)
                                    {
                                        var b = chunkDataBytes[p + i];
                                        dt.Rows.Add(GetHexString(b), b, $"Global Max레벨,{Upgrade.IdString[i]}");
                                    }
                                    p += 61;
                                    for (int i = 0; i < 61; i++)
                                    {
                                        var b = chunkDataBytes[p + i];
                                        dt.Rows.Add(GetHexString(b), b, $"Global Start레벨,{Upgrade.IdString[i]}");
                                    }
                                    p += 61;
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 61; j++)
                                        {
                                            var b = chunkDataBytes[p + 61 * i + j];
                                            dt.Rows.Add(GetHexString(b), b, $"플레이어{i + 1},디폴트설정,{Upgrade.IdString[j]}");
                                        }
                                    }
                                    p += 12 * 61;
                                    break;
                                case "UPGx":
                                    for (int i = 0; i < 61; i++)
                                    {
                                        var b = chunkDataBytes[p + i];
                                        dt.Rows.Add(GetHexString(b), b, $"디폴트설정,{Upgrade.IdString[i]}");
                                    }
                                    var b0 = chunkDataBytes[p + 61];
                                    dt.Rows.Add(GetHexString(b0), b0, $"[사용안함]");
                                    p += 62; // 1바이트는 사용안함
                                    for (int i = 0; i < 61; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"미네랄,{Upgrade.IdString[i]}");
                                    }
                                    p += 2 * 61;
                                    for (int i = 0; i < 61; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"미네랄+,{Upgrade.IdString[i]}");
                                    }
                                    p += 2 * 61;
                                    for (int i = 0; i < 61; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"가스,{Upgrade.IdString[i]}");
                                    }
                                    p += 2 * 61;
                                    for (int i = 0; i < 61; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"가스+,{Upgrade.IdString[i]}");
                                    }
                                    p += 2 * 61;
                                    for (int i = 0; i < 61; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"시간,{Upgrade.IdString[i]}");
                                    }
                                    p += 2 * 61;
                                    for (int i = 0; i < 61; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"시간+,{Upgrade.IdString[i]}");
                                    }
                                    p += 2 * 61;
                                    break;
                                case "DD2 ":
                                    break;
                                case "THG2":
                                    break;
                                case "MASK":
                                    break;
                                case "MRGN":
                                    for (int i = 0; i < 255; i++)
                                    {
                                        var b = GetInt32(chunkDataBytes, 20 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"로케이션{i + 1},X1");
                                        b = GetInt32(chunkDataBytes, 20 * i + 4);
                                        dt.Rows.Add(GetHexString(b), b, $"로케이션{i + 1},Y1");
                                        b = GetInt32(chunkDataBytes, 20 * i + 8);
                                        dt.Rows.Add(GetHexString(b), b, $"로케이션{i + 1},X2");
                                        b = GetInt32(chunkDataBytes, 20 * i + 12);
                                        dt.Rows.Add(GetHexString(b), b, $"로케이션{i + 1},Y2");
                                        var c = GetInt16(chunkDataBytes, 20 * i + 16);
                                        dt.Rows.Add(GetHexString(c), c, $"로케이션{i + 1},스트링번호");
                                        c = GetInt16(chunkDataBytes, 20 * i + 18);
                                        dt.Rows.Add(GetHexString(c), c, $"로케이션{i + 1},Elevation");
                                    }
                                    break;
                                case "STRx": // STR
                                    var b1 = GetInt32(chunkDataBytes);
                                    dt.Rows.Add(GetHexString(b1), b1, $"스트링개수");
                                    p += 4;
                                    for (int i = 0; i < 1024; i++)
                                    {
                                        var b = GetInt32(chunkDataBytes, p + 4 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"스트링{i + 1},오프셋");

                                        if (b != 4100)
                                        {
                                            string str = GetStarcraftString(chunkDataBytes, b);
                                            dt.Rows.Add(GetHexString(str), str, $"스트링{i + 1}");
                                        }
                                    }
                                    p += 4 * 1024;
                                    break;
                                case "SPRP":
                                    var b2 = GetInt16(chunkDataBytes, p);
                                    dt.Rows.Add(GetHexString(b2), b2, "시나리오 이름");
                                    p += 2;
                                    b2 = GetInt16(chunkDataBytes, p);
                                    dt.Rows.Add(GetHexString(b2), b2, "시나리오 설명");
                                    break;
                                case "FORC":
                                    for (int i = 0; i < 8; i++)
                                    {
                                        var b = chunkDataBytes[p + i];
                                        dt.Rows.Add(GetHexString(b), b, $"플레이어{i + 1},포스번호");
                                    }
                                    p += 8;
                                    for (int i = 0; i < 4; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"포스{i + 1},포스이름스트링번호");
                                    }
                                    p += 4 * 2;
                                    for (int i = 0; i < 4; i++)
                                    {
                                        var b = chunkDataBytes[p + i];
                                        dt.Rows.Add(GetHexString(b), b, $"포스{i + 1},포스속성");
                                    }
                                    break;
                                case "WAV ":
                                    for (int i = 0; i < 512; i++)
                                    {
                                        var b = GetInt32(chunkDataBytes, p + 4 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"웨이브{i + 1},MPQ Path");
                                    }
                                    break;
                                case "PTEx": // PTEC
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 44; j++)
                                        {
                                            var b = chunkDataBytes[p + 44 * i + j];
                                            dt.Rows.Add(GetHexString(b), b, $"플레이어{i + 1},기술업글가능,{Tech.IdString[j]}");
                                        }
                                    }
                                    p += 12 * 44;
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 44; j++)
                                        {
                                            var b = chunkDataBytes[p + 44 * i + j];
                                            dt.Rows.Add(GetHexString(b), b, $"플레이어{i + 1},기술업글완료,{Tech.IdString[j]}");
                                        }
                                    }
                                    p += 12 * 44;
                                    for (int j = 0; j < 44; j++)
                                    {
                                        var b = chunkDataBytes[p + j];
                                        dt.Rows.Add(GetHexString(b), b, $"Global 기술업글가능,{Tech.IdString[j]}");
                                    }
                                    p += 44;
                                    for (int j = 0; j < 44; j++)
                                    {
                                        var b = chunkDataBytes[p + j];
                                        dt.Rows.Add(GetHexString(b), b, $"Global 기술업글완료,{Tech.IdString[j]}");
                                    }
                                    p += 44;
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 44; j++)
                                        {
                                            var b = chunkDataBytes[p + 44 * i + j];
                                            dt.Rows.Add(GetHexString(b), b, $"플레이어{i + 1},디폴트설정,{Tech.IdString[j]}");
                                        }
                                    }
                                    p += 12 * 44;
                                    break;
                                case "TECx": // TECS
                                    for (int j = 0; j < 44; j++)
                                    {
                                        var b = chunkDataBytes[p + j];
                                        dt.Rows.Add(GetHexString(b), b, $"디폴트설정,{Tech.IdString[j]}");
                                    }
                                    p += 44;
                                    for (int j = 0; j < 44; j++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * j);
                                        dt.Rows.Add(GetHexString(b), b, $"미네랄,{Tech.IdString[j]}");
                                    }
                                    p += 2 * 44;
                                    for (int j = 0; j < 44; j++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * j);
                                        dt.Rows.Add(GetHexString(b), b, $"가스,{Tech.IdString[j]}");
                                    }
                                    p += 2 * 44;
                                    for (int j = 0; j < 44; j++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * j);
                                        dt.Rows.Add(GetHexString(b), b, $"시간,{Tech.IdString[j]}");
                                    }
                                    p += 2 * 44;
                                    for (int j = 0; j < 44; j++)
                                    {
                                        var b = GetInt16(chunkDataBytes, p + 2 * j);
                                        dt.Rows.Add(GetHexString(b), b, $"에너지,{Tech.IdString[j]}");
                                    }
                                    p += 2 * 44;
                                    break;
                                case "MBRF":
                                    break;
                                case "TRIG":
                                    break;
                                case "UPRP":
                                    for (int i = 0; i < 64; i++)
                                    {
                                        var b = GetInt16(chunkDataBytes, 20 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"슬롯{i + 1},유닛에적용가능 속성");
                                        b = GetInt16(chunkDataBytes, 20 * i + 2);
                                        dt.Rows.Add(GetHexString(b), b, $"슬롯{i + 1},유닛정보가유효 속성");
                                        var d = chunkDataBytes[20 * i + 4];
                                        dt.Rows.Add(GetHexString(d), d, $"슬롯{i + 1},가지고있는플레이어");
                                        d = chunkDataBytes[20 * i + 5];
                                        dt.Rows.Add(GetHexString(d), d, $"슬롯{i + 1},HP %");
                                        d = chunkDataBytes[20 * i + 6];
                                        dt.Rows.Add(GetHexString(d), d, $"슬롯{i + 1},쉴드 %");
                                        d = chunkDataBytes[20 * i + 7];
                                        dt.Rows.Add(GetHexString(d), d, $"슬롯{i + 1},에너지 %");
                                        var e = GetInt32(chunkDataBytes, 20 * i + 8);
                                        dt.Rows.Add(GetHexString(e), e, $"슬롯{i + 1},자원량(자원유닛만)");
                                        b = GetInt16(chunkDataBytes, 20 * i + 12);
                                        dt.Rows.Add(GetHexString(b), b, $"슬롯{i + 1},hangar");
                                        b = GetInt16(chunkDataBytes, 20 * i + 14);
                                        dt.Rows.Add(GetHexString(b), b, $"슬롯{i + 1},유닛속성(클라킹/버로우..)");
                                        e = GetInt32(chunkDataBytes, 20 * i + 16);
                                        dt.Rows.Add(GetHexString(e), e, $"슬롯{i + 1},[사용안함]");
                                    }
                                    break;
                                case "UPUS":
                                    for (int i = 0; i < 64; i++)
                                    {
                                        var b = chunkDataBytes[i];
                                        dt.Rows.Add(GetHexString(b), b, $"슬롯{i + 1},트리거유닛속성사용");
                                    }
                                    break;
                                case "SWNM":
                                    for (int i = 0; i < 256; i++)
                                    {
                                        var b = GetInt32(chunkDataBytes, 4 * i);
                                        dt.Rows.Add(GetHexString(b), b, $"스위치{i + 1},이름스트링번호");
                                    }
                                    break;
                            }

                            dt.Rows.Add(new string[] { "──────", "──────", "────────────────────────────" });
                        }
                    }
                }
            }
            catch
            {

            }

            DataGrid.DataSource = dt.DefaultView;
            DataGrid.MultiSelect = false;
            DataGridViewColumn c1 = DataGrid.Columns[0];
            DataGridViewColumn c2 = DataGrid.Columns[1];
            DataGridViewColumn c3 = DataGrid.Columns[2];
            c1.Width = 80;
            c2.Width = 80;
            c3.Width = 350;
        }

        public short GetInt16(byte[] bytes, int start = 0)
        {
            return BitConverter.ToInt16(bytes, start);
        }

        public int GetInt32(byte[] bytes, int start = 0)
        {
            return BitConverter.ToInt32(bytes, start);
        }

        public string GetValue(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
        }

        public byte[] GetBytes(string str)
        {
            return Encoding.Default.GetBytes(str);
        }

        public string GetHexString(byte b)
        {
            return string.Format("{0:X2} ", b);
        }

        public string GetHexString(byte[] bytes)
        {
            StringBuilder bu = new StringBuilder("");

            foreach (byte b in bytes)
            {
                bu.Append(string.Format("{0:X2} ", b));
            }

            return bu.ToString();
        }

        public string GetHexString(int num)
        {
            byte[] intBytes = BitConverter.GetBytes(num);

            return GetHexString(intBytes);
        }

        public string GetHexString(short num)
        {
            byte[] shortBytes = BitConverter.GetBytes(num);

            return GetHexString(shortBytes);
        }

        public string GetHexString(string str)
        {
            return GetHexString(GetBytes(str));
        }

        public string GetStarcraftString(byte[] bytes, int offset)
        {
            for (int i = offset; i < bytes.Length; i++)
            {
                if (bytes[i] == 0)
                {
                    return GetValue(bytes).Substring(offset, i - offset);
                }
            }

            return "";
        }

        private void ChunkListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGrid.Rows[DataGrid.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Description"].Value.ToString().Equals(ChunkListBox.Items[ChunkListBox.SelectedIndex].ToString())).First().Index].Selected = true;

            DataGrid.FirstDisplayedCell = DataGrid.Rows[DataGrid.SelectedRows[0].Index].Cells[0];
        }
    }
}