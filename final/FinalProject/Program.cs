using System;

namespace LaserOrderCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ISheetsClient client = new MockSheetsClient(); // swap later for GoogleSheetsClient
            var app = new App(client);
            app.Run();

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
