﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperProductRepository(conn);

            repo.CreateProduct("newStuff", 20, 1);

            var products = repo.GetAllProducts();

            foreach(var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }


            //var repo = new DapperDepartmentRepository(conn);

            //var departments = repo.GetAllDepartments();

            //foreach(var dept in departments)
            //{
            //    Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
            //}
        }

    }
}
