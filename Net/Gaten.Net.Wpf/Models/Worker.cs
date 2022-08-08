using Gaten.Net.Wpf.Controls;

using System;
using System.ComponentModel;
using System.Threading;

namespace Gaten.Net.Wpf.Models
{
    public class Worker
    {
        BackgroundWorker worker;
        public TextProgressBar ProgressBar { get; set; } = default!;
        public Action<Worker, object?> Action { get; set; } = default!;
        public bool IsRunning { get; set; }
        public bool IsWaiting { get; set; }
        public object? Arguments { get; set; }

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

        public void For(int from, int to, int unit, Action<int> action)
        {
            var jobCount = System.Math.Abs(to - from);
            SetProgressBar(from, to - 1);
            for(int i = from; i < to; i+= unit)
            {
                Progress(i);
                ProgressText($"{i - from + 1} / {jobCount}");
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
