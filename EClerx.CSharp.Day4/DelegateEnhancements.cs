using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EClerx.CSharp.Day4
{
    public delegate double DiscountDelegate(double amount);

    internal class DelegateEnhancements
    {
        public static double Discount(double amount)
        {
            return amount - (amount * 0.2);
        }

        public static void AddNumber(int n1, int n2)
        {
            Console.WriteLine($"Add :{n1 + n2}");
        }

        static void Main(string[] args)
        {
            DiscountDelegate del = Discount;
            Console.WriteLine($"Final Amount after Discount :{del(2000)}");

            //Anonymous Function
            DiscountDelegate del1 = delegate (double amount)
            {
                return amount - (amount * 0.2);
            };
            Console.WriteLine($"Final Amount after Discount :{del1(2500)}");

            //Lambda Expression
            //DiscountDelegate del2 = (amount) =>
            //{
            //    return amount - (amount * 0.2);
            //};

            DiscountDelegate del2 = x => x - (x * .2);
            Console.WriteLine($"Final Amount after Discount :{del2(2500)}");

            //Action<> - Method with parameter and no return type
            //Func<> - Method with paramter and (any) return type
            //Predicate<> Method to return boolean return type

            Func<double, double> f1 = Discount;
            Console.WriteLine($"Final Amount after Discount :{f1(5500)}");

            Action<int, int> add = AddNumber;
            add(50, 6);

            int price = -1000;

            Predicate<int> checkPrice = x => x > 0;

            var result = checkPrice(price);
            Console.WriteLine($"Result :{result}");
        }
    }
}
