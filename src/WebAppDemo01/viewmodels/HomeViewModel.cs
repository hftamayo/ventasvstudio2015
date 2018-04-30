using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDemo01.models;

namespace WebAppDemo01.viewmodels
{
    public class HomeViewModel
    {
        public IEnumerable<Productos> ProductoOfertaSemana { get; set; }
    }
}
