﻿using Microsoft.EntityFrameworkCore;
using API.Models;
using API.DTOs.Roles;

namespace API.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options){}

        public DbSet<Account> Accounts {get; set;}
        public DbSet<AccountRole> AccountRoles { get; set;}
        public DbSet<Booking> Bookings { get; set;}
        public DbSet<Education> Educations { get; set;}
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Role> Roles { get; set;}
        public DbSet<Room> Rooms { get; set;}
        public DbSet<University> Universities { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new NewDefaultRoleDto
                {
                    Guid = Guid.Parse("5eeda544-ee8f-495d-9366-6c04e0904a5c"),
                    Name = "Employee"
                }, new NewDefaultRoleDto
                {
                    Guid = Guid.Parse("4016bbf3-5514-4478-97f8-85a3baef09c2"),
                    Name = "Manager"
                }, new NewDefaultRoleDto
                {
                    Guid = Guid.Parse("24706f51-2651-4cd2-9ca0-c8e510969b7d"),
                    Name = "Admin"
                });

            modelBuilder.Entity<Employee>().HasIndex(e => new
            {
                e.NIK,
                e.Email,
                e.PhoneNumber
            }).IsUnique();

            ////Many Education with One University (N:1) Bisa pake cara ini
            //modelBuilder.Entity<Education>()
            //            .HasOne(e => e.University)
            //            .WithMany(u => u.Educations)
            //            .HasForeignKey(u => u.UniversityGuid);

            //One University to many Education (1:N)
            modelBuilder.Entity<University>()
                        .HasMany(u => u.Educations)
                        .WithOne(e => e.University)
                        .HasForeignKey(e => e.UniversityGuid);

            //One Room to many Booking (1:N)
            modelBuilder.Entity<Room>()
                        .HasMany(r => r.Bookings)
                        .WithOne(b => b.Room)
                        .HasForeignKey(b => b.RoomGuid);

            //One Employee to many Booking (1:N)
            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.Bookings)
                        .WithOne(b => b.Employee)
                        .HasForeignKey(b => b.EmployeeGuid);

            //One Employee to one Education (1:1)
            modelBuilder.Entity<Employee>()
                        .HasOne(emp => emp.Education)
                        .WithOne(edu => edu.Employee)
                        .HasForeignKey<Education>(edu => edu.Guid);

            //One Employee to one Account (1:1)
            modelBuilder.Entity<Employee>()
                        .HasOne(emp => emp.Account)
                        .WithOne(acc => acc.Employee)
                        .HasForeignKey<Account>(acc => acc.Guid);

            //One Account to many Account Role (1:N)
            modelBuilder.Entity<Account>()
                        .HasMany(acc => acc.AccountRoles)
                        .WithOne(accRole => accRole.Account)
                        .HasForeignKey(accRole => accRole.AccountGuid);
                        //.OnDelete(DeleteBehavior.Restrict);

            //One Role to many Account Role (1:N)
            modelBuilder.Entity<Role>()
                        .HasMany(r => r.AccountRoles)
                        .WithOne(accRole => accRole.Role)
                        .HasForeignKey(accRole => accRole.RoleGuid);
        }
    }
}
