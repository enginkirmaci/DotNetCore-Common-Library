using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class AsyncHelper
    {
        private static readonly TaskFactory TaskFactory = new TaskFactory(CancellationToken.None,
                      TaskCreationOptions.None,
                      TaskContinuationOptions.None,
                      TaskScheduler.Default);

        /// <summary>
        /// Runs a task-based function with generic return type
        /// </summary>
        /// <typeparam name="TResult">Generic return object</typeparam>
        /// <param name="func">The function to execute</param>
        /// <returns>The result from the func</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return TaskFactory
              .StartNew(func)
              .Unwrap()
              .GetAwaiter()
              .GetResult();
        }

        /// <summary>
        /// Runs a task-based function
        /// </summary>
        /// <param name="func">The function to execute</param>
        public static void RunSync(Func<Task> func)
        {
            TaskFactory
              .StartNew(func)
              .Unwrap()
              .GetAwaiter()
              .GetResult();
        }

        public async static Task RunAsync(Func<Task> func)
        {
            await TaskFactory
                .StartNew(func)
                .Unwrap();
        }
    }
}