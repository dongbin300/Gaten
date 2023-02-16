using Gaten.Audio.Waver.Models;
using Gaten.Net.Extensions;
using Gaten.Visual.DataVisualizer;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Gaten.Audio.Waver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WaveVisualizer innerWaveVisualizer = new WaveVisualizer();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Wave Create
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            int freq = int.Parse(FreqTextBox.Text);
            double duration = double.Parse(DurationTextBox.Text);
            double volume = double.Parse(VolumeTextBox.Text);
            int sampleRate = 48000;
            int bitRate = 32;
            int channel = 2;
            int defaultAmplifier = (int)Math.Pow(2, bitRate - 7);

            string fileName = $"{freq}Hz{duration}s{volume}V{sampleRate}Hz{bitRate}b{channel}c.wav";

            List<byte>? contents = new();

            contents.AddRange(1179011410.ToBytes());
            contents.AddRange(((duration * sampleRate * channel * bitRate / 8) + 36).ToBytes());
            contents.AddRange(1163280727.ToBytes());
            contents.AddRange(544501094.ToBytes());
            contents.AddRange(16.ToBytes());
            contents.AddRange(((ushort)1).ToBytes());
            contents.AddRange(((ushort)channel).ToBytes());
            contents.AddRange(sampleRate.ToBytes());
            contents.AddRange((sampleRate * channel * bitRate / 8).ToBytes());
            contents.AddRange(((ushort)(channel * bitRate / 8)).ToBytes());
            contents.AddRange(((ushort)bitRate).ToBytes());
            contents.AddRange((duration * sampleRate * channel * bitRate / 8).ToBytes());

            for (long i = 0; i < (long)sampleRate * duration * channel; i++)
            {
                contents.AddRange(((int)(
                    volume *
                    defaultAmplifier *
                    Math.Sin(2 * Math.PI * i * freq / sampleRate))).ToBytes());
            }

            File.WriteAllBytes(fileName, contents.ToArray());
            MessageBox.Show("생성 완료");
        }

        private void DataButton_Click(object sender, RoutedEventArgs e)
        {
            int freq = int.Parse(FreqTextBox.Text);
            double duration = double.Parse(DurationTextBox.Text);
            double volume = double.Parse(VolumeTextBox.Text);
            int sampleRate = 48000;
            int bitRate = 32;
            int channel = 2;
            int defaultAmplifier = (int)Math.Pow(2, bitRate - 7);

            string fileName = $"{freq}Hz{duration}s{volume}V{sampleRate}Hz{bitRate}b{channel}c.txt";

            List<int> contents = new();

            for (long i = 0; i < (long)sampleRate * duration * channel; i++)
            {
                contents.Add((int)(
                    volume *
                defaultAmplifier *
                    Math.Sin(2 * Math.PI * i * freq / sampleRate)));
            }

            File.WriteAllLines(fileName, contents.Select(x => x.ToString()));
            MessageBox.Show("생성 완료");
        }
        #endregion

        #region Wave Read
        private void SelectWavFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Wav Files|*.wav";

            if(dialog.ShowDialog() ?? false)
            {
                var wavFile = new WavFile(dialog.FileName);

                innerWaveVisualizer.Init(wavFile.Data);
                InnerWaveVisualizer.Content = innerWaveVisualizer;
            }
        }
        #endregion
    }
}
