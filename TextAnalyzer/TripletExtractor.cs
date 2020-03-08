using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace TextAnalyzer
{
    class TripletExtractor
    {
        string matchPattern = @"(\p{L}){3}";
        Regex regex;
        BlockingCollection<string> source;
        ConcurrentDictionary<string, int> destination;
        CancellationToken token;

        public TripletExtractor(BlockingCollection<string> source, ConcurrentDictionary<string, int> destination, CancellationToken token)
        {
            this.source = source;
            this.destination = destination;
            regex = new Regex(matchPattern);
            this.token = token;
        }

        public void Run()
        {
            foreach (var item in source.GetConsumingEnumerable())
            {
                MatchTriplets(item);
            }
        }

        void MatchTriplets(string s)
        {

            for (int i = 0; i < s.Length - 2; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                Match match = regex.Match(s, i);
                if (match.Success)
                {
                    i = match.Index;
                    destination.AddOrUpdate(match.Value.ToLower(), 1, (key, curValue) => curValue + 1);
                }
                else
                {
                    return;
                }                    
            }
        }

    }
}
