using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Consol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var purchase = new Purchase()
                {
                    Id = 1,
                    Product = "Laptop",
                    Price = 1000
                };

                context.Purchases.Add(purchase);

                context.SaveChanges();

                //
                // var allPurchases = context.Purchases.ToList();



                context.Purchases.Update(purchase);


                context.Purchases.FirstOrDefault(p => p.Product == "Shoes");

            }
        }   
    }

    public class MyDbContext : DbContext
    {
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Server=.;Database=EF_Test;Tusted_Connection=True;MultipleActiveResultSets=True;");
           optionsBuilder.UseInMemoryDatabase("EF_Test");
        }

    }

    public class Purchase
    {
        public int Id { get; set; }
        public string? Product { get; set; }
        public decimal Price { get; set; }
    }
}
