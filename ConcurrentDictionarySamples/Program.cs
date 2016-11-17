using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentDictionarySamples
{
    class Program
    {
        private static int runCount = 0;
        private static readonly ConcurrentDictionary<string, string> dict = 
            new ConcurrentDictionary<string, string>();

        static void Main(string[] args)
        {


            var task1 = Task.Run(() => PrintValue("The Firs Value"));
            var task2 = Task.Run(() => PrintValue("The Second Value"));

            Task.WaitAll(task1, task2);

            PrintValue("The Third Value");
            Console.WriteLine($"Run Count :{runCount}");
            Console.ReadLine();
        }

        private static void PrintValue(string valueToPrint)
        {
           var valueToFound = dict.GetOrAdd("key",
                x =>
                 {
                     Interlocked.Increment(ref runCount);
                     Thread.Sleep(100);
                     return valueToPrint;
                 });
            Console.WriteLine(valueToFound);
        }

       
    }
}
