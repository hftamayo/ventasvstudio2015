using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class Productos
    {
        [Key]
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripProducto { get; set; }
        public decimal PreCostoProducto { get; set; }
        public decimal PreVentaProducto { get; set; }
        public bool EstadoProducto { get; set; }
        public int CodigoCategoria { get; set;  }
        public virtual CatProductos CatProductos { get; set; }


    }
}
