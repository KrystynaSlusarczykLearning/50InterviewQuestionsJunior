using System;
using System.Collections.Generic;

namespace NullOperators
{
    class Greeter
    {
        public static string Greet(string name)
        {
            return $"Hello, {name ?? "Stranger"}!";
        }
    }

    static class ListExtensions
    {
        public static int GetAtIndex(this List<int?> numbers, int index)
        {
            return numbers?[index] ??
                throw new ArgumentException($"Index {index} not found " +
                $"in the list or value is null.");
        }

        public static void ClearIfNotNull(this List<int?> numbers)
        {
            numbers?.Clear();
        }
    }

    class Program
    {
        private static List<int> _numbers;

        static void Main(string[] args)
        {
            (_numbers ??= new List<int>()).Add(5);
        }
    }
}
