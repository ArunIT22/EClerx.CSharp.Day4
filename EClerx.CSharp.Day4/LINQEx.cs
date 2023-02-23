using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EClerx.CSharp.Day4
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string Category { get; set; }
    }

    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }


    internal class LINQEx
    {
        public static List<Product> GetProducts()
        {
            return new List<Product> {
                new Product{ Id = 1, Name="Pen", Price=500, Category="Cat1"},
                new Product{ Id = 1, Name="Water Bottle", Price=600, Category="Cat2"},
                new Product{ Id = 3, Name="Mug", Price=1200, Category="Cat1"},
                new Product{ Id = 4, Name="Doll", Price=899, Category="Cat2"},
                new Product{ Id = 5, Name="Webcam", Price=2599, Category="Cat1"},
                };
        }
        static void Main(string[] args)
        {
            //Query Method
            var products = from prd in GetProducts()
                           where prd.Price > 1000
                           orderby prd.Name descending
                           select prd;



            //Lambda Expression
            var product2 = GetProducts()
                .Where(x => x.Price > 500)
                .OrderBy(x => x.Name);

            Console.WriteLine($"{"Id",-10}\t{"Name",-15}\t{"Price"}");
            foreach (var item in product2)
            {
                Console.WriteLine($"{item.Id,-10}\t{item.Name,-15}\t{item.Price}");
            }

            //Search by Product Id
            Console.WriteLine();
            //First, FirstOrDefault, Single, SingleOrDefault

            //var product = GetProducts().First(a => a.Id == 1);
            var product = GetProducts().FirstOrDefault(a => a.Id == 10);
            //var product = GetProducts().Single(a => a.Id == 1);
            if (product != null)
            {
                Console.WriteLine($"Product ID :{product.Id}\tProduct Name :{product.Name}");
            }
            else
            {
                Console.WriteLine("No Product available");
            }

            Console.WriteLine();
            var distinctProducts = GetProducts().Select(x => x.Id).Distinct();
            foreach (var item in distinctProducts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            var topProduct = GetProducts().Skip(2).Take(2);
            Console.WriteLine($"{"Id",-10}\t{"Name",-15}\t{"Price"}");
            foreach (var item in topProduct)
            {
                Console.WriteLine($"{item.Id,-10}\t{item.Name,-15}\t{item.Price}");
            }

            //Aggregate Function
            var TotalPrice = GetProducts().Sum(x => x.Price);
            var Count = GetProducts().Count();
            var min = GetProducts().Min(x => x.Price);
            var max = GetProducts().Max(x => x.Price);
            var avg = GetProducts().Average(x => x.Price);

            Console.WriteLine($"Total Price :{TotalPrice}\tTotal Items :{Count}\tMin Price :{min}\tMax Price :{max}\tAverage Price :{avg}");

            //Group By
            var group = GetProducts().GroupBy(x => x.Category);

            foreach (var item in group)
            {
                Console.WriteLine($"Category :{item.Key}\t Count :{item.Count()}");
                foreach (var p in item)
                {
                    Console.WriteLine($"{p.Id}\t{p.Name}\t{p.Price}\t{p.Category}");
                }
            }

            Console.WriteLine();
            //Select - User-defined Column or Moving to Different Class
            var productDto = GetProducts().Select(q => new ProductDto
            {
                Name = q.Name,
                Price = q.Price,
            });

            Console.WriteLine($"{"Name",-15}\t{"Price"}");
            foreach (var item in productDto)
            {
                Console.WriteLine($"{item.Name,-15}\t{item.Price}");
            }

        }
    }
}
