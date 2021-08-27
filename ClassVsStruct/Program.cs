using System;

namespace ClassVsStruct
{
    struct Point
    {
        public int x;
        public int y;

        //does not compile - struct can't have
        //explicit parameterless constuctor
        //public Point()
        //{

        //}

        //does not compile - all fields must be
        //assigned in the constructor
        //public Point(int x)
        //{

        //}

        //does not compile - structs can't have destructors
        //public ~Point() 
        //{

        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.ReadKey();
        }
    }
}
