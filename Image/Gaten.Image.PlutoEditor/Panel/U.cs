using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Image.PlutoEditor.Panel
{
    /// <summary>
    /// Universe Coordinate
    /// 
    /// Pixel : 모니터에서 표시되는 하나의 픽셀 단위
    /// Coordinate : 프로그램 내에서 표시되는 하나의 점 단위
    /// </summary>
    public class U
    {
        public static int Scale = 20;

        public U() { }

        /// <summary>
        /// Scale 설정
        /// </summary>
        /// <param name="value"></param>
        public static float SetScale(int value)
        {
            // 기존 스케일과 같으면 값 그대로
            if (Scale == value) return 1.0f;

            // 변경된 스케일 비율
            float _scale = (float)value / Scale;

            // 스케일 설정
            Scale = value;

            return _scale;
        }

        /// <summary>
        /// 픽셀 값
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int P(int x)
        {
            return x * Scale;
        }

        /// <summary>
        /// 포인트 픽셀 값
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Point P(Point p)
        {
            p.X *= Scale;
            p.Y *= Scale;
            return p;
        }

        /// <summary>
        /// 좌표 값
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int C(int x)
        {
            return x / Scale;
        }

        /// <summary>
        /// 포인트 좌표 값
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Point C(Point p)
        {
            p.X /= Scale;
            p.Y /= Scale;
            return p;
        }
    }
}
