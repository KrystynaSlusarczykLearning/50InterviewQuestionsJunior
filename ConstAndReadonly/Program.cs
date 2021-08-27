using System;

namespace ConstAndReadonly
{
    class Program
    {
        //must be assigned at declaration
        // private const int ConstNumber; 

        private const int OtherConstNumber = 4;

        //must be compile-time constant
        // private const int ConstCurrentYear = DateTime.Now.Year; 

        //must be compile-time constant
        //private const Person ConstPerson = new Person("John", "Smith", 1980); 
        
        // private static const int StaticConst = 6; //const can't be declared static - it is implicitely static

        private readonly int ReadonlyCurrentYear = DateTime.Now.Year; //readonly does not need to be compile-time constant
        private readonly Person ReadonlyPerson = new Person("John", "Smith", 1980);
        private static readonly int StaticReadonly = 6;

        private readonly int ReadonlyNumber;

        //it is fine to assign readonly number at declaration
        private readonly int OtherReadonlyNumber = 4; 

        public Program() //constructor
        {
            //this will not compile because we can only assign consts at declaration
            //ConstNumber = 5; 

            //it is fine to assign readonly value in constructor
            ReadonlyNumber = 10;

            //we can also assign a value even if we already did it at declaration
            OtherReadonlyNumber = 12; 
        }

        static void Main(string[] args)
        {
            const float PI = 3.14f;
            const int DaysInWeek = 7;
            const int MaxSizeOfAnArray = 20; //assuming this is the designed limitation
            const int BitsInByte = 8;

            // ReadonlyNumber = 20; //this will not compile as we can only assign readonly number
            //at declaration or in constructor
        }
    }

    class Person
    {
        public string Name;
        public string LastName;
        public int YearOfBirth;

        public Person(string name, string lastName, int yearOfBirth)
        {
            Name = name;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
        }
    }
}
