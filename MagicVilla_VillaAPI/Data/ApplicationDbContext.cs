using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(

                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Location = "Chennai",
                    Rate = 4200,
                    SqFt = 3550,
                    DateCreated = DateTime.Now
                },
              new Villa
              {
                  Id = 2,
                  Name = "Grand Villa",
                  Location = "MGR Chennai",
                  Rate = 2200,
                  SqFt = 4550,
                  DateCreated = DateTime.Now

              },
              new Villa
              {
                  Id = 3,
                  Name = "Luxury Villa",
                  Location = "Chennai ECR",
                  Rate = 1200,
                  SqFt = 1550,
                  DateCreated = DateTime.Now,
              });



        }
    }
}

