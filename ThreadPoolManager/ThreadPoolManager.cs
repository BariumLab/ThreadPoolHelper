using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ThreadPoolHelper
{
    /// <summary>
    /// Must use with the <see cref="ThreadPoolObject"/> class.
    /// </summary>
    public static class ThreadPoolManager
    {
        /// <summary>
        /// Halts the main thread until all the queued threads have completed.
        /// </summary>
        /// <param name="totalQueuedThreads">Total number of threads that were queued.</param>
        /// <param name="waitTime">How often to check if the threads have completed in seconds. Defaults to 1 second.</param>
        public static void WaitForThreads(int totalQueuedThreads, double waitTime = 1)
        {
            while(totalQueuedThreads <= ThreadPoolObject.Counter)
            {
                var counter = ThreadPoolObject.Counter;
                Thread.Sleep(Convert.ToInt32(waitTime * 1000));
            }
        }

        /// <summary>
        /// Halts the main thread until all the queued threads have completed.
        /// </summary>
        /// <param name="collection">Collection that reflects the amount of threads that are queued.</param>
        /// <param name="waitTime">How often to check if the threads have completed in seconds. Defaults to 1 second.</param>
        public static void WaitForThreads<T>(IEnumerable<T> collection, double waitTime = 1)
        {
            var totalCount = collection.Count();
            while (totalCount <= ThreadPoolObject.Counter)
            {
                var counter = ThreadPoolObject.Counter;
                Thread.Sleep(Convert.ToInt32(waitTime * 1000));
            }
        }
    }
}
