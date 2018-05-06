using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDemo01.models;

namespace WebAppDemo01.Componentes
{
    public class CategoriasMenu: ViewComponent
    {
        private readonly ICatProductosRepositorio _catproductosRepositorio;
        public CategoriasMenu(ICatProductosRepositorio catproductosRepositorio)
        {
            _catproductosRepositorio = catproductosRepositorio;
        }//fin del constructor
        public IViewComponentResult Invoke()
        {
            var catproductos = _catproductosRepositorio.CategoriasProductos.OrderBy(cp => cp.NombreCatProducto);
            return View(catproductos);
        }
    }
}
