using System;

namespace AccessModifiers
{
    public class TestClass
    {
        public string PublicField = "public"; //accessible in any class in any assembly
        internal string InternalField = "internal"; //accessible in any class in this assembly
        protected string ProtectedField = "protected"; // accessible only in classes derived from this class
        protected internal string ProtectedInternalField = "protected internal"; // accessible from any class in this assembly, OR from derived classes in other assemblies
        private protected string PrivateProtectedField = "private protected"; // in this assembly can only be accessed from classes derived from this class. Not accessible in another assemblies at all.
        private string PrivateField = "private"; // not accessible in any other class

    }

    class ChildOfTestClassInTheSameAssembly : TestClass
    {
        public ChildOfTestClassInTheSameAssembly()
        {
            Console.WriteLine(base.PublicField);
            Console.WriteLine(base.InternalField);
            Console.WriteLine(base.ProtectedField);
            Console.WriteLine(base.ProtectedInternalField);
            Console.WriteLine(base.PrivateProtectedField); 
            //Console.WriteLine(base.PrivateField); //only accessible in the TestClass
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var testClassInstance = new TestClass();

            Console.WriteLine(testClassInstance.PublicField);
            Console.WriteLine(testClassInstance.InternalField);
            //Console.WriteLine(testClassInstance.ProtectedField); //not accessible here because this class is not derived from the TestClass
            Console.WriteLine(testClassInstance.ProtectedInternalField);
            //Console.WriteLine(testClassInstance.PrivateProtectedField); //not accessible here because this class is not derived from the TestClass
            //Console.WriteLine(testClassInstance.PrivateField); //only accessible in the TestClass

            Console.ReadKey();
        }
    }
}
