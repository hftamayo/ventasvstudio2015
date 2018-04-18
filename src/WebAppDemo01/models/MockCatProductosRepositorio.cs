using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class MockCatProductosRepositorio: ICatProductosRepositorio
    {
        public IEnumerable<CatProductos> CategoriasProductos
        {
            get
            {
                return new List<CatProductos>
                {
                    new CatProductos {CodigoCatProducto = 1, NombreCatProducto = "Raspberry Pi", DescripcionCatProducto = "Productos compatibles con Raspberry Pi" },
                    new CatProductos {CodigoCatProducto = 2, NombreCatProducto = "Arduino", DescripcionCatProducto = "Productos compatibles con Arduino Genuino" },
                    new CatProductos {CodigoCatProducto = 3, NombreCatProducto = "Herramientas", DescripcionCatProducto = "Herramientas para trabajo con Gadgets" }
                };
            }//fin del get
        } //fin de ienumerable
    }//fin de public class
}
