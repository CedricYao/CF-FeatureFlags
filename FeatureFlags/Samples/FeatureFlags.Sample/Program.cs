using System;
using System.Collections;

namespace FeatureFlags.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!");

            var envVariables = System.Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry entry in envVariables)
            {
                Console.WriteLine($"{entry.Key} -- {entry.Value}");
            }

            while (true)
            {

            }
        }
    }
}
