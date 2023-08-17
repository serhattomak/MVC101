using System;
using System.Linq;
using LINQSamples.Data;

namespace LINQSamples
{

    class ProductModel
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //var products = db.Products.Where(p=>p.UnitPrice>18).ToList();
                //var products = db.Products.Select(p=>new {p.ProductName, p.UnitPrice}).Where(p=>p.UnitPrice>18).ToList();
                //var products = db.Products.Where(p => p.UnitPrice > 18 && p.UnitPrice<30).ToList();
                //var products = db.Products.Where(p => p.CategoryId >= 1 && p.CategoryId <= 5).ToList();
                //var products = db.Products.Where(p => p.CategoryId == 1 || p.CategoryId == 5).ToList();
                //var products = db.Products.Where(p=>p.CategoryId==1).Select(p => new { p.ProductName, p.UnitPrice }).ToList();
                //var products = db.Products.Where(i=>i.ProductName=="Chai").ToList();
                var products = db.Products.Where(i=>i.ProductName.Contains("Ch")).ToList();

                foreach (var p in products)
                {
                    Console.WriteLine(p.ProductName + ' ' + p.UnitPrice);
                }
            }

            Console.ReadLine();
        }

        private static void Lesson1(NorthwindContext db)
        {
            //var products = db.Products.ToList();
            //var products = db.Products.Select(p => p.ProductName).ToList();
            //var products = db.Products.Select(p => new {p.ProductName, p.UnitPrice}).ToList();
            //var products = db.Products.Select(p => new ProductModel
            //{
            //    Name = p.ProductName,
            //    Price = p.UnitPrice
            //}).ToList();

            //var product = db.Products.First();
            var product = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).FirstOrDefault();

            Console.WriteLine(product.ProductName + ' ' + product.UnitPrice);

            //foreach (var p in products)
            //{
            //    Console.WriteLine(p.Name + ' ' + p.Price);
            //}
        }
    }
}

