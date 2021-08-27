using System.Collections.Generic;

namespace NewKeyword
{
    class NewOperator
    {
        public static void CreateSomeObjects()
        {
            //new operator
            var rachel = new Person("Rachel", 34); //constructor call

            Person john = new("John", 19); //C# 9 style

            var steve = new Person { Name = "Steve", Age = 45 }; //object initialization

            var currencies = new Dictionary<string, string> //collection initialization
            {
                ["USA"] = "USD",
                ["Great Britain"] = "GBP"
            };

            var numbers = new int[4]; //array creation

            var person = new { Name = "Anna", Age = 55 }; //anonymous type 
        }
    }

    class Person
    {
        public string Name;
        public int Age;

        public Person()
        {

        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
