using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class CarroComprasItems
    {
        [Key]
        public int codigoProductoSeleccionado { get; set; }
        public Productos Productos { get; set; }
        public int cantidadProductoSeleccionado { get; set; }
        public string codigoCarroCompras { get; set; }
    }
}
