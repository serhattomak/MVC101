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

                //ALL CUSTOMERS' INFO

                //var customers = db.Customers.ToList();

                //foreach (var c in customers)
                //{
                //    Console.WriteLine(c.ContactName);
                //}

                //ALL CUSTOMERS' ID

                //var customerId = db.Customers.Select(c => new { c.CustomerId, c.ContactName }).ToList();

                //foreach (var c in customerId)
                //{
                //    Console.WriteLine(c.CustomerId + ' ' + c.ContactName);
                //}

                //CUSTOMERS WHO LIVE IN GERMANY

                //var customerLocation = db.Customers.Select(c=> new { c.ContactName, c.Country }).Where(c => c.Country == "Germany").ToList();

                //foreach (var c in customerLocation)
                //{
                //    Console.WriteLine(c.Country + ' ' + c.ContactName);
                //}

                //WHERE DOES "DIEGO ROEL" LIVE?

                //var locationDiego = db.Customers.Where(l => l.ContactName == "Diego Roel").FirstOrDefault();

                //Console.WriteLine(locationDiego.ContactName + " " + locationDiego.CompanyName);

                //WHICH PRODUCTS HAVE 0 UNITS IN STOCK

                //var products = db.Products.Select(p=> new{ p.ProductName, p.UnitsInStock }).Where(p => p.UnitsInStock == 0).ToList();

                //foreach (var p in products)
                //{
                //    Console.WriteLine(p.ProductName + " " + p.UnitsInStock);
                //}

                //ALL EMPLOYEES' FIRST AND LAST NAME

                //var employees = db.Employees.Select(e => new { FullName = e.FirstName + ' ' + e.LastName });
                //foreach (var e in employees)
                //{
                //    Console.WriteLine(e.FullName);
                //}

                //TAKE STARTING 5 VALUES

                //var products = db.Products.Take(5).ToList();

                //foreach (var p in products)
                //{
                //    Console.WriteLine(p.ProductName + " " + p.ProductId);
                //}

                //TAKE SECOND 5 VALUES

                //var products = db.Products.Skip(5).Take(5).ToList();

                //foreach (var p in products)
                //{
                //    Console.WriteLine(p.ProductName + " " + p.ProductId);
                //}


                //var results = db.Products.Count();
                //var result = db.Products.Count(i=>i.UnitPrice>10 && i.UnitPrice<30);
                //var result = db.Products.Count(i => !i.Discontinued);

                //var result = db.Products.Min(p => p.UnitPrice);
                //var result = db.Products.Where(p=>p.CategoryId==2).Max(p => p.UnitPrice);

                //var result = db.Products.Where(p => !p.Discontinued).Average(p => p.UnitPrice);
                //var result = db.Products.Where(p => !p.Discontinued).Sum(p => p.UnitPrice);

                //var result = db.Products.OrderBy(p => p.UnitPrice).ToList();
                //var result = db.Products.OrderByDescending(p => p.UnitPrice).ToList();
                var result = db.Products.OrderByDescending(p => p.UnitPrice).LastOrDefault();

                Console.WriteLine(result.ProductName + " " + result.UnitPrice);

                //foreach (var item in result)
                //{
                //    Console.WriteLine(item.ProductName + " " + item.UnitPrice);
                //}

                Console.WriteLine(result);
            }

            Console.ReadLine();
        }

        private static void Lesson2(NorthwindContext db)
        {
            //var products = db.Products.Where(p=>p.UnitPrice>18).ToList();
            //var products = db.Products.Select(p=>new {p.ProductName, p.UnitPrice}).Where(p=>p.UnitPrice>18).ToList();
            //var products = db.Products.Where(p => p.UnitPrice > 18 && p.UnitPrice<30).ToList();
            //var products = db.Products.Where(p => p.CategoryId >= 1 && p.CategoryId <= 5).ToList();
            //var products = db.Products.Where(p => p.CategoryId == 1 || p.CategoryId == 5).ToList();
            //var products = db.Products.Where(p=>p.CategoryId==1).Select(p => new { p.ProductName, p.UnitPrice }).ToList();
            //var products = db.Products.Where(i=>i.ProductName=="Chai").ToList();
            var products = db.Products.Where(i => i.ProductName.Contains("Ch")).ToList();

            foreach (var p in products)
            {
                Console.WriteLine(p.ProductName + ' ' + p.UnitPrice);
            }
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

