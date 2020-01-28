using System;
using System.Collections.Generic;

namespace Dijkstras_Algorithm
{
    public struct Node
    {
        public string Key { get; }
        public string Name { get; }
        public int Weight { get; }

        public Node(string key, string name, int weight)
        {
            this.Key = key;
            this.Name = name;
            this.Weight = weight;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Node> graph = new List<Node>();
            graph.Add(new Node("Start", "A", 6));
            graph.Add(new Node("Start", "B", 2));
            graph.Add(new Node("A", "Fin", 1));
            graph.Add(new Node("B", "A", 3));
            graph.Add(new Node("B", "Fin", 5));
            graph.Add(new Node("Fin", string.Empty, 1));

            Dictionary<string, int> costs = new Dictionary<string, int>();
            costs.Add("A", 6);
            costs.Add("B", 2);
            costs.Add("Fin", int.MaxValue);


            Dictionary<string, string> parents = new Dictionary<string, string>();
            parents.Add("A", "Start");
            parents.Add("B", "Start");
            parents.Add("Fin", string.Empty);

            Dijkstras(graph, costs, parents);

            foreach (var item in costs) {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Console.WriteLine('\n');

            foreach (var item in parents) {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        private static void Dijkstras(List<Node> graph, Dictionary<string, int> costs, Dictionary<string, string> parents)
        {
            var processed = new List<Node>();
            var node = LowestCodeNode(costs, graph, processed);

            while (node.Key != null)
            {
                var cost = costs[node.Name];
                var neighbours = new List<Node>();
                neighbours.AddRange(graph.FindAll(n => n.Key == node.Name));

                for (int i = 0; i < neighbours.Count; i++)
                {
                    if(string.IsNullOrEmpty(neighbours[i].Name)) {
                        continue;
                    }

                    var newCost = cost + neighbours[i].Weight;
                    var value = costs[neighbours[i].Name];

                    if(value > newCost)
                    {
                        costs[neighbours[i].Name] = newCost;
                        parents[neighbours[i].Name] = node.Name;
                    }
                }

                processed.Add(node);
                node = LowestCodeNode(costs, graph, processed);
            }
        }

        private static Node LowestCodeNode(Dictionary<string, int> costs, List<Node> graph, List<Node> processed)
        {
            var lowestCost = int.MaxValue;
            var lowestCostNode = new Node();

            foreach (var node in costs)
            {
                var cost = node.Value;

                if(cost < lowestCost && !processed.Exists(n => n.Name == node.Key))
                {
                    lowestCost = cost;
                    lowestCostNode = graph.Find(n => n.Name == node.Key);
                }
            }

            return lowestCostNode;
        }
    }
}
