using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class CarroCompras
    {
        [Key]
        public int codigoCarroCompras { get; set; }
        public int codigoItemSeleccionado { get; set; }
        public Productos Productos { get; set; }
        public int cantidadSeleccionada { get; set; }
    }
}
