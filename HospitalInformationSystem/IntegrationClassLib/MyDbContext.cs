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
        public DbSet<Notification> Notification { get; set; }


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

            String server = Environment.GetEnvironmentVariable("SERVER") ?? "localhost";
            String port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            String databaseName = Environment.GetEnvironmentVariable("DB_NAME") ?? "Integration";
            String username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
            String password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "saska";


            String connectionString = $"Server={server}; Port ={port}; Database ={databaseName}; User Id = {username}; Password ={password};";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy.Model.Pharmacy>().HasData(
                new Pharmacy.Model.Pharmacy { Id = 1, Name = "Apoteka1", ApiKey = "fds15d4fs6", Url = "http://localhost", Port = "18013", Sftp = false },
                new Pharmacy.Model.Pharmacy { Id = 2, Name = "Apoteka2", ApiKey = "fds15d4fs6", Url = "localhost", Port = "4111", ComunicateWithGrpc=true, Sftp = true },
                new Pharmacy.Model.Pharmacy { Id = 3, Name = "Apoteka3", ApiKey = "fds15d4fs6", Url = "http://localhost", Port = "18013", ComunicateWithGrpc = true, Sftp = true }
            );
            modelBuilder.Entity<Objection>().HasData(
                new Objection { Id = 1, PharmacyName = "Apoteka1", TextObjection = "Lose usluge" }
            );
            modelBuilder.Entity<Notification>().HasData(
               new Notification(1, "Izvestaj", true, "Ovde ce da bude tekst nekog izvestaja", "MedicationSpecifiation.pdf")
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
