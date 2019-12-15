namespace TestingEntityRelations
{
    using System;
    using System.Linq;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using TestingEntityRelations.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new CarDbContext();

            db.Database.Migrate();

            db.SaveChanges();

            //---- Adding a new customer.
            //var car = db
            //    .Cars
            //    .FirstOrDefault();

            //var customer = new Customer
            //{
            //    FirstName = "Ivan",
            //    LastName = "Peshov",
            //    Age = 29
            //};

            //---- Adding a new car.
            //var insigniaModel = db
            //    .Models
            //    .FirstOrDefault(m => m.Name == "Insignia");

            //insigniaModel
            //    .Cars
            //    .Add(new Car
            //    {
            //        Color = "Black",
            //        Price = 20000,
            //        ProductionDate = DateTime.UtcNow.AddDays(-100),
            //        Vin = "astqwo1275410245a"
            //    });

            //---- Searching for make Opel and adding Model Astra.
            //var opelMake = db
            //    .Makes
            //    .FirstOrDefault(n => n.Name == "Opel");

            //opelMake
            //    .Models
            //    .Add(new Model
            //    {
            //        Name = "Astra",
            //        Year = 2017,
            //        Modification = "OPC"
            //    });

            //---------------------------------------------

            //----Adding a new make.
            //db.Makes.Add(new Make
            //{
            //    Name = "Opel"
            //});
        }
    }
}

