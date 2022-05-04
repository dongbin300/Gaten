using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Extension
{
    public static class ColorExtension
    {
        /// <summary>
        /// 검은색인지 확인
        /// </summary>
        /// <param name="color">픽셀 컬러</param>
        /// <param name="margin">오차범위, 10일 경우 (10,10,10)까지는 허용함</param>
        /// <returns></returns>
        public static bool IsBlack(this Color color, int margin = 10)
        {
            return color.R + color.G + color.B <= margin * 3;
        }

        /// <summary>
        /// 같은 색인지 확인
        /// </summary>
        /// <param name="color1">픽셀 컬러1</param>
        /// <param name="color2">픽셀 컬러2</param>
        /// <param name="margin">오차 범위</param>
        /// <returns></returns>
        public static bool IsSameColor(this Color color1, Color color2, int margin = 10)
        {
            return ((int)color1.R).IsRange(color2.R - margin, color2.R + margin) &&
                ((int)color1.G).IsRange(color2.G - margin, color2.G + margin) &&
                ((int)color1.B).IsRange(color2.B - margin, color2.B + margin);
        }

        /// <summary>
        /// 모두 같은 색인지 확인
        /// </summary>
        /// <param name="colors">픽셀 컬러들</param>
        /// <param name="margin">오차 범위</param>
        /// <returns></returns>
        public static bool IsSameColor(this IList<Color> colors, int margin = 10)
        {
            for (int i = 0; i < colors.Count - 1; i++)
            {
                if (!IsSameColor(colors[i], colors[i + 1], margin))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 그레이색인지 확인
        /// </summary>
        /// <param name="color">픽셀 컬러</param>
        /// <param name="margin">오차범위</param>
        /// <returns></returns>
        public static bool IsGrayColor(this Color color, int margin = 10)
        {
            return Math.Abs(color.R - color.G) <= margin && Math.Abs(color.R - color.B) <= margin && Math.Abs(color.G - color.B) <= margin;
        }

        /// <summary>
        /// 해당 좌표에서 X축(오른쪽)으로 inspectWidth만큼의 평균값
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="width"></param>
        /// <param name="inspectWidth"></param>
        /// <returns></returns>
        public static Color AverageOfInspectX(this IList<Color> colors, int i, int j, int width, int inspectWidth)
        {
            int R = 0;
            int G = 0;
            int B = 0;

            for (int t = 0; t < inspectWidth; t++)
            {
                R += colors[i * width + (j + t)].R;
                G += colors[i * width + (j + t)].G;
                B += colors[i * width + (j + t)].B;
            }

            return Color.FromArgb(R / inspectWidth, G / inspectWidth, B / inspectWidth);
        }

        /// <summary>
        /// 해당 좌표에서 Y축(밑)으로 inspectHeight만큼의 평균값
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="width"></param>
        /// <param name="inspectHeight"></param>
        /// <returns></returns>
        public static Color AverageOfInspectY(this IList<Color> colors, int i, int j, int width, int inspectHeight)
        {
            int R = 0;
            int G = 0;
            int B = 0;

            for (int t = 0; t < inspectHeight; t++)
            {
                R += colors[(i + t) * width + j].R;
                G += colors[(i + t) * width + j].G;
                B += colors[(i + t) * width + j].B;
            }

            return Color.FromArgb(R / inspectHeight, G / inspectHeight, B / inspectHeight);
        }

        /// <summary>
        /// 대상에 더 가까운 색상을 선택
        /// </summary>
        /// <param name="color">비교 대상 컬러</param>
        /// <param name="color1">후보1 컬러</param>
        /// <param name="color2">후보2 컬러</param>
        /// <returns></returns>
        public static Color GetNearestColor(this Color color, Color color1, Color color2)
        {
            return Math.Sqrt(Math.Pow(color.R - color1.R, 2) + Math.Pow(color.G - color1.G, 2) + Math.Pow(color.B - color1.B, 2)) < Math.Sqrt(Math.Pow(color.R - color2.R, 2) + Math.Pow(color.G - color2.G, 2) + Math.Pow(color.B - color2.B, 2)) ? color1 : color2;
        }

        /// <summary>
        /// RGB의 평균
        /// </summary>
        /// <param name="color">픽셀 컬러</param>
        /// <returns>RGB의 평균값</returns>
        public static int RGBAverage(this Color color)
        {
            return (color.R + color.G + color.B) / 3;
        }
    }
}
