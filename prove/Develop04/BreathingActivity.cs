using System;

public class BreathingActivity : Activity
{
    private int _breathInSeconds = 4;
    private int _breathOutSeconds = 6;

    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
    { }

    protected override void RunCore()
    {
        int remaining = GetDurationSeconds();

        while (remaining > 0)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            int inTime = Math.Min(_breathInSeconds, remaining);
            ShowCountdown(inTime);
            remaining -= inTime;

            if (remaining <= 0) break;

            Console.WriteLine();
            Console.Write("Breathe out... ");
            int outTime = Math.Min(_breathOutSeconds, remaining);
            ShowCountdown(outTime);
            remaining -= outTime;

            Console.WriteLine();
        }
    }
}