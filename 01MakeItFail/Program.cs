using System;
//iterate
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Press 'q' to quit");

        while (true)
        {
            // Do some work here...

            // Check if user has pressed 'q' to quit
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
            {
                Console.WriteLine("Quitting...");
                break;
            }
        }
    }
}
