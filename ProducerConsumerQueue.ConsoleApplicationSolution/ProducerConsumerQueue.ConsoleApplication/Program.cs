using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerQueue.ConsoleApplication
{
    class Program
    {
        // Shared thread-safe queue between producer and consumer
        static readonly ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

        // Counters for tracking stats
        static int producedCount = 0;
        static int consumedCount = 0;

        static async Task Main(string[] args)
        {
            using var cts = new CancellationTokenSource();
            var token = cts.Token;

            Console.WriteLine("Press Ctrl+C to stop...");

            // Gracefully handle Ctrl+C (SIGINT)
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("\nStopping...");
                cts.Cancel();
                e.Cancel = true;
            };

            // Start producer and consumer tasks
            var producer = Task.Run(() => Produce(token), token);
            var consumer = Task.Run(() => Consume(token), token);

            try
            {
                await Task.WhenAll(producer, consumer);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was cancelled.");
            }

            Console.WriteLine($"\nDone.\nTotal Produced: {producedCount}\nTotal Consumed: {consumedCount}");
        }

        /// <summary>
        /// Continuously produces random numbers and enqueues them until cancellation is requested.
        /// </summary>
        static void Produce(CancellationToken token)
        {
            var rand = new Random();
            while (!token.IsCancellationRequested)
            {
                int number = rand.Next(1, 100);
                queue.Enqueue(number);
                Interlocked.Increment(ref producedCount);
                Console.WriteLine($"Produced: {number}");
                Thread.Sleep(300); // Simulate delay
            }
        }

        /// <summary>
        /// Continuously attempts to dequeue numbers and print them until cancellation and queue is empty.
        /// </summary>
        static void Consume(CancellationToken token)
        {
            while (!token.IsCancellationRequested || !queue.IsEmpty)
            {
                if (queue.TryDequeue(out int number))
                {
                    Interlocked.Increment(ref consumedCount);
                    Console.WriteLine($"\tConsumed: {number}");
                }
                else
                {
                    Thread.Sleep(100); // Wait a bit if queue is empty
                }
            }
        }
    }
}