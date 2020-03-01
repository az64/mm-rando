using MMR.Randomizer;
using System.IO;

namespace MMR.CLI
{
    partial class Program
    {
        public class TextWriterProgressReporter : IProgressReporter
        {
            private readonly TextWriter _textWriter;

            public TextWriterProgressReporter(TextWriter textWriter)
            {
                _textWriter = textWriter;
            }

            public void ReportProgress(int percentProgress, string message)
            {
                _textWriter.WriteLine(message);
            }
        }
    }
}
