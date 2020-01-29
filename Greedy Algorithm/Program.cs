using System;
using System.Linq;
using System.Collections.Generic;

namespace Greedy_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var statesNeeded = new List<string>(new string[] { "mt", "wa", "or", "id", "nv", "ut", "ca", "az" });

            Dictionary<string, List<string>> stations = new Dictionary<string, List<string>>();
            stations.Add("kone", new List<string>(new string[] { "id", "nv", "ut" }));
            stations.Add("ktwo", new List<string>(new string[] { "wa", "id", "mt" }));
            stations.Add("kthree", new List<string>(new string[] { "or", "nv", "ca" }));
            stations.Add("kfour", new List<string>(new string[] { "nv", "ut" }));
            stations.Add("kfive", new List<string>(new string[] { "ca", "az" }));

            var finalStations = GreedyStationFind(stations, statesNeeded);

            foreach (var station in finalStations) {
                Console.WriteLine(station + " ");
            }
        }

        public static IEnumerable<string> GreedyStationFind(Dictionary<string, List<string>> stations, List<string> statesNeeded)
        {
            var finalStations = new List<string>();

            while (statesNeeded.Count > 0)
            {
                var bestStations = new KeyValuePair<string, List<string>>();
                var statesCovered = new List<string>();

                foreach (var station in stations)
                {
                    var states = new List<string>(station.Value);
                    var covered = statesNeeded.Intersect(states).ToList();

                    if(covered.Count > statesCovered.Count)
                    {
                        bestStations = station;
                        statesCovered.AddRange(covered);
                        statesCovered.Distinct();
                    }
                }

                statesNeeded.RemoveAll(s => statesCovered.Contains(s));
                finalStations.Add(bestStations.Key);
            }

            return finalStations;
        }
    }
}
