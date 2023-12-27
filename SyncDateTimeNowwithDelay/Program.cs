using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDateTimeNowwithDelay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int threadId;
            //   Console.ReadLine();

            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            // Initiate the asychronous call.
            IAsyncResult result = caller.BeginInvoke(100000,
                out threadId, null, null);

            Thread.Sleep(0);
            Console.WriteLine("Main thread {0} does some work.",
                Thread.CurrentThread.ManagedThreadId);

            DateTime now = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan(0, 0, 80);

            // Wait for the WaitHandle to become signaled.
            while (!result.IsCompleted)
            {
                TimeSpan timeSpan2 = DateTime.Now.Subtract(now);
                if (timeSpan2 > timeSpan)
                {
                    throw new TimeoutException("Powershell script taking too long");
                }
                // Console.WriteLine("{0} < {1} continue processing",timeSpan2,timeSpan);
                Thread.Sleep(1000);
            }


            string returnValue = caller.EndInvoke(out threadId, result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".",
                threadId, returnValue);


        }
    }

    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }
    // The delegate must have the same signature as the method
    // it will call asynchronously.
    public delegate string AsyncMethodCaller(int callDuration, out int threadId);
}

