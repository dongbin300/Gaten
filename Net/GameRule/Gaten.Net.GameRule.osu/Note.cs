using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.GameRule.osu
{
    public enum NoteType
    {
        Circle,
        Slider,
        Spin // not supported
    }

    public class Note
    {
        public NoteType Type;
        public Point Position;
        public int Size;
        public static int CircleSize = 100;
        public static int SliderSize = 40;

        public Note()
        {

        }

        public Note(NoteType type, Point position)
        {
            Type = type;
            Position = position;

            switch (type)
            {
                case NoteType.Circle: Size = CircleSize; break;
                case NoteType.Slider: Size = SliderSize; break;
            }
        }

        public Note(NoteType type, int x, int y)
        {
            Type = type;
            Position = new Point(x, y);

            switch (type)
            {
                case NoteType.Circle: Size = CircleSize; break;
                case NoteType.Slider: Size = SliderSize; break;
            }
        }
    }
}
