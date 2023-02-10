using System;

namespace NotificationCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            SenderClass class1 = new SenderClass();
            NotifiableClass2 class2 = new NotifiableClass2();

            class1.Start();
            class2.Start();

            Console.ReadKey();
        }
    }
}
