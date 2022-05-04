using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Gaten.Net.Language.Korean;

namespace Gaten.Game.BrandNewType
{
    class Note
    {
        public int Position;
        public string Value;

        public Note()
        {

        }

        public Note(int position, string value)
        {
            Position = position;
            Value = value;
        }
    }

    class NoteObject
    {
        public List<Note> Notes = new List<Note>();
        public static int Bpm;

        public const int gap = 3;

        public NoteObject()
        {

        }

        public NoteObject(int bpm, string str)
        {
            Bpm = bpm;
            ToNote(str);
        }

        /// <summary>
        /// 문장을 노트들로 변환
        /// </summary>
        /// <param name="str">문장</param>
        public void ToNote(string str)
        {
            char[] strLetters = str.ToCharArray();
            int p = 16;

            foreach (char c in strLetters)
            {
                // 한글이 아니면 스킵
                if (!HangeulUtil.IsHangeul(c))
                    continue;

                KoreanSentence h = new KoreanSentence(c);

                // Area 개수가 2개 이하이면 8비트
                var separatedHangeul = h.Separate(KoreanSeparateOption.Heavy).FirstOrDefault() ?? new Hangeul { Area1 = "ㄱ", Area2 = "ㅏ" };
                if (separatedHangeul.GetAreaCount() <= 2)
                {
                    Notes.Add(new Note(GetNotePosition(ref p, 4), separatedHangeul.Area1));
                    Notes.Add(new Note(GetNotePosition(ref p, 4), separatedHangeul.Area2));
                }
                // 4개 이하이면 16비트
                else if (separatedHangeul.GetAreaCount() <= 4)
                {
                    Notes.Add(new Note(GetNotePosition(ref p, 2), separatedHangeul.Area1));
                    Notes.Add(new Note(GetNotePosition(ref p, 2), separatedHangeul.Area2));
                    if (separatedHangeul.AdditionalArea2 != string.Empty)
                        Notes.Add(new Note(GetNotePosition(ref p, 2), separatedHangeul.AdditionalArea2));
                    if (separatedHangeul.Area3 != string.Empty)
                        Notes.Add(new Note(GetNotePosition(ref p, 2), separatedHangeul.Area3));
                    if (separatedHangeul.AdditionalArea3 != string.Empty)
                        Notes.Add(new Note(GetNotePosition(ref p, 2), separatedHangeul.AdditionalArea3));
                    if (separatedHangeul.GetAreaCount() == 3)
                        p += 2;
                }
                // 4개 초과이면 32비트
                else
                {
                    Notes.Add(new Note(GetNotePosition(ref p, 1), separatedHangeul.Area1));
                    Notes.Add(new Note(GetNotePosition(ref p, 1), separatedHangeul.Area2));
                    Notes.Add(new Note(GetNotePosition(ref p, 1), separatedHangeul.AdditionalArea2));
                    Notes.Add(new Note(GetNotePosition(ref p, 1), separatedHangeul.Area3));
                    Notes.Add(new Note(GetNotePosition(ref p, 1), separatedHangeul.AdditionalArea3));
                    p += 3;
                }
            }
        }

        /// <summary>
        /// 노트의 X위치 구하기
        /// </summary>
        /// <param name="p"></param>
        /// <param name="incValue"></param>
        /// <returns></returns>
        public int GetNotePosition(ref int p, int incValue)
        {
            double basisInterval = 450.0 / Bpm;
            int notePosX = (int)(p * basisInterval - gap);
            p += incValue;

            return notePosX;
        }

        /// <summary>
        /// 노트를 쳤을 때 처리
        /// </summary>
        /// <param name="key"></param>
        /// <param name="rail"></param>
        /// <returns>-1: 미스, 0: 아무것도 없음, 1: 퍼펙트</returns>
        public int Hit(System.Windows.Forms.Keys key, Rail rail, bool shiftMode)
        {
            string HangeulOrderString = "ㅁㅠㅊㅇㄷㄹㅎㅗㅑㅓㅏㅣㅡㅜㅐㅔㅂㄱㄴㅅㅕㅍㅈㅌㅛㅋ"; // Shift Off
            string HangeulOrderString2 = "ㅁㅠㅊㅇㄸㄹㅎㅗㅑㅓㅏㅣㅡㅜㅒㅖㅃㄲㄴㅆㅕㅍㅉㅌㅛㅋ"; // Shift On

            // 현재 타이밍에 가장 적합한 노트 가져오기
            Note activeNote = GetActiveNote(rail);

            // 쳐야 되는 노트가 없을 경우 아무 일도 안 일어남
            if (activeNote == null)
                return 0;

            // shiftMode true : 쉬프트 버튼 누르고 있음
            // shiftMode false : 쉬프트 버튼 안누르고 있음
            // activeNote의 값과 입력한 키를 비교해서 맞게 쳤으면 1을 반환, 틀리게 쳤으면 -1을 반환
            if((shiftMode ? HangeulOrderString2 : HangeulOrderString)[(int)key - 'A'].ToString() == activeNote.Value)
            {
                Notes.Remove(activeNote);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public Note GetActiveNote(Rail rail)
        {
            for (int i = 0; i < Notes.Count; i++)
            {
                // Rail Hit Bar의 왼쪽 검사
                if ((Notes[i].Position + gap * 7) * rail.ServiceSpeed >= rail.Position)
                {
                    // Rail Hit Bar의 오른쪽 검사
                    if ((Notes[i].Position - gap * 3) * rail.ServiceSpeed <= rail.Position)
                        return Notes[i];
                }
            }
            return null;
        }
    }
}
