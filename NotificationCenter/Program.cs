using System;

namespace NotificationCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            NotifiableClass1 class1 = new NotifiableClass1();
            NotifiableClass2 class2 = new NotifiableClass2();

            class1.Start();
            class2.Start();

            Console.ReadKey();
        }
    }
}
