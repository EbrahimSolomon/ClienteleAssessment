using System.Collections.Generic;
using System.Threading;
using System;

namespace ProducerConsumerQueue.WebApplication.Services
{
    public class ProducerConsumerService : IProducerConsumerService
    {
        private Queue<int> _queue = new Queue<int>();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);  // Semaphore to signal the consumer
        private readonly object _lockObj = new object();
        private Random _random = new Random();
        public List<string> Results { get; private set; } = new List<string>(); // List to store results

        public void StartProducer()
        {
            Thread producerThread = new Thread(Produce);
            producerThread.Start();
        }

        public void StartConsumer()
        {
            Thread consumerThread = new Thread(Consume);
            consumerThread.Start();
        }

        private void Produce()
        {
            for (int i = 0; i < 10; i++)
            {
                int number = _random.Next(1, 100); // Generate a random number
                lock (_lockObj)
                {
                    _queue.Enqueue(number); // Add number to the queue
                    Results.Add($"Produced: {number}"); // Add produced number to the Results list
                    Console.WriteLine($"Produced: {number}"); // Log produced number
                    Monitor.Pulse(_lockObj); // Notify the consumer that there’s an item in the queue
                }
                Thread.Sleep(1000); // Simulate some delay
            }
        }
        private void Consume()
        {
            while (true)
            {
                _semaphore.Wait(); // Wait for the signal from producer that there's something in the queue

                int number = -1;
                lock (_queue)  // Lock the queue to prevent race conditions
                {
                    if (_queue.Count > 0)
                    {
                        number = _queue.Dequeue(); // Read number from the queue
                        Results.Add($"Consumed: {number}"); // Add consumed number to the Results list
                    }
                }

                if (number != -1)
                {
                    Thread.Sleep(1000); // Simulate some delay between consuming
                }
            }
        }
    }
}
