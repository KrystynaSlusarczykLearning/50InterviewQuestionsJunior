using System;
using System.Collections.Generic;

namespace MethodOverloading
{
    class Program
    {

        private static int Add(int a, int b)
        {
            return a + b;
        }

        private static int Add(ref int a, ref int b)
        {
            return a + b;
        }

        //does not compile - the methods can't differ only by ref/out modifiers
        //private static int Add(ref int a, out int b)
        //{
        //    return a + b;
        //}

        //does not compile - the methods can't differ only by return type
        //private static string Add(int a, int b) 
        //{
        //    return a.ToString() + b.ToString();
        //}

        private static string Add(string a, string b)
        {
            return a + b;
        }

        private static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        private static void Add(List<int> list, int newElement)
        {
            list.Add(newElement);
        }

        private static void Add(int newElement, List<int> list)
        {
            list.Add(newElement * 2);
        }

        private static void TestMethod(int a)
        {
            Console.WriteLine("calling method without optional parameter.");
        }

        private static void TestMethod(int a, int b = 0)
        {
            Console.WriteLine("calling method with optional parameter.");
        }

        static void Main(string[] args)
        {
            //var someInt = Add(1, 2);
            //var someString = Add(1, 2); //how can the compiler know which one I mean?

            //the method without optional parameters will be called
            TestMethod(5);

            Console.ReadKey();
        }
    }
}
