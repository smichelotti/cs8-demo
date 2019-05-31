using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS80Demo
{
    public class QueueClient
    {
        public static async IAsyncEnumerable<int> GetQueueItems()
        {
            for (int i = 0; i < 100; i++)
            {
                // Simulate getting items asynchronously from a queue
                await Task.Delay(100);
                yield return new Random().Next();
            }
        }
    }
}
