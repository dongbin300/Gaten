namespace Gaten.Net.Math
{
    public class SineWave : IWave
    {
        public List<double> Magnitudes { get; }
        public int SampleRate { get; set; }
        public double Frequency { get; set; }
        public double Amplitude { get; set; }
        public double Duration { get; set; }
        public double Phase { get; set; }
        public double Crest { get; set; }
        public double Trough { get; set; }

        /// <summary>
        /// 사인파를 만듭니다.
        /// </summary>
        /// <param name="sampleRate">(샘플레이트)1초에 포함되는 magnitude 개수</param>
        /// <param name="frequency">(주파수)1초에 진동하는 회수</param>
        /// <param name="amplitude">(진폭)0과의 거리의 최대값</param>
        /// <param name="duration">(길이)파동의 길이(초 단위)</param>
        public SineWave(int sampleRate, double frequency, double amplitude, double duration, double phase = 0)
        {
            SampleRate = sampleRate;
            Frequency = frequency;
            Amplitude = amplitude;
            Duration = duration;
            Phase = phase;

            Crest = amplitude;
            Trough = -amplitude;

            Magnitudes = new List<double>();
            for (int i = 0; i < sampleRate * duration; i++)
            {
                Magnitudes.Add(amplitude * System.Math.Sin(2 * System.Math.PI * (i - phase) * frequency / sampleRate));
            }
        }
    }
}
