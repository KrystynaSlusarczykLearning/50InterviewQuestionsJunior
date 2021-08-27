using System;

namespace PartialClasses
{
    partial class Duck
    {
        private void Quack()
        {
            Console.WriteLine("Quack, quack, I'm a duck");
        }

        public partial void Fly();
    }
}
