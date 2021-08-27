using System;

namespace CommonIntermediateLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! What's your name?");
            var name = Console.ReadLine();

            Console.WriteLine($"Nice to meet you, {name}. How old are you?");

            var ageAsText = Console.ReadLine();

            if(int.TryParse(ageAsText, out int age))
            {
                Console.WriteLine($"That young, only {age}?");
            }
            else
            {
                Console.WriteLine("Sorry, I didn't get that.");
            }
            Console.WriteLine("Well, it was nice to meet you! Bye, bye!");
            Console.ReadKey();
        }
    }
}

