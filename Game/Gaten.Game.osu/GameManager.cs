using Gaten.Net.GameRule.osu;
using Gaten.Net.GameRule.osu.OsuFile;

using Microsoft.Win32.SafeHandles;

using System.Runtime.InteropServices;

namespace Gaten.Game.osu
{
    public class GameManager : IDisposable
    {
        private bool disposed = false;
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public List<Note> notes = new();
        public int Current;
        public int TrackPosition;
        public int TrackSpeed;
        public int Height = 720;
        public const int fps = 30; // fps 30 이라고 가정
        public const int height = 632; // 높이 700이라고 가정 : 이 값이 커질수록 트랙속도는 빨라짐

        public GameManager(int trackSpeed)
        {
            Current = 0;
            TrackPosition = 0;
            TrackSpeed = trackSpeed;

            MakeTestNotes();
        }

        public GameManager(OsuFileObject obj)
        {
            Current = 0;
            TrackPosition = 0;

            // 노트 낙하 속도 계산
            double ar = double.Parse(obj.Difficulty["ApproachRate"].ToString());
            int ms = ApproachRate.GetMilliseconds(ar);
            TrackSpeed = (int)(1000.0 * height / ms / fps);

            // 노트 파싱
            notes = NoteParser.Parse(obj);
        }

        public bool Proceed()
        {
            TrackPosition += TrackSpeed;

            if (notes[Current].Position.Y <= TrackPosition)
            {
                Current++;
            }

            if (Current >= notes.Count)
            {
                Dispose();
                return false;
            }

            return true;
        }

        public void MakeTestNotes()
        {
            Random r = new();

            for (int i = 0; i < 100; i++)
            {
                int x = r.Next(1150) + 50;
                int y = (i * 200) + 200;

                notes.Add(new Note(NoteType.Circle, x, y));
            }
        }

        public void Draw(PaintEventArgs e)
        {
            for (int i = Current; i < notes.Count; i++)
            {
                if (notes[i].Position.Y > TrackPosition + Height)
                {
                    break;
                }

                e.Graphics.FillEllipse(Brushes.White, new Rectangle(
                    notes[i].Position.X, Height - (notes[i].Position.Y - TrackPosition),
                    notes[i].Size, notes[i].Size
                    ));
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
    }
}
