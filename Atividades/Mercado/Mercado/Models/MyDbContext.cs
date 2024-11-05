using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Mercado.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> categorias { get; set; }
    }
}
