using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EClerx.CSharp.Day4
{
    internal class Program
    {
        //Instance Variable
        public double price = 1000;

        //Read-only
        public readonly double salary = 0;

        //const
        public const double maxMark = 100;

        public Program()
        {
            salary = 50000;
           // maxMark = 120;
        }

        public void ChangePrice()
        {
            price = 10000;
            //salary = 50000;
           // maxMark = 50;
        }

        public void Delete()
        {

        }

        static void Main1(string[] args)
        {
            Program program = new Program();
            program.price = 200;
            // program.salary = 60000;

            Console.WriteLine($"Salary :{program.salary}");

            Console.WriteLine($"Max Mark :{Program.maxMark}");

            program.ChangePrice();
            program.Delete();
        }
    }
}
