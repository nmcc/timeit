using System;
using System.Linq;
using System.Diagnostics;

namespace Timeit
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length< 1)
            {
                PrintHelp();
                return 1;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var process = Process.Start(
                fileName: args[0],
                arguments: args.Length > 1 ? string.Join(" ", args.Skip(1)) : string.Empty);

            process.WaitForExit();

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Command execution time: {stopwatch.Elapsed}");

            return process.ExitCode;
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Usage: timeit.exe <command> <args>");
        }
    }
}
