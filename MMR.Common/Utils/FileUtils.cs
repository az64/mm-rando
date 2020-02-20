using System.IO;

namespace MMR.Common.Utils
{
    public static class FileUtils
    {
        public static string MakeFilenameValid(string filename)
        {
            foreach (var c in Path.GetInvalidFileNameChars()) { filename = filename.Replace(c, '-'); }
            return filename;
        }
    }
}
