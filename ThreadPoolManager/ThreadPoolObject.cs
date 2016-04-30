using System.Threading;

namespace ThreadPoolHelper
{
    /// <summary>
    /// Class used to wrap an object used with the <see cref="ThreadPool"/> class.
    /// <para>Pass this object as the second parameter in <see cref="ThreadPool.QueueUserWorkItem(WaitCallback, object)"/>.</para>
    /// Within the <see cref="WaitCallback"/> function cast the object to <see cref="ThreadPoolObject"/>.
    /// </summary>
    public class ThreadPoolObject
    {
        /// <summary>
        /// Counter used to display the amount of threads that have completed their function.
        /// </summary>
        public static int Counter = 0;

        /// <summary>
        /// Wrapper for the main functional object used in the <see cref="ThreadPool.QueueUserWorkItem(WaitCallback, object)"/>.
        /// </summary>
        public object ThreadObject { get; set; }

        /// <summary>
        /// Call at the end of each <see cref="ThreadPool.QueueUserWorkItem(WaitCallback, object)"/> function.
        /// </summary>
        public void IncrementCounter()
        {
            Interlocked.Increment(ref Counter);
        }
    }
}
