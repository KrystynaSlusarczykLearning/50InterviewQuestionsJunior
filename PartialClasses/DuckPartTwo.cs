using System;

namespace PartialClasses
{
    partial class Duck
    {
        private void Swim()
        {
            Console.WriteLine("Swimming in a pond");
        }

        public partial void Fly()
        {
            Console.WriteLine("Flying high in the sky");
        }
    }
}
