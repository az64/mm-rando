using MMR.Randomizer;
using System;

namespace MMR.CLI
{
    partial class Program
    {
        public class ProgressBarProgressReporter : IProgressReporter
        {
            private readonly ProgressBar _progressBar;

            public ProgressBarProgressReporter(ProgressBar progressBar)
            {
                _progressBar = progressBar;
            }

            public void ReportProgress(int percentProgress, string message)
            {
                //_progressBar.WriteLine(message);
                _progressBar.Report(new Tuple<double, string>(percentProgress / 100.0, message));
            }
        }
    }
}
