using System;
using System.Collections.Generic;

namespace MMR.Common.Utils
{
    public static class DictionaryHelper
    {
        public static Dictionary<string, List<string>> FromProgramArguments(string[] args)
        {
            var result = new Dictionary<string, List<string>>();
            if (args.Length == 0)
            {
                return result;
            }
            string currentArgument = null;
            foreach (var arg in args)
            {
                if (arg.StartsWith("-"))
                {
                    currentArgument = arg;
                    result[currentArgument] = new List<string>();
                    continue;
                }
                if (currentArgument == null)
                {
                    throw new ArgumentException($"Error: unnamed argument '{arg}'");
                }
                result[currentArgument].Add(arg);
            }
            return result;
        }
    }
}
