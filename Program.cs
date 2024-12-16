using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();

        // Subscribe to events
        stopwatch.OnStarted += DisplayMessage;
        stopwatch.OnStopped += DisplayMessage;
        stopwatch.OnReset += DisplayMessage;
Console.Clear();
        Console.WriteLine("===============================================");
        Console.WriteLine("            🕒 Console Stopwatch App 🕒         ");
        Console.WriteLine("===============================================\n");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("  ▶ Press 'S' to Start the stopwatch.");
        Console.WriteLine("  ⏹ Press 'T' to Stop the stopwatch.");
        Console.WriteLine("  🔄 Press 'R' to Reset the stopwatch.");
        Console.WriteLine("  ❌ Press 'Q' to Quit the application.");
        Console.WriteLine("-----------------------------------------------\n");

        while (true)
        {
            var input = Console.ReadKey(intercept: true).KeyChar;

            switch (char.ToUpper(input))
            {
                case 'S':
                    // Run Start method on a new thread
                    Task.Run(() => stopwatch.Start());
                    break;
                case 'T':
                    stopwatch.Stop();
                    break;
                case 'R':
                    stopwatch.Reset();
                    Console.WriteLine(); // Move to the next line
                    break;
                case 'Q':
                    Console.WriteLine(".........Quitting the app.");
                    return;
                default:
                    Console.WriteLine("⚠ Invalid input. Please press 'S', 'T', 'R', or 'Q'");
                    break;
            }
        }
    }
static void DisplayMessage(string message)
{
    Console.WriteLine();
    Console.WriteLine(message);
}

}
