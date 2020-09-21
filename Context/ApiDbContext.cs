using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Hbsis.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> optionsDb) : base(optionsDb)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=NT-04871;Database=master;Initial Catalog=CatalogoDB;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}