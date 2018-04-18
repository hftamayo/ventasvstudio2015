using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public interface IProductosRepositorio
    {
        IEnumerable<Productos> Productos { get; }
        IEnumerable<Productos> ProductoOfertaSemana { get; }

        Productos GetProductosPorCodigo(int CodigoProducto);
    }
}
