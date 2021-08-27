using System;
using System.Collections.Generic;
using System.Linq;

namespace Nullable
{
    class NullableSample
    {
        //this doesnt work because string is already nullable (as reference type)
        // private Nullable<string> nullableString; 

        private Nullable<int> nullableInt; //default is null
        private int? alsoNullableInt; //shorter syntax
        private int nonNullableInt; //default is zero

        public void SomeMethod()
        {
            nullableInt = null;
            //nonNullableInt = null; //we can't assign null to non-nullable int
            nullableInt = 5;
            nonNullableInt = 5;

            if(nullableInt.HasValue)
            {
                Console.WriteLine($"Value is {nullableInt.Value}");
            }
            else
            {
                Console.WriteLine("Value is not present");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person("Jon", 160),
                new Person("Anna",-1),
                new Person("Monica",185),
                new Person("Sebastian",-1),
                new Person("Alice",170),
            };

            Console.WriteLine($"Average height is {people.Average(person => person.Height)}");

            var peopleWithNullableHeight = new List<PersonWithNullableHeight>
            {
                new PersonWithNullableHeight("Jon", 160),
                new PersonWithNullableHeight("Anna"),
                new PersonWithNullableHeight("Monica", 185),
                new PersonWithNullableHeight("Sebastian"),
                new PersonWithNullableHeight("Alice", 170),
            };

            Console.WriteLine($"[NULLABLE] Average height is {peopleWithNullableHeight.Average(person => person.Height)}");

            Console.ReadKey();
        }
    }

    class Person
    {
        public int Height;
        public string Name;

        public Person(string name, int height)
        {
            Name = name;
            Height = height;
        }
    }

    class PersonWithNullableHeight
    {
        public int? Height;

        public string Name;

        public PersonWithNullableHeight(string name)
        {
            Name = name;
            Height = null;
        }

        public PersonWithNullableHeight(string name, int height)
        {
            Name = name;
            Height = height;
        }
    }
}
