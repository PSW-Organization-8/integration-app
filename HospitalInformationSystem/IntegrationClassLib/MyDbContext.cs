using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Pharmacy.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace IntegrationClassLib
{
    public class MyDbContext : DbContext
    {

        public DbSet<Pharmacy.Model.Pharmacy> Pharmacies { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Medication> Medications { get; set; }

        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            String connectionString = "Server=localhost; Port =5432; Database =Integration; User Id = postgres; Password =root;";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy.Model.Pharmacy>().HasData(
                new Pharmacy.Model.Pharmacy { Id = 1, Name = "Apoteka1", ApiKey= "fds15d4fs6", Url="http://localhost", Port= "18013" }
            );
            modelBuilder.Entity<Objection>().HasData(
                new Objection { Id = 1, PharmacyName = "Apoteka1", TextObjection = "Lose usluge" }
            );
            modelBuilder.Entity<Response>().HasData(
               new Response { Id = 1, ObjectionId = "1", TextResponse = "Nije tacno" }
           );
            modelBuilder.Entity<Medication>().HasData(new Medication { MedicineID=1, Name = "Synthroid", Quantity = 2 });
        }
    }
}
