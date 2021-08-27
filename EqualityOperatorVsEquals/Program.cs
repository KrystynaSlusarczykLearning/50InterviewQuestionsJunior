using System;

namespace EqualityOperatorVsEquals
{
    class CustomClass
    {
        int _x;
        public CustomClass(int x)
        {
            _x = x;
        }
    }

    struct CustomStruct
    {
        int _x;
        public CustomStruct(int x)
        {
            _x = x;
        }
    }

    class CustomClassOverridingEquals
    {
        int _x;
        public CustomClassOverridingEquals(int x)
        {
            _x = x;
        }

        public override bool Equals(object obj)
        {
            var item = obj as CustomClassOverridingEquals;

            if (item == null)
            {
                return false;
            }

            return _x == item._x;
        }

        public override int GetHashCode()
        {
            return _x.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("For strings:");
            string string1 = "abc";
            string string2 = "abc";
            Console.WriteLine($"string1 == string2: {string1 == string2}");
            Console.WriteLine($"string1.Equals(string2): {string1.Equals(string2)}\n");

            Console.WriteLine("For CustomClass:");
            var customClass1 = new CustomClass(1);
            var customClass2 = new CustomClass(1);
            Console.WriteLine($"customClass1 == customClass2: {customClass1 == customClass2}");
            Console.WriteLine($"customClass1.Equals(customClass2): {customClass1.Equals(customClass2)}\n");

            Console.WriteLine("For CustomClassOverridingEquals:");
            var customClassOverridingEquals1 = new CustomClassOverridingEquals(1);
            var customClassOverridingEquals2 = new CustomClassOverridingEquals(1);
            Console.WriteLine($"customClassOverridingEquals1 == customClassOverridingEquals2: " +
                $"{customClassOverridingEquals1 == customClassOverridingEquals2}");
            Console.WriteLine($"customClassOverridingEquals1.Equals(customClassOverridingEquals2): " +
                $"{customClassOverridingEquals1.Equals(customClassOverridingEquals2)}\n");

            Console.WriteLine("For CustomStruct:");
            var customStruct1 = new CustomStruct(1);
            var customStruct2 = new CustomStruct(1);
            // == operator is not supported for structs unless overloaded
            //Console.WriteLine($"CustomStruct1 == CustomStruct2: {customStruct1 == customStruct2}");
            Console.WriteLine($"CustomStruct1.Equals(CustomStruct2): {customStruct1.Equals(customStruct2)}\n");

            Console.ReadKey();
        }
    }
}
