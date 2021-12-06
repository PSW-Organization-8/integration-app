using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Pharmacy.Model;
using IntegrationClassLib.SharedModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace IntegrationClassLib
{
    public class MyDbContext : DbContext
    {

        public DbSet<Pharmacy.Model.Pharmacy> Pharmacies { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Floor> Floors { get; set; }
        public DbSet<Building> Buildings { get; set; }

        public DbSet<IntegrationClassLib.SharedModel.Equipment> Equipments { get; set; }

        public DbSet<IntegrationClassLib.SharedModel.MoveEquipment> MoveEquipments { get; set; }

        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            String connectionString = "Server=localhost; Port =5432; Database =integration; User Id = postgres; Password =root;";
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
            modelBuilder.Entity<MedicationConsumption>().HasData(
             new MedicationConsumption { MedicineID = 1, MedicineName = "Brufen", DateTime = DateTime.ParseExact("11/11/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), Quantity = 32 },
             new MedicationConsumption { MedicineID = 2, MedicineName = "Vitamin C", DateTime = DateTime.ParseExact("11/11/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), Quantity = 16 },
             new MedicationConsumption { MedicineID = 3, MedicineName = "Brufen", DateTime = DateTime.ParseExact("11/11/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), Quantity = 56 }
         );
        }
    }
}
