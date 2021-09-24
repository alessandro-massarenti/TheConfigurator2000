using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using TheConfigurator2000.Classes;


namespace TheConfigurator2000.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Quotation> Quotations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Configurator2000; Trusted_connection = true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddCreatedDateColumn(modelBuilder);
        }

        private static void AddCreatedDateColumn(ModelBuilder modelBuilder)
        {
            var allEntities = modelBuilder.Model.GetEntityTypes();

            foreach (var item in allEntities)
            {
                item.AddProperty("createdDate", typeof(DateTimeOffset)).SetDefaultValueSql("sysdatetimeoffset()");
            }
        }

    }
}
