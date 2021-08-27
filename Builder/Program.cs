using System;

namespace Builder
{
    public class Person
    {
        private string Name { get; }
        private string LastName { get; }
        private int YearOfBirth { get; }
        private int Age { get; }

        private Person(string name, int yearOfBirth, int age)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
            Age = age;
        }

        public class Builder
        {
            private string _name;
            private int _yearOfBirth;
            private int _age;

            public Builder WithName(string name)
            {
                _name = name;
                return this;
            }

            public Builder WithYearOfBirth(int yearOfBirth)
            {
                if (yearOfBirth > DateTime.Now.Year || yearOfBirth < 1900)
                {
                    throw new Exception("Invalid year of birth");
                }
                _age = DateTime.Now.Year - yearOfBirth;
                _yearOfBirth = yearOfBirth;
                return this;
            }

            public Person Build()
            {
                return new Person(_name, _yearOfBirth, _age);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Person.Builder();
            var name = ReadName();
            builder = builder.WithName(name);
            //some other operations
            var year = ReadYear();
            builder = builder.WithYearOfBirth(year);
            //some other operations
            var person = builder.Build();


            var dog1 = new Pet("Dog", "Louis Charles Bryan the Third", "Rex", "Tina", "Lucky", "Happy Paws");
            var dog2 = new Pet.Builder()
                .WithType("Dog")
                .WithNickname("Rex")
                .WithOfficialName("Louis Charles Bryan the Third")
                .WithFatherName("Lucky")
                .WithMotherName("Tina")
                .WithBreedingCompanyName("Happy Paws");

            //var dog3 = new Pet //that requies adding public setters
            //{
            //    Type = "Dog",
            //    OfficialName = "Louis Charles Bryan the Third",
            //    Nickname = "Rex",
            //    MotherName = "Tina",
            //    FatherName = "Lucky",
            //    BreedingCompanyName = "Happy Paws"
            //};

            var invalidDog = new Pet.Builder().Build(); //no properties are set

            var catBuilder = new Pet.Builder()
                .WithType("Cat")
                .WithNickname("Leon");

            //some logic here...
            catBuilder = catBuilder.WithType("Dog"); //we override the original Type
            var cat = catBuilder.Build();

            var car = new Car() { Brand = "Mazda", Color = "Red" };
            var carAfterPainting = car with { Color = "Blue" }; //please note that Car is a record, not a class

            Console.ReadKey();
        }

        private static string ReadName()
        {
            //imagine this is some complicated process, like reading from a remote database
            return "Alex";
        }

        private static int ReadYear()
        {
            //imagine this is some complicated process, like reading from a remote database
            return 1980;
        }
    }
}
