using System;

namespace MagicNumber
{
    class TaxRulesProvider
    {
        public const decimal VatRateLow = 1.05m;
        public const decimal VatRateMedium = 1.08m;
        public const decimal VatRateHigh = 1.23m;

        public class BakingIndustry
        {
            public const int ShortExpiryLimit = 14;
            public const int LongExpiryLimit = 45;
        }
    }

    class PriceCalculator
    {
        public decimal Calculate(
            decimal basePrice, bool isFrozen, bool isBakedGoods,
            bool isPie, int daysToExpiry)
        {
            if (isFrozen)
            {
                return basePrice * TaxRulesProvider.VatRateLow;
            }
            if (isBakedGoods && daysToExpiry <= 
                TaxRulesProvider.BakingIndustry.ShortExpiryLimit)
            {
                return basePrice * TaxRulesProvider.VatRateLow;
            }
            if (isPie && daysToExpiry <= 
                TaxRulesProvider.BakingIndustry.LongExpiryLimit)
            {
                return basePrice * TaxRulesProvider.VatRateMedium;
            }
            if (isPie && daysToExpiry > 
                TaxRulesProvider.BakingIndustry.LongExpiryLimit)
            {
                return basePrice * TaxRulesProvider.VatRateHigh;
            }
            else
            {
                throw new Exception("Invalid product");
            }
        }

        //warning - magic numbers below!
        //public double Calculate(
        //    double basePrice, bool isFrozen, bool isBakedGoods,
        //    bool isPie, int daysToExpiry)
        //{
        //    if (isFrozen)
        //    {
        //        return basePrice * 1.05;
        //    }
        //    if (isBakedGoods && daysToExpiry <= 14)
        //    {
        //        return basePrice * 1.05;
        //    }
        //    if (isPie && daysToExpiry <= 45)
        //    {
        //        return basePrice * 1.08;
        //    }
        //    if (isPie && daysToExpiry > 45)
        //    {
        //        return basePrice * 1.23;
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid product");
        //    }
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.ReadKey();
        }
    }
}
