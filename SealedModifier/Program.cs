using System;

namespace SealedModifier
{
    public class Base
    {
        public virtual void DoSomething() 
        {
            Console.WriteLine("Base class");
        }
    }

    public class Derived : Base
    {
        public override sealed void DoSomething() //we are sealing this method
        {
            Console.WriteLine("Derived class");
        }
    }

    public class DerivedFromDerived : Derived
    {
        //does not compile - this method was sealed in Derived class
        //public override void DoSomething() 
        //{
        //}
    }

    public sealed class SealedBase
    {

    }

    //does not compile - can't derive from sealed class
    //public class DerivedFromSealed : SealedBase
    //{
    //}


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.ReadKey();
        }
    }
}
