using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EClerx.CSharp.Day4
{
    internal class Publisher
    {
        public delegate void AlarmDelegate();
        public event AlarmDelegate Alarm;

        public bool SetAlarm(int time)
        {
            if (time == 6)
            {
                if (Alarm != null)
                {
                    Alarm.Invoke();//Raise the event
                    return true;
                }
            }
            return false;
        }
    }

    public class Subscriber
    {
        public static void AlarmMessage()
        {
            Console.WriteLine("Good Morning. Time to wake up");
        }

        static void Main(string[] args)
        {
            Publisher p = new Publisher();
            p.Alarm += new Publisher.AlarmDelegate(AlarmMessage);

            for (int i = 1; i < 12; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Current Time is {i + ":00"}");
                var res = p.SetAlarm(i);
                if (res)
                {
                    break;
                }
            }
        }
    }
}
