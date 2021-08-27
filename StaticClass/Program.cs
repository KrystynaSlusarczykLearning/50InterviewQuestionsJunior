using System;

namespace StaticClass
{
    static class Calculator
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Power(double a)
        {
            return a * a;
        }
    }

    static class SystemMonitor
    {
        private static readonly DateTime _startTime;

        static SystemMonitor()
        {
            _startTime = DateTime.UtcNow;
        }

        public static string Report()
        {
            return $"Monitoring the system for " +
                $"{(DateTime.UtcNow - _startTime).TotalSeconds} seconds";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // var calculator = new Calculator(); //this will not compile
            var sum = Calculator.Add(4, 5);

            Console.WriteLine(SystemMonitor.Report());
            System.Threading.Thread.Sleep(1000); //wait one second
            Console.WriteLine(SystemMonitor.Report());

            Console.ReadKey();
        }
    }
}
