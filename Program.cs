using System;
using System.IO;
using System.Collections.Generic;

namespace Exercise_Dictionary {
    class Program {
        static void Main(string[] args) {
            Dictionary<string, int> keys = new Dictionary<string, int>();

            Console.WriteLine("Enter file full path: ");
            string path = Console.ReadLine();

            try {
                using (StreamReader sr = File.OpenText(path)) {
                    while (!(sr.EndOfStream)) {
                        string[] votingRecord = sr.ReadLine().Split(',');
                        string name = votingRecord[0];
                        int votes = int.Parse(votingRecord[1]);

                        if (keys.ContainsKey(name)) {
                            keys[name] += votes;
                        } else {
                            keys[name] = votes;
                        }
                    }

                    foreach (var candidate in keys) {
                        Console.WriteLine(candidate.Key + ", " + candidate.Value);
                    }
                }
            } catch (IOException e) {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
