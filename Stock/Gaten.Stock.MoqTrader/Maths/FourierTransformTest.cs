using Gaten.Net.IO;
using Gaten.Net.Math;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Numerics;

namespace Gaten.Stock.MoqTrader.Maths
{
    internal class FourierTransformTest
    {
        public FourierTransformTest()
        {
        }

        public static void TestFFT()
        {
            CompositeWave compositeWave = new();
            compositeWave.AddWave(new SineWave(4096, 35, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 46, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 57, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 68, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 79, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 98, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 124, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 284, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 350, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 411, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 441, 30, 1));
            compositeWave.AddWave(new SineWave(4096, 677, 30, 1));
            var complices = compositeWave.Complices;
            FourierTransform.FFT(complices, FourierTransform.Direction.Forward);
            FourierTransform.GetSmartPeaks(complices);
        }

        public static Complex[] MakeTestSignWave()
        {
            var amp = 16;
            var freq = 3;

            List<Complex> data = new List<Complex>();
            var dataCount = Math.Pow(2, 12);

            for (int i = 0; i < dataCount; i++)
            {
                data.Add(new Complex((int)(amp * Math.Sin(2 * Math.PI * i * freq / 60)), 0));
            }

            return data.ToArray();
        }

        public static void SaveTestData(Complex[] data)
        {
            List<string> contents = new List<string>();
            foreach(var d in data)
            {
                contents.Add(d.Real.ToString());
            }
            GFile.WriteByArray(GPath.Desktop.Down("FT_data").Down("test.csv"), contents);
        }

        public static Complex[] LoadTestData()
        {
            List<Complex> complexes = new List<Complex>();

            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() ?? true)
            {
                var data = GFile.ReadToArray(dialog.FileName);
                foreach(var d in data)
                {
                    complexes.Add(new Complex(double.Parse(d), 0));
                }
            }

            return complexes.ToArray();
        }
    }
}
