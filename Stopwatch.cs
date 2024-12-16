using System;
using System.Threading;

public class Stopwatch
{
    // Fields
    public TimeSpan TimeElapsed { get; private set; } = TimeSpan.Zero;
    private bool isRunning = false;

    // Delegate and Events
    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler? OnStarted;
    public event StopwatchEventHandler? OnStopped;
    public event StopwatchEventHandler? OnReset;

    // Start Method
    public void Start()
    {
        if (isRunning) return;

        isRunning = true;
        OnStarted?.Invoke("Stopwatch Started!");

        while (isRunning)
        {
            Tick();
            Thread.Sleep(1000); // Simulate ticking
            
        }
    }

    // Stop Method
    public void Stop()
    {
        if (!isRunning) return;

        isRunning = false;
        OnStopped?.Invoke("Stopwatch Stopped!");
        Console.WriteLine($"Time Elapsed: {TimeElapsed}"); 
    }
public void Reset()
{
        Stop(); 
        TimeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
        Console.WriteLine($"Time Elapsed: {TimeElapsed}"); 
}

    private void Tick()
    {
        TimeElapsed = TimeElapsed.Add(TimeSpan.FromSeconds(1));
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write($"Time Elapsed: {TimeElapsed:hh\\:mm\\:ss}");
    }
}
