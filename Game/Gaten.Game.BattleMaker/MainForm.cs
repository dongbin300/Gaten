namespace Gaten.Game.BattleMaker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string[] skill = new string[6];
            skill[0] = "Fire";
            skill[1] = "Ice";
            skill[2] = "Storm";
            skill[3] = "Thunder";
            skill[4] = "Flame";
            skill[5] = "Electric";

            codnametb1.Text = "CodeName" + rnd.Next(0, 10000);
            codnametb2.Text = "CodeName" + rnd.Next(0, 10000);
            hptb1.Text = "" + rnd.Next(5000, 20000);
            hptb2.Text = "" + rnd.Next(5000, 20000);
            mptb1.Text = "" + rnd.Next(100, 1000);
            mptb2.Text = "" + rnd.Next(100, 1000);
            powertb1.Text = "" + rnd.Next(100, 1000);
            powertb2.Text = "" + rnd.Next(100, 1000);
            armortb1.Text = "" + rnd.Next(20, 200);
            armortb2.Text = "" + rnd.Next(20, 200);
            lucktb1.Text = "" + rnd.Next(100, 1000);
            lucktb2.Text = "" + rnd.Next(100, 1000);
            luckytb1.Text = "" + rnd.Next(10, 100);
            luckytb2.Text = "" + rnd.Next(10, 100);
            skillnametb1.Text = skill[rnd.Next(0, 5)] + rnd.Next(0, 10000);
            skillnametb2.Text = skill[rnd.Next(0, 5)] + rnd.Next(0, 10000);
            skillpowertb1.Text = "" + string.Format("{0:0.0}", rnd.Next(15, 30) / 10f);
            skillpowertb2.Text = "" + string.Format("{0:0.0}", rnd.Next(15, 30) / 10f);
            skillmptb1.Text = "" + rnd.Next(20, 200);
            skillmptb2.Text = "" + rnd.Next(20, 200);
            skillcooltb1.Text = "" + rnd.Next(2, 4);
            skillcooltb2.Text = "" + rnd.Next(2, 4);
        }

        private void Hero1Winbt_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Battle";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Random rnd = new Random();
                DateTime nowtime = DateTime.Now;
                int i;
                string cod1, cod2;
                int HP1, HP2, MP1, MP2;
                int power1, power2;
                int damage1, damage2;
                int armor1, armor2;
                int luck1, luck2;
                int lucky1, lucky2;
                string skillname1, skillname2;
                float skillpower1, skillpower2;
                int skilldamage1, skilldamage2;
                int skillmp1, skillmp2;
                int skillcool1, skillcool2;
                int cool1, cool2;
                string filename = saveFileDialog1.FileName;

                #region initial

                cod1 = codnametb1.Text;
                cod2 = codnametb2.Text;
                HP1 = int.Parse(hptb1.Text);
                HP2 = int.Parse(hptb2.Text);
                MP1 = int.Parse(mptb1.Text);
                MP2 = int.Parse(mptb2.Text);
                power1 = int.Parse(powertb1.Text);
                power2 = int.Parse(powertb2.Text);
                armor1 = int.Parse(armortb1.Text);
                armor2 = int.Parse(armortb2.Text);
                luck1 = int.Parse(lucktb1.Text);
                luck2 = int.Parse(lucktb2.Text);
                lucky1 = int.Parse(luckytb1.Text);
                lucky2 = int.Parse(luckytb2.Text);
                skillname1 = skillnametb1.Text;
                skillname2 = skillnametb2.Text;
                skillpower1 = float.Parse(skillpowertb1.Text);
                skillpower2 = float.Parse(skillpowertb2.Text);
                skillmp1 = int.Parse(skillmptb1.Text);
                skillmp2 = int.Parse(skillmptb2.Text);
                skillcool1 = int.Parse(skillcooltb1.Text);
                skillcool2 = int.Parse(skillcooltb2.Text);
                cool1 = skillcool1;
                cool2 = skillcool2;

                #endregion

                FileStream fs = new FileStream(filename, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("Battle Maker v1.0 - ������ Gaten");
                sw.WriteLine("���� ������ " + nowtime + "�� ������ �����Դϴ�.");
                sw.WriteLine();
                sw.WriteLine("������ȣ: " +
                    string.Format("{0:0000}", nowtime.Year) +
                    string.Format("{0:00}", nowtime.Month) +
                    string.Format("{0:00}", nowtime.Day) +
                    string.Format("{0:00000}", (123 * nowtime.Hour + 456 * nowtime.Minute + 789 * nowtime.Second))
                    );
                sw.WriteLine();
                sw.WriteLine("  " + cod1 + " vs " + cod2);
                sw.WriteLine();
                sw.WriteLine(cod1 +
                    " HP: " + HP1 +
                    ", MP: " + MP1 +
                    ", ���ݷ�: " + power1 +
                    ", ����: " + armor1 +
                    ", ����: " + luck1 +
                    ", ȸ��: " + lucky1
                    );
                sw.WriteLine(
                    "��ų: " + skillname1 +
                    "(" + skillcool1 + ")" +
                    ", ���ݷ�: " + (int)(skillpower1 * 100f) + "%" +
                    ", MP�Ҹ�: " + skillmp1
                    );
                sw.WriteLine(cod2 +
                    " HP: " + HP2 +
                    ", MP: " + MP2 +
                    ", ���ݷ�: " + power2 +
                    ", ����: " + armor2 +
                    ", ����: " + luck2 +
                    ", ȸ��: " + lucky2
                    );
                sw.WriteLine(
                    "��ų: " + skillname2 +
                    "(" + skillcool2 + ")" +
                    ", ���ݷ�: " + (int)(skillpower2 * 100f) + "%" +
                    ", MP�Ҹ�: " + skillmp2
                    );
                sw.WriteLine();

                for (i = 1; ; i++)
                {
                    cool1++;
                    cool2++;

                    if (HP1 <= 0 || HP2 <= 0)
                    {
                        if (HP1 <= 0 && HP2 > 0)
                        {
                            sw.WriteLine(cod2 + "�� �¸�!");
                            sw.WriteLine("����!");
                        }
                        else if (HP2 <= 0 && HP1 > 0)
                        {
                            sw.WriteLine(cod1 + "�� �¸�!");
                            sw.WriteLine("����!");
                        }
                        else if (HP1 <= 0 && HP2 <= 0)
                        {
                            sw.WriteLine("���º�!");
                        }
                        break;
                    }

                    damage1 = (int)((float)power1 + (float)power1 * ((float)(rnd.Next(0, 100) - 50) / 1000f));
                    damage2 = (int)((float)power2 + (float)power2 * ((float)(rnd.Next(0, 100) - 50) / 1000f));
                    skilldamage1 = (int)(((float)power1 * skillpower1) + ((float)power1 * skillpower1) * ((float)(rnd.Next(0, 200) - 100) / 1000f));
                    skilldamage2 = (int)(((float)power2 * skillpower2) + ((float)power2 * skillpower2) * ((float)(rnd.Next(0, 200) - 100) / 1000f));

                    sw.WriteLine("==============================================");
                    sw.WriteLine(i + "��° ��\r\n");
                    if (cool1 >= skillcool1 && MP1 >= skillmp1) // ��ų����
                    {
                        MP1 -= skillmp1;
                        cool1 = 0;
                        if (rnd.Next(1, 100) <= (int)((float)lucky2 / (float)luck1 * 100f)) // ��ųȸ��
                        {
                            sw.WriteLine(cod2 + "���� ��ų������ ȸ���߽��ϴ�.(" + (int)((float)lucky2 / (float)luck1 * 100f) + "%)");
                        }
                        else
                        {
                            sw.WriteLine(cod1 + "���� @" + skillname1 + "@�� " + cod2 + "���� �����߽��ϴ�. ������ " + (skilldamage1 - armor2) + "(" + skilldamage1 + "-" + armor2 + ")");
                            HP2 -= (skilldamage1 - armor2);
                        }
                    }
                    else // ��Ÿ
                    {
                        if (rnd.Next(1, 100) <= (int)((float)lucky2 / (float)luck1 * 100f)) // ȸ��
                        {
                            sw.WriteLine(cod2 + "���� ������ ȸ���߽��ϴ�.(" + (int)((float)lucky2 / (float)luck1 * 100f) + "%)");
                        }
                        else
                        {
                            sw.WriteLine(cod1 + "���� " + cod2 + "���� �����߽��ϴ�. ������ " + (damage1 - armor2) + "(" + damage1 + "-" + armor2 + ")");
                            HP2 -= (damage1 - armor2);
                        }
                    }

                    if (cool2 >= skillcool2 && MP2 >= skillmp2) // ��ų����
                    {
                        MP2 -= skillmp2;
                        cool2 = 0;
                        if (rnd.Next(1, 100) <= (int)((float)lucky1 / (float)luck2 * 100f)) // ��ųȸ��
                        {
                            sw.WriteLine(cod1 + "���� ��ų������ ȸ���߽��ϴ�.(" + (int)((float)lucky1 / (float)luck2 * 100f) + "%)");
                        }
                        else
                        {
                            sw.WriteLine(cod2 + "���� @" + skillname2 + "@�� " + cod1 + "���� �����߽��ϴ�. ������ " + (skilldamage2 - armor1) + "(" + skilldamage2 + "-" + armor1 + ")");
                            HP1 -= (skilldamage2 - armor1);
                        }
                    }
                    else // ��Ÿ
                    {
                        if (rnd.Next(1, 100) <= (int)((float)lucky1 / (float)luck2 * 100f)) // ȸ��
                        {
                            sw.WriteLine(cod1 + "���� ������ ȸ���߽��ϴ�.(" + (int)((float)lucky1 / (float)luck2 * 100f) + "%)");
                        }
                        else
                        {
                            sw.WriteLine(cod2 + "���� " + cod1 + "���� �����߽��ϴ�. ������ " + (damage2 - armor1) + "(" + damage2 + "-" + armor1 + ")");
                            HP1 -= (damage2 - armor1);
                        }
                    }
                    sw.WriteLine(cod1 +
                        " HP: " + HP1 +
                        " MP: " + MP1 +
                        "(" + (int)((float)MP1 / (float)skillmp1) + ")"
                        );
                    sw.WriteLine(cod2 +
                        " HP: " + HP2 +
                        " MP: " + MP2 +
                        "(" + (int)((float)MP2 / (float)skillmp2) + ")"
                        );
                    sw.WriteLine();
                }
                sw.Flush();
                fs.Close();
            }
        }

        private void Hero2Winbt_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Battle";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Random rnd = new Random();
                DateTime nowtime = DateTime.Now;
                int i;
                string cod1, cod2;
                int HP1, HP2, MP1, MP2;
                int power1, power2;
                int damage1, damage2;
                int armor1, armor2;
                int luck1, luck2;
                int lucky1, lucky2;
                string skillname1, skillname2;
                float skillpower1, skillpower2;
                int skilldamage1, skilldamage2;
                int skillmp1, skillmp2;
                int skillcool1, skillcool2;
                int cool1, cool2;
                string filename = saveFileDialog1.FileName;

                #region initial

                cod1 = codnametb1.Text;
                cod2 = codnametb2.Text;
                HP1 = int.Parse(hptb1.Text);
                HP2 = int.Parse(hptb2.Text);
                MP1 = int.Parse(mptb1.Text);
                MP2 = int.Parse(mptb2.Text);
                power1 = int.Parse(powertb1.Text);
                power2 = int.Parse(powertb2.Text);
                armor1 = int.Parse(armortb1.Text);
                armor2 = int.Parse(armortb2.Text);
                luck1 = int.Parse(lucktb1.Text);
                luck2 = int.Parse(lucktb2.Text);
                lucky1 = int.Parse(luckytb1.Text);
                lucky2 = int.Parse(luckytb2.Text);
                skillname1 = skillnametb1.Text;
                skillname2 = skillnametb2.Text;
                skillpower1 = float.Parse(skillpowertb1.Text);
                skillpower2 = float.Parse(skillpowertb2.Text);
                skillmp1 = int.Parse(skillmptb1.Text);
                skillmp2 = int.Parse(skillmptb2.Text);
                skillcool1 = int.Parse(skillcooltb1.Text);
                skillcool2 = int.Parse(skillcooltb2.Text);
                cool1 = skillcool1;
                cool2 = skillcool2;

                #endregion

                FileStream fs = new FileStream(filename, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("Battle Maker v1.0 - ������ Gaten");
                sw.WriteLine("���� ������ " + nowtime + "�� ������ �����Դϴ�.");
                sw.WriteLine();
                sw.WriteLine("������ȣ: " +
                    string.Format("{0:0000}", nowtime.Year) +
                    string.Format("{0:00}", nowtime.Month) +
                    string.Format("{0:00}", nowtime.Day) +
                    string.Format("{0:00000}", (123 * nowtime.Hour + 456 * nowtime.Minute + 789 * nowtime.Second))
                    );
                sw.WriteLine();
                sw.WriteLine("  " + cod1 + " vs " + cod2);
                sw.WriteLine();
                sw.WriteLine(cod1 +
                    " HP: " + HP1 +
                    ", MP: " + MP1 +
                    ", ���ݷ�: " + power1 +
                    ", ����: " + armor1 +
                    ", ����: " + luck1 +
                    ", ȸ��: " + lucky1
                    );
                sw.WriteLine(
                    "��ų: " + skillname1 +
                    "(" + skillcool1 + ")" +
                    ", ���ݷ�: " + (int)(skillpower1 * 100f) + "%" +
                    ", MP�Ҹ�: " + skillmp1
                    );
                sw.WriteLine(cod2 +
                    " HP: " + HP2 +
                    ", MP: " + MP2 +
                    ", ���ݷ�: " + power2 +
                    ", ����: " + armor2 +
                    ", ����: " + luck2 +
                    ", ȸ��: " + lucky2
                    );
                sw.WriteLine(
                    "��ų: " + skillname2 +
                    "(" + skillcool2 + ")" +
                    ", ���ݷ�: " + (int)(skillpower2 * 100f) + "%" +
                    ", MP�Ҹ�: " + skillmp2
                    );
                sw.WriteLine();

                for (i = 1; ; i++)
                {
                    cool1++;
                    cool2++;

                    if (HP1 <= 0 || HP2 <= 0)
                    {
                        if (HP1 <= 0 && HP2 > 0)
                        {
                            sw.WriteLine(cod2 + "�� �¸�!");
                            sw.WriteLine("����!");
                        }
                        else if (HP2 <= 0 && HP1 > 0)
                        {
                            sw.WriteLine(cod1 + "�� �¸�!");
                            sw.WriteLine("����!");
                        }
                        else if (HP1 <= 0 && HP2 <= 0)
                        {
                            sw.WriteLine("���º�!");
                        }
                        break;
                    }

                    damage1 = (int)((float)power1 + (float)power1 * ((float)(rnd.Next(0, 100) - 50) / 1000f));
                    damage2 = (int)((float)power2 + (float)power2 * ((float)(rnd.Next(0, 100) - 50) / 1000f));
                    skilldamage1 = (int)(((float)power1 * skillpower1) + ((float)power1 * skillpower1) * ((float)(rnd.Next(0, 200) - 100) / 1000f));
                    skilldamage2 = (int)(((float)power2 * skillpower2) + ((float)power2 * skillpower2) * ((float)(rnd.Next(0, 200) - 100) / 1000f));

                    sw.WriteLine("==============================================");
                    sw.WriteLine(i + "��° ��\r\n");
                    if (cool1 >= skillcool1 && MP1 >= skillmp1) // ��ų����
                    {
                        MP1 -= skillmp1;
                        cool1 = 0;
                        if (rnd.Next(1, 100) <= (int)((float)lucky2 / (float)luck1 * 100f)) // ��ųȸ��
                        {
                            sw.WriteLine(cod2 + "���� ��ų������ ȸ���߽��ϴ�.(" + (int)((float)lucky2 / (float)luck1 * 100f) + "%)");
                        }
                        else
                        {
                            sw.WriteLine(cod1 + "���� @" + skillname1 + "@�� " + cod2 + "���� �����߽��ϴ�. ������ " + (skilldamage1 - armor2) + "(" + skilldamage1 + "-" + armor2 + ")");
                            HP2 -= (skilldamage1 - armor2);
                        }
                    }
                    else // ��Ÿ
                    {
                        if (rnd.Next(1, 100) <= (int)((float)lucky2 / (float)luck1 * 100f)) // ȸ��
                        {
                            sw.WriteLine(cod2 + "���� ������ ȸ���߽��ϴ�.(" + (int)((float)lucky2 / (float)luck1 * 100f) + "%)");
                        }
                        else
                        {
                            sw.WriteLine(cod1 + "���� " + cod2 + "���� �����߽��ϴ�. ������ " + (damage1 - armor2) + "(" + damage1 + "-" + armor2 + ")");
                            HP2 -= (damage1 - armor2);
                        }
                    }

                    if (cool2 >= skillcool2 && MP2 >= skillmp2) // ��ų����
                    {
                        MP2 -= skillmp2;
                        cool2 = 0;
                        if (rnd.Next(1, 100) <= (int)((float)lucky1 / (float)luck2 * 100f)) // ��ųȸ��
                        {
                            sw.WriteLine(cod1 + "���� ��ų������ ȸ���߽��ϴ�.(" + (int)((float)lucky1 / (float)luck2 * 100f) + "%)");
                        }
                        else
                        {
                            sw.WriteLine(cod2 + "���� @" + skillname2 + "@�� " + cod1 + "���� �����߽��ϴ�. ������ " + (skilldamage2 - armor1) + "(" + skilldamage2 + "-" + armor1 + ")");
                            HP1 -= (skilldamage2 - armor1);
                        }
                    }
                    else // ��Ÿ
                    {
                        if (rnd.Next(1, 100) <= (int)((float)lucky1 / (float)luck2 * 100f)) // ȸ��
                        {
                            sw.WriteLine(cod1 + "���� ������ ȸ���߽��ϴ�.(" + (int)((float)lucky1 / (float)luck2 * 100f) + "%)");
                        }
                        else
                        {
                            sw.WriteLine(cod2 + "���� " + cod1 + "���� �����߽��ϴ�. ������ " + (damage2 - armor1) + "(" + damage2 + "-" + armor1 + ")");
                            HP1 -= (damage2 - armor1);
                        }
                    }
                    sw.WriteLine(cod1 +
                        " HP: " + HP1 +
                        " MP: " + MP1 +
                        "(" + (int)((float)MP1 / (float)skillmp1) + ")"
                        );
                    sw.WriteLine(cod2 +
                        " HP: " + HP2 +
                        " MP: " + MP2 +
                        "(" + (int)((float)MP2 / (float)skillmp2) + ")"
                        );
                    sw.WriteLine();
                }
                sw.Flush();
                fs.Close();
            }
        }
    }
}