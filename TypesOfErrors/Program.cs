using System;
using System.Collections.Generic;
using System.Linq;

namespace TypesOfErrors
{

    class Program
    {
        static void Main(string[] args)
        {
            //compilation error - missing semicolon
            //var number = 5

            //the code below will execute without exception, but the result will not be as expected
            var sentence = MergeWords("A", "little", "duck", "swims", "in", "a", "pond");
            Console.WriteLine(sentence);

            //the code below will produce a runtime error because we try to access first element of an empty list
            var list = new List<int>();
            var firstElement = list.First();

            Console.ReadKey();
        }

        private static object MergeWords(params string[] words)
        {
            return string.Join("", words);
            //should be:
            //return string.Join(" ", words);
        }
    }
}
