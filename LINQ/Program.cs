using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var pirates = new List<Person>
            {
                new Person("Anne", "Bonny", 1698),
                new Person("Charles", "Vane", 1680),
                new Person("Mary", "Read", 1690),
                new Person("Bartolomew", "Roberts", 1682),
            };

            var bornAfter1685QuerySyntax = from pirate in pirates
                                where pirate.YearOfBirth > 1685
                                select pirate;

            var bornAfter1685MethodSyntax = pirates.Where(pirate => pirate.YearOfBirth > 1685);

            foreach (var pirate in bornAfter1685QuerySyntax)
            {
                Console.WriteLine($"{pirate.Name} {pirate.LastName} was born after 1685");
            }

            IEnumerable<Person> orderedByLastName = pirates.OrderBy(pirate => pirate.LastName);

            IEnumerable<int> onlyYearsOfBirth = pirates.Select(pirate => pirate.YearOfBirth);

            double averageYearOfBirth = pirates.Average(pirate => pirate.YearOfBirth);

            bool isAnyPirateBornBefore1650 = pirates.Any(pirate => pirate.YearOfBirth < 1650);

            bool areAllPiratesBornAfter1650 = pirates.All(pirate => pirate.YearOfBirth > 1650);

            IEnumerable<Person> piratesWithLastNameStartingWithR = pirates.Where(
                pirate => pirate.LastName.StartsWith("R"));

            Person firstPirateByAlphabet = pirates.OrderBy(pirate => pirate.LastName).First();

            IEnumerable<Person> piratesFromYoungestToOldest = pirates.OrderBy(
                pirate => pirate.YearOfBirth).Reverse();

            Console.ReadKey();
        }
    }
}
