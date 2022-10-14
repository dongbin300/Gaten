using Gaten.Net.Wpf.Controls;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace Gaten.Net.Wpf.Models
{
    [Flags]
    public enum ProgressBarDisplayOptions
    {
        Count = 0x01,
        Percent = 0x02,
        TimeRemaining = 0x04
    }

    public class Worker
    {
        public TextProgressBar ProgressBar { get; set; } = default!;
        public Action<Worker, object?> Action { get; set; } = default!;
        public bool IsRunning { get; set; }
        public object? Arguments { get; set; }

        BackgroundWorker worker;
        Stopwatch stopwatch;
        bool IsWaiting;

        public Worker()
        {
            worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            stopwatch = new Stopwatch();
        }

        public Worker(TextProgressBar progressBar) : this()
        {
            ProgressBar = progressBar;
        }

        public Worker Start()
        {
            IsRunning = true;
            IsWaiting = true;
            if (Arguments == null)
            {
                worker.RunWorkerAsync();
            }
            else
            {
                worker.RunWorkerAsync(Arguments);
            }

            return this;
        }

        public void Stop()
        {
            IsRunning = false;
            IsWaiting = false;
            worker.CancelAsync();
        }

        public void SetProgressBar(int min, int max)
        {
            ProgressBar.SetMinimum(min);
            ProgressBar.SetMaximum(max);
        }

        public void ProgressByPercent(int progressPercent)
        {
            worker.ReportProgress(progressPercent);
            Thread.Sleep(1);
        }

        public void Progress(double value)
        {
            ProgressBar.SetValue(value);
            Thread.Sleep(1);
        }

        public void ProgressText(string text)
        {
            ProgressBar.SetText(text);
        }

        public void For(int from, int to, int unit, Action<int> action, ProgressBarDisplayOptions options)
        {
            var jobCount = System.Math.Abs(to - from);
            SetProgressBar(from, to - 1);
            stopwatch.Start();
            for (int i = from; i < to; i += unit)
            {
                var elapsedMs = stopwatch.ElapsedMilliseconds;
                var estimatedTimeRemainingSeconds = (int)System.Math.Round(((elapsedMs * (double)to / i) - elapsedMs) / 1000, 0) + 1;
                var estimatedTimeRemainingString =
                    (estimatedTimeRemainingSeconds / 3600 > 0 ? estimatedTimeRemainingSeconds / 3600 + "h " : "") +
                    (estimatedTimeRemainingSeconds % 3600 / 60 > 0 ? estimatedTimeRemainingSeconds % 3600 / 60 + "m " : "") +
                    estimatedTimeRemainingSeconds % 60 + "s";
                Progress(i);
                ProgressText(
                    $"{(options.HasFlag(ProgressBarDisplayOptions.Count) ? $"{i - from + 1} / {jobCount}" : "")}" +
                    $"{(options.HasFlag(ProgressBarDisplayOptions.Percent) ? $" ({System.Math.Round((i - from + 1) / (double)jobCount, 4):P})" : "")}" +
                    $"{(options.HasFlag(ProgressBarDisplayOptions.TimeRemaining) ? $" {estimatedTimeRemainingString}" : "")}");
                action(i);
            }
        }

        public void Wait()
        {
            while (IsWaiting)
            {
                Thread.Sleep(5);
            }
        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            IsRunning = false;
            ProgressBar.ToMaximum();
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            ProgressBar.SetValue(e.ProgressPercentage);
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            IsRunning = true;
            IsWaiting = true;
            ProgressBar.ToMinimum();
            Action(this, e.Argument);
            IsWaiting = false;
        }
    }
}
