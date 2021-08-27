using System;

namespace Properties
{
    class Person
    {
        public int YearOfBirth
        {
            get
            {
                return _dateOfBirth.Year;
            }
            set
            {
                _dateOfBirth = new DateTime(value, _dateOfBirth.Month, _dateOfBirth.Day);
            }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value < DateTime.Now) //we don't allow dates from the future
                {
                    _dateOfBirth = value;
                }
            }
        }

        public DateTime? DateOfDeath { get; set; }

        public int? LengthOfLife
        {
            get
            {
                return DateOfDeath == null ? 
                    null :
                    (int)((DateOfDeath.Value - DateOfBirth).TotalDays / 365);
            }
        }

        public string Name { get; }

        public Person(int yearOfBirth, string lastName, string name)
        {
            YearOfBirth = yearOfBirth;
            LastName = lastName;
            Name = name;
        }

        private void SetName(string name)
        {
            //Name = name; //does not work since Name is readonly
        }


        public string LastName { get; private set; }

        private void SetLastName(string lastName)
        {
            //it's ok - we can change this private property within the Person class
            LastName = lastName; 
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(1950, "Smith", "John");
            //we can't do that because the setter is private
            //person.LastName = "Swanson"; 

            Console.ReadKey();
        }
    }
}
