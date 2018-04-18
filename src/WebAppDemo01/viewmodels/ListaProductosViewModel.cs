using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDemo01.models;

namespace WebAppDemo01.viewmodels
{
    public class ListaProductosViewModel
    {
        public IEnumerable<Productos> Productos { get; set; }
        public string CategoriasProductos { get; set; }
    }
}
