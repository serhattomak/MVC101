﻿using System;
using System.Linq;
using LINQSamples.Data;

namespace LINQSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                var products = db.Products.ToList();

                foreach (var p in products)
                {
                    Console.WriteLine(p.ProductName);
                }
            }

            Console.ReadLine();
        }
    }
}

