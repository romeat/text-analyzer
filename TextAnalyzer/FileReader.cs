using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TextAnalyzer
{
    public class FileReader
    {
        public void Read(string filepath, BlockingCollection<string> target, CancellationToken token)
        {
            foreach (var line in File.ReadLines(filepath))
            {
                if (token.IsCancellationRequested)
                {
                    target.CompleteAdding();
                    return;
                }
                target.Add(line);
            }
            target.CompleteAdding();
        }
    }
}
