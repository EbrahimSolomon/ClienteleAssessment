using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class Program
{
    private static List<int> _lastValidNumbers = new List<int>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter numbers separated by commas or spaces (e.g., 5,10 15), or type 'retry' to rerun the last valid input, or 'exit' to quit:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No input provided.");
                continue;
            }

            if (input.Trim().ToLower() == "exit")
            {
                Console.WriteLine("Exiting application.");
                break;
            }

            List<int> numbers = new List<int>();

            if (input.Trim().ToLower() == "retry")
            {
                if (_lastValidNumbers.Count == 0)
                {
                    Console.WriteLine("No previous valid input to retry.");
                    continue;
                }

                numbers = new List<int>(_lastValidNumbers);
                Console.WriteLine($"Retrying with: {string.Join(", ", numbers)}");
            }
            else
            {
                string[] tokens = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var token in tokens)
                {
                    if (int.TryParse(token.Trim(), out int n) && n >= 0)
                        numbers.Add(n);
                    else
                        Console.WriteLine($"Invalid or negative input ignored: {token}");
                }

                if (numbers.Count == 0)
                {
                    Console.WriteLine("No valid numbers provided.");
                    continue;
                }

                _lastValidNumbers = new List<int>(numbers); // Store for retry
            }

            int threadCount = numbers.Count;
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                int n = numbers[i];
                threads[i] = new Thread(() =>
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    FactorialCalculator.ComputeAndPrint(n);
                    sw.Stop();
                    lock (typeof(Console))
                    {
                        Console.WriteLine($"Time taken for {n}: {sw.ElapsedMilliseconds} ms");
                    }
                });
                threads[i].Start();
            }

            foreach (var t in threads)
                t.Join();

            Console.WriteLine($"All factorials computed. Threads used: {threadCount}\n");
        }
    }
}
