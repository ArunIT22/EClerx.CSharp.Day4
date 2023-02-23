using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EClerx.CSharp.Day4
{
    public class ThreadVsAsync
    {
        public void ThreadDemo()
        {
            Console.WriteLine($"Thread Method Started :{Environment.CurrentManagedThreadId}");//5
            Thread.Sleep(2000);//Network Delay
            Console.WriteLine("Thread in sleep mode");//5
            Console.WriteLine($"Thread Method Started :{Environment.CurrentManagedThreadId}");//5
        }

        public async Task ThreadDemoAsync()
        {
            Console.WriteLine($"Thread Method Started :{Environment.CurrentManagedThreadId}");//1
            await Task.Delay(2000);
            Console.WriteLine("Thread in sleep mode");
            Console.WriteLine($"Thread Method Started :{Environment.CurrentManagedThreadId}");//4
        }

        static async Task Main1(string[] args)
        {
            ThreadVsAsync obj = new ThreadVsAsync();

            //Thread Demo
            //Thread t1 = new Thread(new ThreadStart(obj.ThreadDemo));
            //Console.WriteLine("Main Method STarts");
            //t1.Start();
            //Console.WriteLine("Main method Ends");

            ////Async Demo
            Console.WriteLine("Main Method STarts");
            await obj.ThreadDemoAsync();
            Console.WriteLine("Main method Ends");
        }
    }
}
