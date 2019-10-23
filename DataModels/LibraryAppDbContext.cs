using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataModels
{
    public class LibraryAppDbContext : DbContext
    {
        public LibraryAppDbContext(DbContextOptions options)
        : base(options) { }

        public DbSet<UserDTO> Users { get; set; }
        public DbSet<BookDTO> Books { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDTO>()
                .HasOne(x => x.User)
                .WithMany(x => x.BookList)
                .HasForeignKey(x => x.UserId);

            //HashedPassword
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            //Seeding
            modelBuilder.Entity<UserDTO>()
                .HasData(
                new UserDTO()
                {
                    Id = 1,
                    Username = "bob007",
                    Password = hashedPassword,
                    FirstName = "Bob",
                    LastName = "Bobsky",                   
                });
            modelBuilder.Entity<BookDTO>()
                .HasData(
                new BookDTO()
                {
                    Id = 1,
                    Author = "Annie Auerbach",
                    Title = "SpongeBob Superstar",
                    Context = @"SpongeBob's ego--and head--swell when he is selected to  
                    star in a television special as the world's biggest daredevil,  
                    but hotshot producer Barry Cuda has another role in mind for him.",
                    Genre = 6,
                    NumbersOfCopies = 10,
                    Image = "https://images-na.ssl-images-amazon.com/images/I/51aF2mEeDrL._SX341_BO1,204,203,200_.jpg",
                    UserId = 1
                },
                new BookDTO()
                {
                    Id = 2,
                    Author = "Clive Cussler",
                    Title = "Valhalla rising",
                    Context = @"Marine explorer Dirk Pitt must rely on the nautical lore
                    of Jules Verne to stop a ruthless oil baron with his sights set on political
                    power in this #1 New York Times-bestselling series.",
                    Genre = 5,
                    NumbersOfCopies = 8,
                    Image= "https://images-na.ssl-images-amazon.com/images/I/81LXwqs6eiL.jpg",
                    UserId = 1
                });
        }
    }
}
