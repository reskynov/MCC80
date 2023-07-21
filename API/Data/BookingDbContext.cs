using Microsoft.EntityFrameworkCore;
using API.Models;

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
            modelBuilder.Entity<Education>()
                        .HasOne(emp => emp.Employee)
                        .WithOne(edu => edu.Education)
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

            //One Role to many Account Role (1:N)
            modelBuilder.Entity<Role>()
                        .HasMany(r => r.AccountRoles)
                        .WithOne(accRole => accRole.Role)
                        .HasForeignKey(accRole => accRole.RoleGuid);
        }
    }
}
