using System;
using System.Collections.Generic;

namespace StaticKeyword
{
    class Box
    {
        public static int MaxCount = 50;

        private List<string> elements = new List<string>();

        public void Add(string element)
        {
            if(elements.Count < MaxCount)
            {
                elements.Add(element);
            }
        }

        //can't be made static as it refers
        //to non-static elements field
        public int GetCurrentCount()
        {
            return elements.Count;
        }

        public static string FormatMaxCount()
        {
            return $"The max count for this Box is {MaxCount}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var box1 = new Box();
            var box2 = new Box();
            //var invalidMaxCount = box1.MaxCount; //this does not compile as we try to access static field on instance
            var maxCount = Box.MaxCount;
            var elementsCount = box2.GetCurrentCount();
            var maxCountFormatted = Box.FormatMaxCount();

            Console.ReadKey();
        }
    }
}
