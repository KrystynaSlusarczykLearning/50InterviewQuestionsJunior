using AccessModifiers;
using System;

namespace AccessModifiersOtherAssembly
{
    class ChildOfTestClassInOtherAssembly : TestClass
    {
        public ChildOfTestClassInOtherAssembly()
        {
            Console.WriteLine(base.PublicField);
            //Console.WriteLine(base.InternalField); //not accessible in this assembly
            Console.WriteLine(base.ProtectedField);
            Console.WriteLine(base.ProtectedInternalField);
            //Console.WriteLine(base.PrivateProtectedField); //only accessible in classes derived from the TestClass and in the same assembly as the TestClass
            //Console.WriteLine(base.PrivateField); //only accessible in the TestClass
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var testClassInstance = new TestClass();
            Console.WriteLine(testClassInstance.PublicField);
            //Console.WriteLine(testClassInstance.InternalField); //not accessible in this assembly
            //Console.WriteLine(testClassInstance.ProtectedField); //not accessible here because this class is not derived from the TestClass
            //Console.WriteLine(testClassInstance.ProtectedInternalField); //not accessible here because this class is not derived from the TestClass and it is in another assembly
            //Console.WriteLine(testClassInstance.PrivateProtectedField); //not accessible here because this class is not derived from the TestClass
            //Console.WriteLine(testClassInstance.PrivateField); //only accessible in the TestClass


            Console.ReadKey();
        }
    }
}
