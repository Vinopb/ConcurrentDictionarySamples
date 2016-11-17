using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentDictionarySamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new ConcurrentDictionary<string, string>();

           var value=  dict.GetOrAdd("key", x => "The First Value");
            Console.WriteLine(value);

            value = dict.GetOrAdd("key", x => "The Secnd Value");
            Console.WriteLine(value);


           
        }

       
    }
}
