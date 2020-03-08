using System;
using System.Diagnostics;
using System.IO;
using TextAnalyzer;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using TextAnalyzerApp.Resources;

namespace TextAnalyzerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            if (args.Length == 0)
            {
                Console.WriteLine(ConsoleMessages.EnterFilepath);
                path = Console.ReadLine();
            }
            else
            {
                path = args[0];
            }

            if (File.Exists(path))
            {
                AnalyzeFile(path);
            }
            else
            {
                Console.WriteLine(ConsoleMessages.NoSuchFile);
            }
        }

        static void AnalyzeFile(string path)
        {
            var engine = new Engine();
            CancellationTokenSource cts = new CancellationTokenSource();
            Task.Factory.StartNew(() => CancelProcessingWhenKeyPressed(cts), TaskCreationOptions.AttachedToParent);
            Stopwatch sw = new Stopwatch();
            try
            {
                sw.Start();
                var result = engine.GetTriplets(path, cts.Token);
                sw.Stop();
                PrintResult(result, sw);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ConsoleMessages.FailedToProcessFile + ex.GetType().Name);
            }
        }

        static void CancelProcessingWhenKeyPressed(CancellationTokenSource cts)
        {
            Console.ReadKey();
            Console.WriteLine();
            cts.Cancel();
        }
        
        static void PrintResult(List<string> result, Stopwatch sw)
        {
            if (result.Count != 0)
            {
                Console.WriteLine(ConsoleMessages.MostFrequentTriplets, result.Count);
                Console.WriteLine(string.Join(", ", result));
            }
            else
            {
                Console.WriteLine(ConsoleMessages.NoTripletsFound);
            }
            Console.WriteLine(ConsoleMessages.ElapsedTime + sw.ElapsedMilliseconds);
        }
    }
}
