namespace Gaten.Audio.VirtualKeyboard
{
    internal class Keyboard
    {
        public string[] Tone = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        public string[] Chord = { "M", "m", "dim", "aug", "M7", "7", "m7", "m7(b5)", "dim7", "sus4", "6", "m6" };
        public bool[] Press = new bool[12];
        public int Key = 0;

        public Keyboard() { }

        /// <summary>
        /// 건반이 눌림
        /// </summary>
        /// <param name="index">건반 번호</param>
        public string PressKey(int index)
        {
            Press[index] = !Press[index];
            return ConfirmChord();
        }

        /// <summary>
        /// 코드 확인
        /// </summary>
        public string ConfirmChord()
        {
            const int keyNumber = 12;

            for (int i = 0; i < keyNumber; i++)
            {
                if (Only(new int[] { i, i + 4, i + 7 })) return Tone[i];
                if (Only(new int[] { i, i + 3, i + 7 })) return Tone[i] + Chord[1];
                if (Only(new int[] { i, i + 3, i + 6 })) return Tone[i] + Chord[2];
                if (Only(new int[] { i, i + 4, i + 8 })) return Tone[i] + Chord[3];
                if (Only(new int[] { i, i + 4, i + 7, i + 11 })) return Tone[i] + Chord[4];
                if (Only(new int[] { i, i + 4, i + 7, i + 10 })) return Tone[i] + Chord[5];
                if (Only(new int[] { i, i + 3, i + 7, i + 10 })) return Tone[i] + Chord[6];
                if (Only(new int[] { i, i + 3, i + 6, i + 10 })) return Tone[i] + Chord[7];
                if (Only(new int[] { i, i + 3, i + 6, i + 9 })) return Tone[i] + Chord[8];
                if (Only(new int[] { i, i + 5, i + 7, i + 10 })) return Tone[i] + Chord[9];
                if (Only(new int[] { i, i + 4, i + 7, i + 9 })) return Tone[i] + Chord[10];
                if (Only(new int[] { i, i + 3, i + 7, i + 9 })) return Tone[i] + Chord[11];
            }

            return "";
        }

        /// <summary>
        /// 전체 건반 중에 해당 건반만 눌려있는지
        /// </summary>
        /// <param name="lists">대상 건반 번호들</param>
        /// <returns></returns>
        bool Only(int[] lists)
        {
            lists = lists.Select(l => l %= 12).ToArray();
            Array.Sort(lists);

            // 현재 눌린 건반의 인덱스들을 찾기 위해 new { i, v } 선언 -> i(index), v(value)
            // 눌린 건반을 찾아서 인덱스를 select
            // 배열로 만들어서 lists와 비교
            return Enumerable.SequenceEqual(Press.Select((v, i) => new { i, v }).Where(p => p.v.Equals(true)).Select(p => p.i).ToArray(), lists);
        }

        /// <summary>
        /// 으뜸음으로 키보드 세팅
        /// </summary>
        /// <param name="tonicIndex">으뜸음 번호</param>
        public void SetWithTonic(int tonicIndex)
        {
            int[] index = { 0, 2, 4, 5, 7, 9, 11 };
            foreach (int i in index)
                PressKey((tonicIndex + i) % 12);
        }

        /// <summary>
        /// 화음으로 키보드 세팅
        /// </summary>
        /// <param name="chordIndex">코드 번호</param>
        public string SetWithHarmony(int chordIndex)
        {
            switch (chordIndex)
            {
                case 0: PressKey((0 + Key) % 12); PressKey((4 + Key) % 12); return PressKey((7 + Key) % 12);
                case 1: PressKey((0 + Key) % 12); PressKey((3 + Key) % 12); return PressKey((7 + Key) % 12);
                case 2: PressKey((0 + Key) % 12); PressKey((3 + Key) % 12); return PressKey((6 + Key) % 12);
                case 3: PressKey((0 + Key) % 12); PressKey((4 + Key) % 12); return PressKey((8 + Key) % 12);
                case 4: PressKey((0 + Key) % 12); PressKey((4 + Key) % 12); PressKey((7 + Key) % 12); return PressKey((11 + Key) % 12);
                case 5: PressKey((0 + Key) % 12); PressKey((4 + Key) % 12); PressKey((7 + Key) % 12); return PressKey((10 + Key) % 12);
                case 6: PressKey((0 + Key) % 12); PressKey((3 + Key) % 12); PressKey((7 + Key) % 12); return PressKey((10 + Key) % 12);
                case 7: PressKey((0 + Key) % 12); PressKey((3 + Key) % 12); PressKey((6 + Key) % 12); return PressKey((10 + Key) % 12);
                case 8: PressKey((0 + Key) % 12); PressKey((3 + Key) % 12); PressKey((6 + Key) % 12); return PressKey((9 + Key) % 12);
                case 9: PressKey((0 + Key) % 12); PressKey((5 + Key) % 12); PressKey((7 + Key) % 12); return PressKey((10 + Key) % 12);
                case 10: PressKey((0 + Key) % 12); PressKey((4 + Key) % 12); PressKey((7 + Key) % 12); return PressKey((9 + Key) % 12);
                case 11: PressKey((0 + Key) % 12); PressKey((3 + Key) % 12); PressKey((7 + Key) % 12); return PressKey((9 + Key) % 12);
            }
            return "";
        }

        /// <summary>
        /// 키 설정
        /// </summary>
        /// <param name="keyString">키 문자열</param>
        public string SetKey(string keyString)
        {
            Key = Tone.Select((v, i) => new { i, v }).Where(t => t.v.Equals(keyString)).Select(t => t.i).First();
            return Tone[Key];
        }

        /// <summary>
        /// 건반의 상태 초기화
        /// </summary>
        public void Clear()
        {
            Press = Press.Select(p => p = false).ToArray();
        }

        /// <summary>
        /// 키 증가
        /// </summary>
        public string AscendKey()
        {
            bool temp = Press[11];
            for (int i = 11; i > 0; i--)
                Press[i] = Press[i - 1];
            Press[0] = temp;

            Key = (Key + 1) % 12;

            return Tone[Key];
        }

        /// <summary>
        /// 키 감소
        /// </summary>
        public string DescendKey()
        {
            bool temp = Press[0];
            for (int i = 0; i < 11; i++)
                Press[i] = Press[i + 1];
            Press[11] = temp;

            Key = Key == 0 ? 11 : Key - 1;

            return Tone[Key];
        }
    }
}
