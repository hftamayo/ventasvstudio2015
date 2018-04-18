using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class CatProductos
    {
        [Key]
        public int CodigoCatProducto { get; set; }
        public string NombreCatProducto { get; set; }
        public string DescripcionCatProducto { get; set; }
        public List<Productos> Productos { get; set; }
    }
}
