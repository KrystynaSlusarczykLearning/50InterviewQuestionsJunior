using System;

namespace OpenClosedPrinciple
{
    public interface IIceCreamFactory
    {
        IceCream Create(IceCreamType iceCreamType);
    }

    public class IceCreamFactory : IIceCreamFactory
    {
        public IceCream Create(IceCreamType iceCreamType)
        {
            switch (iceCreamType)
            {
                case IceCreamType.Vanilla:
                    return new IceCream(IceCreamType.Vanilla, 
                        new[] { "Cream", "Sugar", "Vanilla" });
                case IceCreamType.Chocolate:
                    return new IceCream(IceCreamType.Chocolate, 
                        new[] { "Cream", "Sugar", "Chocolate" });
                case IceCreamType.Strawberry:
                    return new IceCream(IceCreamType.Strawberry, 
                        new[] { "Sugar", "Strawberry", "Coconut Cream" });
                default:
                    throw new ArgumentException(
                        $"Invalid type of ice cream: {iceCreamType}");
            }
        }
    }

    public enum IceCreamType
    {
        Vanilla,
        Chocolate,
        Strawberry
    }

    public class IceCream
    {
        public IceCreamType IceCreamType { get; }
        public string[] Ingredients { get; }

        public IceCream(IceCreamType iceCreamType, string[] ingredients)
        {
            IceCreamType = iceCreamType;
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            return IceCreamType.ToString();
        }
    }

    public class RandomIceCreamGenerator
    {
        private Random _random = new Random();
        private readonly IIceCreamFactory _iceCreamFactory;

        public RandomIceCreamGenerator(IIceCreamFactory iceCreamFactory)
        {
            _iceCreamFactory = iceCreamFactory;
        }

        public IceCream Generate()
        {
            var randomType = GetRandomIceCreamType();
            return _iceCreamFactory.Create(randomType);
        }

        private IceCreamType GetRandomIceCreamType()
        {
            var values = Enum.GetValues(typeof(IceCreamType));

            return (IceCreamType)values.GetValue(_random.Next(values.Length));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                $"Triangle of base 10, height 5. Area is: {new AreaCalculator().Calculate(new Triangle(10, 5))}");

            var randomIceCreamGenerator = new RandomIceCreamGenerator(new IceCreamFactory());
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Random ice cream: {randomIceCreamGenerator.Generate()}");
            }
            Console.ReadKey();
        }
    }
}
