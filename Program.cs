using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();

        stopwatch.OnStarted += DisplayMessage;
        stopwatch.OnStopped += DisplayMessage;
        stopwatch.OnReset += DisplayMessage;
Console.Clear();
        Console.WriteLine("===============================================");
        Console.WriteLine("          Console Stopwatch App          ");
        Console.WriteLine("===============================================\n");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("  Press 'S' to Start the stopwatch.");
        Console.WriteLine("  Press 'T' to Stop the stopwatch.");
        Console.WriteLine("  Press 'R' to Reset the stopwatch.");
        //added rather than clicking ctrl+c everytime
        Console.WriteLine("  Press 'Q' to Quit the application.");
        Console.WriteLine("-----------------------------------------------\n");

        while (true)
        {
            var input = Console.ReadKey(intercept: true).KeyChar;

            switch (char.ToUpper(input))
            {
                case 'S':
                    Task.Run(() => stopwatch.Start());//since others started freezing if one key is cliked, then separate the thread
                    break;
                case 'T':
                    stopwatch.Stop();
                    break;
                case 'R':
                    stopwatch.Reset();
                    Console.WriteLine(); 
                    break;
                case 'Q':
                    Console.WriteLine(".........Quitting the app.");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please press 'S', 'T', 'R', or 'Q'");
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
