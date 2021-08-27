using System;

namespace Params
{
    class Program
    {
        //this will not compile - params keyword can only be applied to the last parameter 
        //static void SomeFunction(params int[] numbers, int multiplier, params[] otherNumber)
        //{

        //}

        //this will not compile - params keyword must be used with single-dimensional array
        //static void SomeFunction(params List<int> numbers)
        //{

        //}

        static int ClumsySum(int[] numbers)
        {
            var sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        static int Sum(params int[] numbers)
        {
            var sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            ClumsySum(new[] { 1, 2 });
            ClumsySum(new[] { 1, 2, 3, 4 });
            ClumsySum(new int[] { });

            //the below definitely looks better than the above
            Sum(1, 2);
            Sum(1, 2, 3, 4);
            Sum();

            Console.ReadKey();
        }
    }
}
