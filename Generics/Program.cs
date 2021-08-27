using System;
using System.Collections.Generic;

namespace Generics
{
    //non-generic classes
    public class IntegersList
    {
        public void Add(int item)
        {
            //...
        }
    }

    public class StringsList
    {
        public void Add(string item)
        {
            //...
        }
    }

    public class DoublesList
    {
        public void Add(double item)
        {
            //...
        }
    }

    //generic class
    public class List<T>
    {
        public void Add(T item)
        {
            //...
        }
    }

    #region constraints

    public class OnlyReferenceTypes<T> where T : class
    {

    }

    public class OnlyValueTypes<T> where T : struct
    {

    }

    public class OnlyTypesWithParameterlessConstructor<T> where T : new()
    {

    }

    public class BaseClass
    {

    }

    public class OnlyDerivedFromBaseClass<T> where T : BaseClass
    {

    }

    public interface IFlying
    {

    }

    public class OnlyImplementingIFlyingInterface<T> where T : IFlying
    {

    }

    #endregion

    public class Program
    {
        static void Main(string[] args)
        {
            var currencies = new Dictionary<string, string> 
            {
                ["USA"] = "USD",
                ["Great Britain"] = "GBP"
            };

            var yearsOfBirth = new Dictionary<string, int>
            {
                ["John Smith"] = 1980,
                ["Monica Smith"] = 1983
            };

            //var invalidObject = new OnlyImplementingIFlyingInterface<int>(); //will not compile as constraint is not met
           
            Console.ReadKey();
        }
    }
}
