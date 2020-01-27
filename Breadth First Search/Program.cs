using System;
using System.Collections.Generic;

namespace Breadth_First_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var personDict = new Dictionary<string, List<string>>();

            personDict.Add("Darren", new List<string>(new string[] { "Alice", "Bob", "Claire" }));
            personDict.Add("Bob", new List<string>(new string[] { "Anuj", "Peggy" }));
            personDict.Add("Alice", new List<string>(new string[] { "Peggy" }));
            personDict.Add("Claire", new List<string>(new string[] { "Thom", "Johnny" }));
            personDict.Add("Anuj", new List<string>(new string[] { }));
            personDict.Add("Peggy", new List<string>(new string[] { }));
            personDict.Add("Thom", new List<string>(new string[] { }));
            personDict.Add("Johnny", new List<string>(new string[] { }));

            Search("Darren", personDict);
        }

        private static void Search(string personName, Dictionary<string, List<string>> personDict)
        {
            var searchQueue = new Queue<string>(personDict[personName]);
            var searched = new List<string>();

            while (searchQueue.Count > 0)
            {
                var person = searchQueue.Dequeue();

                if(!searched.Exists(p => p == person))
                {
                    if(IsPersonSeller(person)) 
                    {
                        Console.WriteLine(person + " is a mango seller !");
                        return;
                    }

                    personDict[person].ForEach(p => searchQueue.Enqueue(p));
                    searched.Add(person);
                }
            }

            Console.WriteLine("There is no mango seller !");
        }

        private static bool IsPersonSeller(string name)
        {
            if(char.ToLowerInvariant(name.ToCharArray()[name.Length - 1]) == 'm') {
                return true;
            }

            return false;
        }
    }
}
