namespace DefaultAccessModifiers
{
    //at namespace level we can only use internal or public
    //private class PrivateClassAtNamespaceLevel
    //{
    //}

    //this class is internal by default
    class ClassAtNamespaceLevel 
    {
        //this field is private by default
        int number;

        //all access modifiers other than private are non-default
        public int publicNumber;


        //this class is private by default,
        //because it is declared at class level
        class InnerClass 
        {

        }
    }

    public class PublicClassAtNamespaceLevel //public is non-default access modifier
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello!");
            System.Console.ReadKey();
        }
    }
}
