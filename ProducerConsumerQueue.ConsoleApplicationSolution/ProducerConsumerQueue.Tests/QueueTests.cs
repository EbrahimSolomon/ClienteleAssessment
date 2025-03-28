using System.Collections.Concurrent;
using Xunit;

namespace ProducerConsumerQueue.Tests
{
    public class QueueTests
    {
        [Fact]
        public void EnqueuedItem_ShouldBeDequeued()
        {
            // Arrange
            var queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            // Act
            bool result = queue.TryDequeue(out int value);

            // Assert
            Assert.True(result);
            Assert.Equal(42, value);
        }

        [Fact]
        public void Dequeue_FromEmptyQueue_ShouldFail()
        {
            var queue = new ConcurrentQueue<int>();

            bool result = queue.TryDequeue(out int value);

            Assert.False(result);
            Assert.Equal(0, value); // default(int) == 0
        }
    }
}
