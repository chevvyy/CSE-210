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
            Console.WriteLine("  4. Custom activity: Run");
            Console.WriteLine("  5. Custom activity: Edit");
            Console.WriteLine("  6. Custom activity: Reset");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Start();
                    break;

                case "2":
                    new ReflectionActivity().Start();
                    break;

                case "3":
                    new ListingActivity().Start();
                    break;

                case "4":
                    CustomActivity.RunFromSaved();
                    break;

                case "5":
                    CustomActivity.EditAndSave();
                    break;

                case "6":
                    CustomActivity.ResetAndCreate();
                    break;

                case "7":
                    running = false;
                    break;
            }
        }
    }
}