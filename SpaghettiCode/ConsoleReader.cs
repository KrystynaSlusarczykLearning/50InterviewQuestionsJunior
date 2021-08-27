using System;

namespace SpaghettiCode
{
    static class ConsoleReader
    {
        public static double ReadDouble(string variableName)
        {
            double result;
            bool wasParsingSuccessful;
            do
            {
                Console.WriteLine($"Enter {variableName}");
                var userInput = Console.ReadLine();
                wasParsingSuccessful = double.TryParse(userInput, out result);
                if (!wasParsingSuccessful)
                {
                    Console.WriteLine("Invalid format, please try again.");
                }
            }
            while (!wasParsingSuccessful);

            return result;
        }

        public static bool ReadBool(string question)
        {
            bool result = false;
            bool wasParsingSuccessful;
            Console.WriteLine($"{question} Enter Y or N");
            do
            {
                var userInput = Console.ReadLine();
                if (userInput == "Y")
                {
                    result = false;
                    wasParsingSuccessful = true;
                }
                else if (userInput == "N")
                {
                    result = true;
                    wasParsingSuccessful = true;
                }
                else
                {
                    Console.WriteLine("Invalid format, please try again. Enter Y or N");
                    wasParsingSuccessful = false;
                }
            }
            while (!wasParsingSuccessful);

            return result;
        }
    }    
}
