using System;
using System.Collections.Generic;
using System.IO;

namespace VirtualAndAbstractMethods
{
    class Program
    {
        public abstract class Printer
        {
            public abstract void Print(string text);
        }

        public class TextFilePrinter : Printer
        {
            public override void Print(string text)
            {
                File.WriteAllText("someFile.txt", text);
            }
        }

        public class PersonDataBuilder
        {
            public virtual string BuildPersonData(string name, string lastName, int yearOfBirth)
            {
                return $"{name} {lastName} was born in {yearOfBirth}";
            }
        }

        public class EmbellishedPersonDataBuilder : PersonDataBuilder
        {
            public override string BuildPersonData(string name, string lastName, int yearOfBirth)
            {
                var prettyLine = "**――**――**――*****――**――**――**";
                return $"{prettyLine}\n" +
                    $"{base.BuildPersonData(name, lastName, yearOfBirth)}\n" +
                    $"{prettyLine}";
            }
        }

        static void Main(string[] args)
        {
            var personDataBuilders = new List<PersonDataBuilder>
            {
                new PersonDataBuilder(),
                new EmbellishedPersonDataBuilder()
            };

            foreach (var personDataBuilder in personDataBuilders)
            {
                Console.WriteLine($"{personDataBuilder.BuildPersonData("Jack", "Smith", 1798)}\n");
            }

            Console.ReadKey();
        }
    }
}
