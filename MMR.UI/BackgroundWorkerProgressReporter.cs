using MMR.Randomizer;
using System.ComponentModel;

namespace MMR.UI
{
    public class BackgroundWorkerProgressReporter : IProgressReporter
    {
        private readonly BackgroundWorker _worker;
        public BackgroundWorkerProgressReporter(BackgroundWorker worker)
        {
            _worker = worker;
        }

        public void ReportProgress(int percentProgress, string message)
        {
            _worker.ReportProgress(percentProgress, message);
        }
    }
}
