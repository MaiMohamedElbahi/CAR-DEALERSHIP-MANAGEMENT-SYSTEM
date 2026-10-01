using System.Xml.Linq;
using System;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Azure.Core.HttpHeader;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using AutoMapper;
using System.Net;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { 
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //            Customer ↔ CustomerProfile 1:1 Customer has one
            //CustomerProfile.

            modelBuilder.Entity<Customer>().HasOne(e => e.CustomerProfile).WithOne(e => e.Customer).HasForeignKey<CustomerProfile>(e => e.CustomerId);
            modelBuilder.Entity<Employee>().HasMany(e => e.Sales).WithOne(s => s.Employee).HasForeignKey(s => s.EmployeeId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>().HasMany(c => c.Sales).WithOne(s => s.Customer).HasForeignKey(s => s.CustomerId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasMany(c => c.Vehicles).WithOne(v => v.Category).HasForeignKey(v => v.CategoryId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehicle>().HasOne(v => v.Sale).WithOne().HasForeignKey<Sale>(s => s.VehicleId).OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(v => v.VIN).IsUnique();
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.DriverLicenseNumber).IsUnique();
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();
            modelBuilder.Entity<Vehicle>().Property(v => v.Price).HasPrecision(12, 2);
            modelBuilder.Entity<Sale>().Property(s => s.SalePrice).HasPrecision(12, 2);
            modelBuilder.Entity<Vehicle>().Property(v => v.Status).HasDefaultValue("Available");



            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Sedan", Description = "Comfortable passenger cars" },
                new Category { CategoryId = 2, Name = "SUV", Description = "Sport utility vehicles" },
                new Category { CategoryId = 3, Name = "Hatchback", Description = "Compact practical cars" }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1, Make = "Toyota", Model = "Corolla", Year = 2024, Color = "White", Price = 650000, Mileage = 12000, VIN = "VIN0000000000000", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 1 },
                new Vehicle { VehicleId = 2, Make = "Hyundai", Model = "Elantra", Year = 2023, Color = "Black", Price = 590000, Mileage = 18000, VIN = "VIN0000000000001", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 1 },
                new Vehicle { VehicleId = 3, Make = "Kia", Model = "Sportage", Year = 2024, Color = "Gray", Price = 980000, Mileage = 9000, VIN = "VIN0000000000002", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 2 }
                );


            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FullName = "Ahmed Hassen", Email = "ahmed.hassan@example.com", Phone = "01010000001", DriverLicenseNumber = "DL100001" },
                new Customer { CustomerId = 2, FullName = "Mona Adel", Email = "mona.adel@example.com", Phone = "01010000002", DriverLicenseNumber = "DL100002" },
                new Customer { CustomerId = 3, FullName = "Omar Khaled", Email = "omar.khaled@example.com", Phone = "01010000003", DriverLicenseNumber = "DL100003"});


            modelBuilder.Entity<CustomerProfile>().HasData(
                 new CustomerProfile { CustomerProfileId = 1, Address = "12 Nile St.", City = "Cairo", Nationality = "Egyptian", DateOfBirth = new DateTime(1992, 3, 12), CustomerId = 1 },
                 new CustomerProfile { CustomerProfileId = 2, Address = "25 Tahrir St.", City = "Giza", Nationality = "Egyptian", DateOfBirth = new DateTime(1995, 7, 24), CustomerId = 2 },
                    new CustomerProfile { CustomerProfileId = 3, Address = "18 El Nasr St.", City = "Cairo", Nationality = "Egyptian", DateOfBirth = new DateTime(1988, 11, 5), CustomerId = 3 }
                    );


            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FullName = "Mostafa Nabil", Position = "Sales Manager", Email = "mostafa.nabil@autodrive.com", Phone = "01020000001", HireDate = new DateTime(2021, 1, 15) },
                new Employee { EmployeeId = 2, FullName = "Aya Emad", Position = "Sales Consultant", Email = "aya.emad@autodrive.com", Phone = "01020000002", HireDate = new DateTime(2022, 4, 15) },
                new Employee { EmployeeId = 3, FullName = "Hassan Ali", Position = "Sales Consultant", Email = "hassen.ali@autodrive.com", Phone = "01020000003", HireDate = new DateTime(2023, 2, 20) }
                );

            //            6.Sales — 3 record
            //Id SaleDate SalePrice PaymentMethod Notes
            //1 2026 - 08 - 15 1750000 Bank Transfer Completed sale.
            //2 2026 - 08 - 22 1850000 Bank Transfer Completed sale.
            //3 2026 - 09 - 05 510000 Cash Completed sale.

            modelBuilder.Entity<Sale>().HasData(
                new Sale { SaleId = 1, SaleDate = new DateTime(2026, 8, 15), SalePrice = 1750000, PaymentMethod = "Bank Transfer", Notes = "Completed sale." , CustomerId = 1 , EmployeeId = 1 , VehicleId = 1},
                new Sale { SaleId = 2, SaleDate = new DateTime(2026, 8, 22), SalePrice = 1850000, PaymentMethod = "Bank Transfer", Notes = "Completed sale.", CustomerId = 2, EmployeeId = 2, VehicleId = 2 },
                new Sale { SaleId = 3, SaleDate = new DateTime(2026, 9, 5), SalePrice = 510000, PaymentMethod = "Cash", Notes = "Completed sale.", CustomerId = 3, EmployeeId = 3, VehicleId = 3 }

                );
        }

    }
}
