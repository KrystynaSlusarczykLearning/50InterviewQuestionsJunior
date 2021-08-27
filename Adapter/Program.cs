using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter
{
    public class Hotel
    {
        public string Name { get; }

        public Hotel(string name)
        {
            Name = name;
        }
    }

    public interface IHotelsByCityFinder
    {
        IEnumerable<Hotel> FindByCity(string city);
    }

    public interface IHotelsByZipCodeFinder
    {
        IEnumerable<Hotel> FindByZipCode(string zipCode);
    }

    public class HotelsByZipCodeFinder : IHotelsByZipCodeFinder
    {
        public IEnumerable<Hotel> FindByZipCode(string zipCode)
        {
            switch(zipCode)
            {
                case "E1 6AN":
                    return new[] { new Hotel("Imperial Hotel"), new Hotel("Golden Duck Hotel") };
                case "E1 7AA":
                    return new[] { new Hotel("Ambassador Hotel") };
                default:
                    return Enumerable.Empty<Hotel>();
            }
        }
    }

    public class HotelsByCityFinderAdapter : IHotelsByCityFinder
    {
        private readonly IHotelsByZipCodeFinder _hotelsByZipCodeFinder;

        public HotelsByCityFinderAdapter(IHotelsByZipCodeFinder hotelsByZipCodeFinder)
        {
            _hotelsByZipCodeFinder = hotelsByZipCodeFinder;
        }

        public IEnumerable<Hotel> FindByCity(string city)
        {
            var zipCodes = GetZipCodesForCity(city);
            return zipCodes.SelectMany(zipCode => _hotelsByZipCodeFinder.FindByZipCode(zipCode));
        }

        private IEnumerable<string> GetZipCodesForCity(string city)
        {
            if(city == "London")
            {
                return new[] { "E1 6AN", "E1 7AA" };
            }
            throw new Exception("Unknown city");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IHotelsByCityFinder hotelsFinder = new HotelsByCityFinderAdapter(new HotelsByZipCodeFinder());
            var hotelsInLondon = hotelsFinder.FindByCity("London");
            Console.WriteLine($"Hotels in London: {string.Join(", ", hotelsInLondon.Select(h => h.Name))}");

            Console.ReadKey();
        }
    }
}
