using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace TextAnalyzer
{
    public class Engine
    {
        BlockingCollection<string> queue;
        ConcurrentDictionary<string, int> dictionary;

        public List<string> GetTriplets(string filepath, CancellationToken token)
        {
            int threadNumber = Environment.ProcessorCount;
            queue = new BlockingCollection<string>(threadNumber);
            dictionary = new ConcurrentDictionary<string, int>(threadNumber, 64);
            List<Task> consumers = CreateConsumers(threadNumber, token);
            FileReader producer = new FileReader();
            producer.Read(filepath, queue, token);
            Task.WaitAll(consumers.ToArray());
            return GetTenMostFrequentTriplets();
        }

        List<Task> CreateConsumers(int numberOfConsumers, CancellationToken token)
        {
            List<Task> consumers = new List<Task>();
            for (int i = 0; i < numberOfConsumers; i++)
            {
                TripletExtractor worker = new TripletExtractor(queue, dictionary, token);
                consumers.Add(Task.Factory.StartNew(() => worker.Run(), TaskCreationOptions.AttachedToParent));
            }
            return consumers;
        }

        List<string> GetTenMostFrequentTriplets()
        {
            List<int> requencies = new List<int>(new int[10]);
            List<string> triplets = new List<string>(new string[10]);
            int i;
            foreach (var entry in dictionary)
            {
                for(i = 0; i < 10; i++)
                {
                    if (entry.Value > requencies[i])
                    {
                        RightShiftListFromPosition(requencies, i);
                        requencies[i] = entry.Value;
                        RightShiftListFromPosition(triplets, i);
                        triplets[i] = entry.Key;
                        break;
                    } 
                }
            }
            return triplets.TakeWhile(s => !String.IsNullOrEmpty(s)).ToList();
        }

        void RightShiftListFromPosition<T>(List<T> list, int pos)
        {
            if (pos == list.Count - 1)
            {
                return;
            }
            for (int i = list.Count - 2; i >= pos; i--)
            {
                list[i + 1] = list[i];
            }
            return;
        }
    }
}
