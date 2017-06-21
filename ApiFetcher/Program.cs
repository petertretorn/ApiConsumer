using System;

namespace ApiFetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            new ClientApp().Run();

            Console.WriteLine("That's it...");

            Console.ReadKey();
        }
    }
}
