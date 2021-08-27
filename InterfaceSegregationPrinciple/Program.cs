using System;
using System.Collections.Generic;

namespace InterfaceSegregationPrinciple
{
    class Program
    {
        public interface IBike
        {
            void Ride();
            void InflateTheTyre();
            void Charge();
        }

        public class ElectricBike : IBike
        {
            public void Ride()
            {
                Console.WriteLine("Use your muscles to move forward.");
            }

            public void InflateTheTyre()
            {
                Console.WriteLine("Use the pump to inflate the tyre.");
            }

            public void Charge()
            {
                Console.WriteLine("Charging the battery of an electric bike.");
            }
        }

        public class Bike : IBike
        {
            //this method is problematic
            public void Charge()
            {
                throw new NotSupportedException("Non-electric bike cannot be charged.");
            }

            public void Ride()
            {
                Console.WriteLine("Use your muscles to move forward.");
            }

            public void InflateTheTyre()
            {
                Console.WriteLine("Use the pump to inflate the tyre.");
            }
        }

        private static void AddElementToList(IList<int> list)
        {
            list.Add(1);
        }

        static void Main(string[] args)
        {
            var list = new List<int>();
            var array = new int[0];

            AddElementToList(list); //this will work fine
            AddElementToList(array); //this will throw NotSupportedException

            Console.ReadKey();
        }
    }
}
