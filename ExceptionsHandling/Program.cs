using System;

namespace ExceptionsHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"6/3 is {DivideNumbers(6, 3)}\n\n");
            Console.WriteLine($"6/0 is {DivideNumbers(6, 0)}\n\n");

            //global try-catch block
            try
            {
                Application.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception was thrown by the application," +
                    $" error message is: {ex.Message}");
            }
            finally
            {
                Console.WriteLine(
                    "Application will close. " +
                    "No exception have been caught by the global try-catch block.");
            }

            Console.ReadKey();
        }

        private static int? DivideNumbers(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Attempt to divide by zero." +
                    $" Exception message: {ex.Message}");
                return null;
            }
            finally
            {
                Console.WriteLine("Executing finally block");
            }
        }

        private static int? ElementAtIndex(int[] numbers, int index)
        {
            try
            {
                return numbers[index];
            }
            //catch clauses in order from the most specific to the most generic
            catch (NullReferenceException)
            {
                Console.WriteLine($"Input array is null");
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Index {index} does not exist in input array");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error, see message: {ex.Message}");
                return null;
            }
        }
    }

    internal class Application
    {
        internal static void Run()
        {
            //imagine some application logic here...
        }
    }
}
