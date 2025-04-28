using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class CinemaManagementDbContext : DbContext
    {
        //Constructor
        public CinemaManagementDbContext() 
        {

            Database.EnsureCreated();

        }

        public CinemaManagementDbContext(DbContextOptions options) : base(options)
        {

        }



        //Configuring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);

            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CinemaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            optionsBuilder.UseSqlServer(conn);

        }

        //Initialize default data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //Creating default model

        }

        //Creating DbSets
        public DbSet<Film> Films { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Ticket> Ticket { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<Discount> Discounts { get; set; }

    }
}
