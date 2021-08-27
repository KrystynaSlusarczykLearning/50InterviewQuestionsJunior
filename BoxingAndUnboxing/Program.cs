using System;

namespace BoxingAndUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            //no boxing here, because string is not a value type
            string word = "abc";
            object obj = word;

            //boxing and unboxing
            int number = 5;
            object boxedNumber = number;
            int unboxedNumber = (int)boxedNumber;

            //this will throw because unboxing requires exact type match
            short shortNumber = 3;
            object boxedShortNumber = shortNumber;
            //int unboxedShortNumber = (int)boxedShortNumber; 

            //this will work fine - no boxing or unboxing here,
            //so short is converted to int without problem
            short otherShortNumber = 3;
            int otherShortNumberCastToInt = (int)otherShortNumber; 

            Console.ReadKey();
        }
    }
}
