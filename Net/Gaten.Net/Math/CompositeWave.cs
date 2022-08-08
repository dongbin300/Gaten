using System.Numerics;

namespace Gaten.Net.Math
{
    public class CompositeWave : IWave
    {
        public List<IWave> Waves { get; set; }
        public List<double> Magnitudes => CalculateMagnitudes();
        public Complex[] Complices => ToComplex();

        public CompositeWave()
        {
            Waves = new List<IWave>();
        }

        public void AddWave(IWave wave)
        {
            Waves.Add(wave);
        }

        public void RemoveWave(IWave wave)
        {
            Waves.Remove(wave);
        }

        public Complex[] ToComplex()
        {
            Complex[] result = new Complex[Magnitudes.Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new Complex(Magnitudes[i], 0);
            }

            return result;
        }

        private List<double> CalculateMagnitudes()
        {
            List<double> magnitudes = new List<double>();
            int maxCount = Waves.Max(x => x.Magnitudes.Count);
            for (int i = 0; i < maxCount; i++)
            {
                magnitudes.Add(Waves.Sum(x => x.Magnitudes.ElementAt(i)));
            }
            return magnitudes;
        }
    }
}
