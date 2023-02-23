using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EClerx.CSharp.Day4
{
    //Step 1
    public delegate void CalculateDelegate(int x, int y);
    public delegate int CalculateDelegate2(int x, int y);
    public class SingleCastDelegateDemo
    {
        public static void AddTwoNumber(int a, int b)
        {
            Console.WriteLine($"Sum :{a + b}");
        }

        public int MultiNumber(int a, int b)
        {
            return a * b;
        }

        static void Main(string[] args)
        {
            SingleCastDelegateDemo obj = new SingleCastDelegateDemo();
            // obj.AddTwoNumber(1, 2);

            //Step 2
            //CalculateDelegate del = new CalculateDelegate(obj.AddTwoNumber);
            CalculateDelegate del =AddTwoNumber;

            //Step 3:
            del(2, 4);

            //Step 2:
            CalculateDelegate2 delMulti = obj.MultiNumber;
            var res = delMulti(2, 3);
            Console.WriteLine($"Multi :{res}");
        }
    }
}
