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
        public string DescripCortaProducto { get; set; }
        public string DescripLargaProducto { get; set; }
        public decimal PreCostoProducto { get; set; }
        public decimal PreVentaProducto { get; set; }
        public string ImagenURL { get; set; }
        public string ImagenPreviaURL { get; set; }
        public bool ProductoEnOferta { get; set; }
        public bool ProductoEnExistencia { get; set; }
        public bool EstadoProducto { get; set; }
        public int CodigoCategoria { get; set;  }
        public virtual CatProductos CatProductos { get; set; }
    }
}
