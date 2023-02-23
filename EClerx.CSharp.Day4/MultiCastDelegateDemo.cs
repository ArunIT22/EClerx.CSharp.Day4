using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EClerx.CSharp.Day4
{

    public class MultiCastDelegateDemo
    {
        public static void AddNumber(int a, int b)
        {
            Console.WriteLine($"Add Number :{a + b}");
        }

        public static void DivideNumber(int a, int b)
        {
            Console.WriteLine($"Divide Number :{a / b}");
        }

        static void Main1(string[] args)
        {
            //Step 2
            CalculateDelegate calcDel = AddNumber;
            calcDel += DivideNumber;
            calcDel += AddNumber;

            //Remove a method from Delegate reference
            calcDel -= DivideNumber;
            calcDel -= AddNumber;

            calcDel += SingleCastDelegateDemo.AddTwoNumber;

            calcDel(10, 2);
        }
    }
}
