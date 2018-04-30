using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebAppDemo01.models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }//fin del constructor

        public DbSet<CatProductos> CategoriasProductos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<CarroCompras> CarroCompras { get; set; }

    }
}
