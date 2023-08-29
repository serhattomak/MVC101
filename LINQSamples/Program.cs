using System;
using System.Linq;
using LINQSamples.Data;
using Microsoft.EntityFrameworkCore;

namespace LINQSamples
{

    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        //public int Quantity { get; set; }
    }

    class CustomerModel
    {
        public CustomerModel()
        {
            this.Orders = new List<OrderModel>();
        }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OrderCount { get; set; }
        public List<OrderModel> Orders { get; set; }
    }

    class OrderModel
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public List<ProductModel> Products { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CustomNorthwindContext())
            {
                
            }

            Console.ReadLine();
        }

        private static void Lesson13(CustomNorthwindContext db)
        {
            //var result=db.Database.ExecuteSqlRaw("delete from products where productID=84");
            //var result = db.Database.ExecuteSqlRaw("update products set unitprice=unitprice*1.2 where categoryId=4");
            //var query = "4";

            //var products = db.Products.FromSqlRaw($"select * from products where categoryId={query}").ToList();

            var products = db.ProductModels.FromSqlRaw("select ProductId, ProductName, UnitPrice from Products").ToList();

            foreach (var item in products)
            {
                Console.WriteLine(item.Name + " => " + item.Price);
            }
        }

        private static void Lesson12(NorthwindContext db)
        {
            //// Total orders from customers

            //var customers = db.Customers.Where(cus => cus.CustomerId == "PERIC").Select(cus => new CustomerModel()
            //{
            //    CustomerId = cus.CustomerId,
            //    CustomerName = cus.ContactName,
            //    OrderCount = cus.Orders.Count,
            //    Orders = cus.Orders.Select(order => new OrderModel()
            //    {
            //        OrderId = order.OrderId,
            //        Total = order.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
            //        Products = order.OrderDetails.Select(od => new ProductModel()
            //        {
            //            ProductId = od.ProductId,
            //            Name = od.Product.ProductName,
            //            Price = od.UnitPrice,
            //            Quantity = od.Quantity
            //        }).ToList()
            //    }).ToList()
            //}).OrderBy(i => i.OrderCount).ToList();

            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer.CustomerId + " => " + customer.CustomerName + " => " + customer.OrderCount);
            //    Console.WriteLine("Orders");
            //    foreach (var order in customer.Orders)
            //    {
            //        Console.WriteLine("*********************");
            //        Console.WriteLine(order.OrderId + "=>" + order.Total);
            //        foreach (var product in order.Products)
            //        {
            //            Console.WriteLine(product.ProductId + " => " + product.Name + " => " + product.Price + " => " +
            //                              product.Quantity);
            //        }
            //    }
            //}
        }

        private static void Lesson11(NorthwindContext db)
        {
            //var products = db.Products.Where(p => p.CategoryId == 1).ToList();
            //var products = db.Products.Include(p=>p.Category).Where(p => p.Category.CategoryName == "Beverages").ToList();
            //var products = db.Products.Where(p => p.Category.CategoryName == "Beverages").Select(p => new { name = p.ProductName, id = p.CategoryId, categoryName = p.Category.CategoryName }).ToList();

            //var categories = db.Categories.Where(c => c.Products.Count() == 0).ToList();
            //var categories = db.Categories.Where(c => c.Products.Any()).ToList();

            //var products = db.Products.Select(p => new {companyName=p.Supplier.CompanyName, contactName=p.Supplier.ContactName, p.ProductName }).ToList();

            // extension methods
            // query expressions

            //var products = (from p in db.Products where p.UnitPrice>10
            //    select p).ToList();

            //var products = (from p in db.Products
            //    join s in db.Suppliers on p.SupplierId equals s.SupplierId
            //    select new
            //    {
            //        p.ProductName, contactName = s.ContactName, companyName = s.CompanyName
            //    }).ToList();

            ////db.Products.Where(p=>p.UnitPrice>10).ToList();

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item.ProductName + " " + item.companyName + " " + item.contactName);
            //}
        }

        private static void Lesson10(NorthwindContext db)
        {
            var p1 = new Product() { ProductId = 86 };
            var p2 = new Product() { ProductId = 85 };

            var products = new List<Product>() { p1, p2 };

            //db.Entry(p).State = EntityState.Deleted;
            db.Products.RemoveRange(products);

            db.SaveChanges();
        }

        private static void Lesson9(NorthwindContext db)
        {
            //var p = db.Products.Find(88);

            //if (p != null)
            //{
            //    db.Products.Remove(p);
            //    db.SaveChanges();
            //}
        }

        private static void Lesson8(NorthwindContext db)
        {
            //var product = db.Products.Find(1);

            //if (product != null)
            //{
            //    product.UnitPrice = 28;

            //    db.Update(product);
            //    db.SaveChanges();
            //}
        }

        private static void Lesson7(NorthwindContext db)
        {
            //var p = new Product() { ProductId = 1 };

            //db.Products.Attach(p);

            //p.UnitsInStock = 50;

            //db.SaveChanges();
        }

        private static void Lesson6(NorthwindContext db)
        {
            //// change tracking
            //var product = db.Products. //AsNoTracking().
            //    FirstOrDefault(p => p.ProductId == 1);

            //if (product != null)
            //{
            //    product.UnitsInStock += 10;

            //    db.SaveChanges();

            //    Console.WriteLine("Data has been updated.");
            //}
        }

        private static void Lesson5(NorthwindContext db)
        {
            //var category = db.Categories.Where(i => i.CategoryName == "Beverages").FirstOrDefault();

            //var p1 = new Product() { ProductName = "new item 11 " };
            //var p2 = new Product() { ProductName = "new item 12 " };

            //var p1 = new Product()
            //{ ProductName = "new item 9", Category = new Category() { CategoryName = "New Category 1" } };
            //var p2 = new Product()
            //{ ProductName = "new item 10", Category = new Category() { CategoryName = "New Category 2" } };

            //var products = new List<Product>()
            //{
            //    p1, p2
            //};

            //category.Products.Add(p1);
            //category.Products.Add(p2);

            //db.Products.AddRange(products);

            //db.SaveChanges();

            //Console.WriteLine("Items have been added.");
            //Console.WriteLine(p1.ProductId);
            //Console.WriteLine(p2.ProductId);
        }

        private static void Lesson4(NorthwindContext db)
        {
            //var results = db.Products.Count();
            //var result = db.Products.Count(i => i.UnitPrice > 10 && i.UnitPrice < 30);
            //var result = db.Products.Count(i => !i.Discontinued);

            //var result = db.Products.Min(p => p.UnitPrice);
            //var result = db.Products.Where(p => p.CategoryId == 2).Max(p => p.UnitPrice);

            //var result = db.Products.Where(p => !p.Discontinued).Average(p => p.UnitPrice);
            //var result = db.Products.Where(p => !p.Discontinued).Sum(p => p.UnitPrice);

            //var result = db.Products.OrderBy(p => p.UnitPrice).ToList();
            //var result = db.Products.OrderByDescending(p => p.UnitPrice).ToList();
            //var result = db.Products.OrderByDescending(p => p.UnitPrice).LastOrDefault();

            //Console.WriteLine(result.ProductName + " " + result.UnitPrice);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.ProductName + " " + item.UnitPrice);
            //}

            //Console.WriteLine(result);
        }

        private static void Lesson3(NorthwindContext db)
        {
            // // ALL CUSTOMERS' INFO

            // var customers = db.Customers.ToList();

            // foreach (var c in customers)
            // {
            //     Console.WriteLine(c.ContactName);
            // }

            // // ALL CUSTOMERS' ID

            // var customerId = db.Customers.Select(c => new { c.CustomerId, c.ContactName }).ToList();

            // foreach (var c in customerId)
            // {
            //     Console.WriteLine(c.CustomerId + ' ' + c.ContactName);
            // }

            ////  CUSTOMERS WHO LIVE IN GERMANY

            // var customerLocation = db.Customers.Select(c => new { c.ContactName, c.Country }).Where(c => c.Country == "Germany")
            //     .ToList();

            // foreach (var c in customerLocation)
            // {
            //     Console.WriteLine(c.Country + ' ' + c.ContactName);
            // }

            // // WHERE DOES "DIEGO ROEL" LIVE? var locationDiego =
            //     db.Customers.Where(l => l.ContactName == "Diego Roel").FirstOrDefault();

            // Console.WriteLine(locationDiego.ContactName + " " + locationDiego.CompanyName);

            // // WHICH PRODUCTS HAVE 0 UNITS IN STOCK

            // var products = db.Products.Select(p => new { p.ProductName, p.UnitsInStock }).Where(p => p.UnitsInStock == 0)
            //     .ToList();

            // foreach (var p in products)
            // {
            //     Console.WriteLine(p.ProductName + " " + p.UnitsInStock);
            // }

            // // ALL EMPLOYEES' FIRST AND LAST NAME

            // var employees = db.Employees.Select(e => new { FullName = e.FirstName + ' ' + e.LastName });
            // foreach (var e in employees)
            // {
            //     Console.WriteLine(e.FullName);
            // }

            // // TAKE STARTING 5 VALUES

            // var products = db.Products.Take(5).ToList();

            // foreach (var p in products)
            // {
            //     Console.WriteLine(p.ProductName + " " + p.ProductId);
            // }

            // // TAKE SECOND 5 VALUES

            // var products = db.Products.Skip(5).Take(5).ToList();

            // foreach (var p in products)
            // {
            //     Console.WriteLine(p.ProductName + " " + p.ProductId);
            // }
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

