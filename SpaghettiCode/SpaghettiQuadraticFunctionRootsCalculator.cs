using System;

namespace SpaghettiCode
{
    class SpaghettiQuadraticFunctionRootsCalculator : IQuadraticFunctionRootsCalculator
    {
        public void Calculate()
        {
            var f = false; //means "is finished" 
            while (!f)
            {
                Console.WriteLine("Quadratic Function: y = ax^2 + bx + c");

                //variables for a,b,c
                double a;
                string astr;
                double b;
                string bstr;
                double c;
                string cstr;
                do
                {
                    //reading a
                    Console.WriteLine("Enter a");
                    astr = Console.ReadLine();
                    if (!double.TryParse(astr, out a))
                    {
                        Console.WriteLine("Invalid format, please try again.");
                    }
                }
                while (!double.TryParse(astr, out a));

                do
                {
                    //reading b
                    Console.WriteLine("Enter b");
                    bstr = Console.ReadLine();
                    if (!double.TryParse(bstr, out b))
                    {
                        Console.WriteLine("Invalid format, please try again.");
                    }
                }
                while (!double.TryParse(bstr, out b));

                do
                {
                    //reading c
                    Console.WriteLine("Enter c");
                    cstr = Console.ReadLine();
                    if (!double.TryParse(cstr, out c))
                    {
                        Console.WriteLine("Invalid format, please try again.");
                    }
                }
                while (!double.TryParse(cstr, out c));

                var d = b * b - 4 * a * c;
                if (d > 0)
                {
                    Console.WriteLine("Two roots:");      
                    Console.WriteLine((-b - Math.Sqrt(d)) / (2 * a));
                    Console.WriteLine((-b + Math.Sqrt(d)) / (2 * a));
                }
                else
                {
                    if (d == 0)
                    {
                        Console.WriteLine("One root:");
                        Console.WriteLine((-b + Math.Sqrt(d)) / (2 * a));
                    }
                    else Console.WriteLine("Zero roots.");
                }




                bool ok;
                string b1str;
                Console.WriteLine("Run calculation again? Enter Y or N");
                do
                {
                    b1str = Console.ReadLine();
                    if (b1str == "Y")
                    {
                        f = false;
                        ok = true;
                    }
                    else if (b1str == "N")
                    {
                        f = true;
                        ok = true;
                    }
                    else { Console.WriteLine("Invalid format, please try again. Enter Y or N"); ok = false; }
                }
                while (!ok);

                }
    } } 
}
