using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class ProductosRepositorio : IProductosRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public ProductosRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Productos> Productos
        {
            get
            {
                return _appDbContext.Productos.Include(c => c.CatProductos);
            }
        }

        public IEnumerable<Productos> ProductoOfertaSemana
        {
            get
            {
                return _appDbContext.Productos.Include(c => c.CatProductos).Where(p => p.ProductoEnOferta);
            }
        }

        public Productos GetProductosPorCodigo(int CodigoProducto)
        {
            return _appDbContext.Productos.FirstOrDefault(p => p.CodigoProducto == CodigoProducto);
        }
    }
}
