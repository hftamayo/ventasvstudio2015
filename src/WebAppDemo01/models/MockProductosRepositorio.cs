using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class MockProductosRepositorio: IProductosRepositorio
    {
        private readonly ICatProductosRepositorio _categoriasRepositorio = new MockCatProductosRepositorio();

        public IEnumerable<Productos> Productos
        {
            get
            {
                return new List<Productos>
                {
                    new Productos {CodigoProducto = 1, NombreProducto = "Raspberry Pie 3", DescripProducto = "Modulo Raspberry Pi version 3", PreCostoProducto = 30.0M, PreVentaProducto = 70.0M, EstadoProducto = true, CodigoCategoria = 1 },
                    new Productos {CodigoProducto = 2, NombreProducto = "Raspberry Pie Zero", DescripProducto = "Modulo Raspberry Pi version Zero", PreCostoProducto = 15.0M, PreVentaProducto = 40.0M, EstadoProducto = true, CodigoCategoria = 2 }
                };
            }//fin de get
        }//fin de IEnumerable Productos

        public IEnumerable<Productos> ProductoOfertaSemana { get; }
        public Productos GetProductosPorCodigo(int CodigoProducto)
        {
            throw new System.NotImplementedException();
        }

    }//fin de public class
}
