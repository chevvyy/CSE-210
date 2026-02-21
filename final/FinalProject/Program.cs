using System;

namespace LaserOrderCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ISheetsClient client = new MockSheetsClient();
            var app = new App(client);
            app.Run();
        }
    }
}