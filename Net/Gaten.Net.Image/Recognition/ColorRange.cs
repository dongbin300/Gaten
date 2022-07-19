using System.Drawing;

namespace Gaten.Net.Image.Recognition
{
    public enum ColorRangeType
    {
        D3,
        Average
    }

    public class ColorRange
    {
        private ColorRangeType type;
        private Color startColor;
        private Color endColor;
        private int min;
        private int max;

        public ColorRange() : this(0,0)
        {

        }

        public ColorRange(Color startColor, Color endColor)
        {
            type = ColorRangeType.D3;
            this.startColor = startColor;
            this.endColor = endColor;
        }

        public ColorRange(int min, int max)
        {
            type = ColorRangeType.Average;
            this.min = min;
            this.max = max;
        }

        public bool IsValid(Color color)
        {
            double average = (double)(color.R + color.G + color.B) / 3;
            return type switch
            {
                ColorRangeType.D3 => startColor.R <= color.R && color.R <= endColor.R &&
                                        startColor.G <= color.G && color.G <= endColor.G &&
                                        startColor.B <= color.B && color.B <= endColor.B,
                ColorRangeType.Average => min <= average && average <= max,
                _ => false,
            };
        }
    }
}
