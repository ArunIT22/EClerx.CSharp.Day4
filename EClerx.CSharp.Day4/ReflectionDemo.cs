using System;
using System.Reflection;

namespace EClerx.CSharp.Day4
{
    internal class ReflectionDemo
    {
        static void Main(string[] args)
        {
            //Reference Assembly
            var myAssembly = Assembly.LoadFile(@"D:\2022\eClerx\Batch 2\Demos\EClerx.CSharp.Day3\BusinessLayer\bin\Debug\BusinessLayer.dll");

            var dllTypes = myAssembly.GetTypes();

            foreach (var item in dllTypes)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("--List of Interfaces----");
            foreach (var item in dllTypes)
            {               
                if (item.IsInterface)
                {
                    Console.WriteLine(item);
                }                
            }

            Console.WriteLine("\n--List of Abstract Classes----");
            foreach (var item in dllTypes)
            {
               
                if (item.IsAbstract)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine();
            var domesticType = myAssembly.GetType("BusinessLayer.DomesticSeller");

            var domesticObj = Activator.CreateInstance(domesticType);

            var methods = domesticObj.GetType().GetMethods();
            Console.WriteLine("\nDomestic Seller Methods....");
            //Method Info
            foreach (var item in methods)
            {
                Console.WriteLine(item);
            }
        }
    }
}
