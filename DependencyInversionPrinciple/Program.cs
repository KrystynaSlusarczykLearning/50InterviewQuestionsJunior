using System;

namespace DependencyInversionPrinciple
{
    class YourStore
    {
        private readonly IDelivery _delivery;

        public YourStore(IDelivery delivery) { _delivery = delivery; }

        public void SellItem(string item, string address)
        {
            var package = PerparePackage(item, address);
            _delivery.DeliverPackage(package);
        }

        private string PerparePackage(string item, string address)
        {
            return "package ready to be shipped";
        }
    }

    public interface IDelivery
    {
        void DeliverPackage(string package);
    }

    internal class FastWheelsDelivery : IDelivery
    {
        public void DeliverPackage(string package)
        {
            //delivering with a bike
        }
    }

    internal class HeavyCargoDelivery : IDelivery
    {
        public void DeliverPackage(string package)
        {
            //delivering accross the country even the heaviest washing machines!
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.ReadKey();
        }
    }
}


