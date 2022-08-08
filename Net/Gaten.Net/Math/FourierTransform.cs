using Gaten.Net.Extensions;

using System.Numerics;

namespace Gaten.Net.Math
{
    public class FourierTransform
    {
        public enum Direction
        {
            Forward = 1,
            Backward = -1
        }

        private const int minLength = 2;
        private const int maxLength = 16384;
        private const int minBits = 1;
        private const int maxBits = 14;

        private static readonly int[][] reversedBits = new int[14][];
        private static readonly Complex[,][] complexRotation = new Complex[14, 2][];

        public static void DFT(Complex[] data, Direction direction)
        {
            int num = data.Length;
            Complex[] array = new Complex[num];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Complex.Zero;
                double num2 = (0 - direction) * 2.0 * System.Math.PI * i / num;
                for (int j = 0; j < data.Length; j++)
                {
                    double num3 = System.Math.Cos(j * num2);
                    double num4 = System.Math.Sin(j * num2);
                    double real = (data[j].Real * num3) - (data[j].Imaginary * num4);
                    double imaginary = (data[j].Real * num4) + (data[j].Imaginary * num3);
                    array[i] += new Complex(real, imaginary);
                }
            }

            if (direction == Direction.Forward)
            {
                for (int k = 0; k < data.Length; k++)
                {
                    data[k] /= (Complex)num;
                }
            }
            else
            {
                for (int l = 0; l < data.Length; l++)
                {
                    data[l] = array[l];
                }
            }
        }

        public static void DFT2(Complex[,] data, Direction direction)
        {
            int length = data.GetLength(0);
            int length2 = data.GetLength(1);
            Complex[] array = new Complex[System.Math.Max(length, length2)];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = Complex.Zero;
                    double num = (0 - direction) * 2.0 * System.Math.PI * j / length2;
                    for (int k = 0; k < length2; k++)
                    {
                        double num2 = System.Math.Cos(k * num);
                        double num3 = System.Math.Sin(k * num);
                        double real = (data[i, k].Real * num2) - (data[i, k].Imaginary * num3);
                        double imaginary = (data[i, k].Real * num3) + (data[i, k].Imaginary * num2);
                        array[j] += new Complex(real, imaginary);
                    }
                }

                if (direction == Direction.Forward)
                {
                    for (int l = 0; l < array.Length; l++)
                    {
                        data[i, l] = array[l] / (Complex)length2;
                    }
                }
                else
                {
                    for (int m = 0; m < array.Length; m++)
                    {
                        data[i, m] = array[m];
                    }
                }
            }

            for (int n = 0; n < length2; n++)
            {
                for (int num4 = 0; num4 < length; num4++)
                {
                    array[num4] = Complex.Zero;
                    double num = (0 - direction) * 2.0 * System.Math.PI * num4 / length;
                    for (int num5 = 0; num5 < length; num5++)
                    {
                        double num2 = System.Math.Cos(num5 * num);
                        double num3 = System.Math.Sin(num5 * num);
                        double real2 = (data[num5, n].Real * num2) - (data[num5, n].Imaginary * num3);
                        double imaginary2 = (data[num5, n].Real * num3) + (data[num5, n].Imaginary * num2);
                        array[num4] += new Complex(real2, imaginary2);
                    }
                }

                if (direction == Direction.Forward)
                {
                    for (int num6 = 0; num6 < array.Length; num6++)
                    {
                        data[num6, n] = array[num6] / (Complex)length;
                    }
                }
                else
                {
                    for (int num7 = 0; num7 < array.Length; num7++)
                    {
                        data[num7, n] = array[num7];
                    }
                }
            }
        }

        public static void FFT(Complex[] data, Direction direction)
        {
            int num = data.Length;
            int num2 = (int)System.Math.Log2(num);
            ReorderData(data);
            int num3 = 1;
            for (int i = 1; i <= num2; i++)
            {
                Complex[] array = GetComplexRotation(i, direction);
                int num4 = num3;
                num3 <<= 1;
                for (int j = 0; j < num4; j++)
                {
                    Complex complex = array[j];
                    for (int k = j; k < num; k += num3)
                    {
                        int num5 = k + num4;
                        Complex complex2 = data[k];
                        Complex complex3 = data[num5];
                        double num6 = (complex3.Real * complex.Real) - (complex3.Imaginary * complex.Imaginary);
                        double num7 = (complex3.Real * complex.Imaginary) + (complex3.Imaginary * complex.Real);
                        data[k] += new Complex(num6, num7);
                        data[num5] = new Complex(complex2.Real - num6, complex2.Imaginary - num7);
                    }
                }
            }

            if (direction == Direction.Forward)
            {
                for (int l = 0; l < data.Length; l++)
                {
                    data[l] /= (Complex)(double)num;
                }
            }
        }

        public static void FFT2(Complex[,] data, Direction direction)
        {
            int length = data.GetLength(0);
            int length2 = data.GetLength(1);
            if (!length.IsPowerOf2() || !length2.IsPowerOf2())
            {
                throw new ArgumentException("The matrix rows and columns must be a power of 2.");
            }

            if (length < 2 || length > 16384 || length2 < 2 || length2 > 16384)
            {
                throw new ArgumentException("Incorrect data length.");
            }

            Complex[] array = new Complex[length2];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = data[i, j];
                }

                FFT(array, direction);
                for (int k = 0; k < array.Length; k++)
                {
                    data[i, k] = array[k];
                }
            }

            Complex[] array2 = new Complex[length];
            for (int l = 0; l < length2; l++)
            {
                for (int m = 0; m < length; m++)
                {
                    array2[m] = data[m, l];
                }

                FFT(array2, direction);
                for (int n = 0; n < length; n++)
                {
                    data[n, l] = array2[n];
                }
            }
        }

        public static List<int> GetPeaks(Complex[] data, int take = 1)
        {
            return data.Select((value, index) => (value, index))
                .OrderByDescending(x => x.value.Imaginary)
                .Take(take)
                .Select(x=>x.index)
                .ToList();
        }

        public static List<int> GetSmartPeaks(Complex[] data)
        {
            var max = data.Max(x => System.Math.Abs(x.Imaginary));

            return data.Select((value, index) => (value, index))
                .OrderByDescending(x => x.value.Imaginary)
                .Where(x => x.value.Imaginary * 10 > max)
                .Select(x=>x.index)
                .ToList();
        }

        private static int[] GetReversedBits(int numberOfBits)
        {
            if (numberOfBits is < 1 or > 14)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (reversedBits[numberOfBits - 1] == null)
            {
                int num = (int)System.Math.Pow(2, numberOfBits);
                int[] array = new int[num];
                for (int i = 0; i < num; i++)
                {
                    int num2 = i;
                    int num3 = 0;
                    for (int j = 0; j < numberOfBits; j++)
                    {
                        num3 = (num3 << 1) | (num2 & 1);
                        num2 >>= 1;
                    }

                    array[i] = num3;
                }

                reversedBits[numberOfBits - 1] = array;
            }

            return reversedBits[numberOfBits - 1];
        }

        private static Complex[] GetComplexRotation(int numberOfBits, Direction direction)
        {
            int num = (direction != Direction.Forward) ? 1 : 0;
            if (complexRotation[numberOfBits - 1, num] == null)
            {
                int num2 = 1 << (numberOfBits - 1);
                double num3 = 1.0;
                double num4 = 0.0;
                double num5 = System.Math.PI / num2 * (double)direction;
                double num6 = System.Math.Cos(num5);
                double num7 = System.Math.Sin(num5);
                Complex[] array = new Complex[num2];
                for (int i = 0; i < num2; i++)
                {
                    array[i] = new Complex(num3, num4);
                    double num8 = (num3 * num7) + (num4 * num6);
                    num3 = (num3 * num6) - (num4 * num7);
                    num4 = num8;
                }

                complexRotation[numberOfBits - 1, num] = array;
            }

            return complexRotation[numberOfBits - 1, num];
        }

        private static void ReorderData(Complex[] data)
        {
            int num = data.Length;
            if (num < 2 || num > 16384 || !num.IsPowerOf2())
            {
                throw new ArgumentException("Incorrect data length.");
            }

            int[] array = GetReversedBits((int)System.Math.Log2(num));
            for (int i = 0; i < num; i++)
            {
                int num2 = array[i];
                if (num2 > i)
                {
                    (data[num2], data[i]) = (data[i], data[num2]);
                }
            }
        }
    }
}
