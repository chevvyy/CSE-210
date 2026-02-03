using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start custom activity");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? "";

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => new CustomActivity(),
                "5" => null,
                _ => null
            };

            if (choice == "5")
            {
                running = false;
            }
            else if (activity != null)
            {
                activity.Start();
            }
        }
    }
}