using Gaten.Net.GameRule.osu.OsuFile;

using System;
using System.Diagnostics;

namespace Gaten.GameTool.osu.Mosu_
{
    public class Conversion
    {
        public static void ChangeMp3Tempo(string srcPath, string destPath, int tempoValue)
        {
            try
            {
                Process.Start(new ProcessStartInfo("mp3stretch.bat")
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    WorkingDirectory = Environment.CurrentDirectory + @"\lll\",
                    Arguments = $"\"{srcPath}\" \"{destPath}\" \"-tempo={tempoValue}\""
                })?.WaitForExit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ChangeOggTempo(string srcPath, string destPath, int tempoValue)
        {
            try
            {
                //string oggFileName = srcPath.Substring(srcPath.LastIndexOf('\\') + 1);
                //string oggFileId = oggFileName.Substring(0, oggFileName.LastIndexOf('.'));
                //string wavFileName = $"{oggFileId}_temp.wav";
                //string convertedWavFileName = $"{oggFileId}_temp_c.wav";

                //// Ogg to Wav
                //using (VorbisWaveReader reader = new VorbisWaveReader(srcPath))
                //{
                //    WaveFileWriter.CreateWaveFile(wavFileName, reader);
                //}

                //// Wav Time Stretch
                //Process.Start(new ProcessStartInfo("wavstretch.bat")
                //{
                //    WindowStyle = ProcessWindowStyle.Hidden,
                //    CreateNoWindow = true,
                //    WorkingDirectory = Environment.CurrentDirectory + @"\lll\",
                //    Arguments = $"\"{wavFileName}\" \"{convertedWavFileName}\" \"-tempo={tempoValue}\""
                //})?.WaitForExit();

                // Wav to Ogg
                //Xabe.FFmpeg.InputBuilder.

                //using (WaveFileReader reader = new WaveFileReader(convertedWavFileName))
                //{
                //    NVorbis.Contracts.
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ChangeOsuTempo(string srcPath, string destPath, int tempoValue)
        {
            try
            {
                string sign = tempoValue >= 0 ? "+" : "";
                double rate = (double)(tempoValue + 100) / 100;

                OsuFileObject obj = new(srcPath);
                obj.Read();

                // 난이도 이름 수정
                if (obj.Metadata["Version"] != null)
                {
                    obj.Metadata["Version"] += $"({sign}{tempoValue})";
                }

                // 프리뷰 타임 수정
                if (obj.General["PreviewTime"] != null)
                {
                    obj.General["PreviewTime"] = ((int)(int.Parse(obj.General["PreviewTime"]) / rate)).ToString();
                }

                // 북마크 수정
                if (obj.Bookmarks != null)
                {
                    for (int i = 0; i < obj.Bookmarks.Count; i++)
                    {
                        obj.Bookmarks[i] = (int)(obj.Bookmarks[i] / rate);
                    }
                }

                // 타이밍 포인트 수정
                for (int i = 0; i < obj.TimingPoints.Count; i++)
                {
                    obj.TimingPoints[i].TimingPosition /= rate;

                    if (obj.TimingPoints[i].OneBeatMillisecond > 0)
                        obj.TimingPoints[i].OneBeatMillisecond /= rate;
                }

                // 노트 타이밍 수정
                for (int i = 0; i < obj.HitObjects.Count; i++)
                {
                    obj.HitObjects[i].TimingPosition = (int)(obj.HitObjects[i].TimingPosition / rate);
                }

                // 매니아 모드면 롱노트 끝나는 타이밍도 수정해줘야함
                if (obj.General["Mode"].Equals("3"))
                {
                    for (int i = 0; i < obj.HitObjects.Count; i++)
                    {
                        string[] data = obj.HitObjects[i].C.Split(':');
                        if (data[0] != "0")
                        {
                            data[0] = ((int)(double.Parse(data[0]) / rate)).ToString();
                            obj.HitObjects[i].C = string.Join(":", data);
                        }
                    }
                }

                obj.Write(destPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
