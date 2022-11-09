using System.Diagnostics;

namespace PublishDotNetToWASM;

public static class Program
{
    public static void Main()
    {
        // warm
        ulong sum = 0;
        foreach (var i in Fibonacci().Take(1000))
        {
            sum += i;
        }

        // run
        sum = 0;
        var sw = Stopwatch.StartNew();
        foreach (var i in Fibonacci().Take(100000))
        {
            sum += i;
        }
        sw.Stop();
        Console.WriteLine($"Result:{sum}, Timespan:{sw.ElapsedTicks} Ticks");
    }

    private static IEnumerable<ulong> Fibonacci()
    {
        ulong current = 1, next = 1;

        while (true) 
        {
            yield return current;
            next = current + (current = next);
        }
    }
}