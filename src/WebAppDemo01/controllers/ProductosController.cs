using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppDemo01.models;
using WebAppDemo01.viewmodels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppDemo01.controllers
{
    public class ProductosController : Controller
    {
        //objetos de solo lectura que sera instancias de las clases repositorios
        private readonly ICatProductosRepositorio _catproductosRepositorio;
        private readonly IProductosRepositorio _productosRepositorio;

        //constructor de esta clase controller
        public ProductosController(ICatProductosRepositorio catproductosRepositorio, IProductosRepositorio productosRepositorio)
        {
            _catproductosRepositorio = catproductosRepositorio;
            _productosRepositorio = productosRepositorio;
        }//fin del constructor

        //metodo para devolver la vista con datos inyectados
        public ViewResult ListaProductos(string categoriasProductos)
        {
            //bug: si la categoria no se digite justo como esta 
            //almacenada genera un NullReferenceException
            IEnumerable<Productos> productos;
            string categoriaActual = string.Empty;
            if (string.IsNullOrEmpty(categoriasProductos))
            {
                productos = _productosRepositorio.Productos.OrderBy(p => p.CodigoProducto);
                categoriaActual = "Todos los Productos";
            }
            else
            {
                productos = _productosRepositorio.Productos.Where(p => p.CatProductos.NombreCatProducto == categoriasProductos)
                    .OrderBy(p => p.CodigoProducto);
                categoriaActual = _catproductosRepositorio.CategoriasProductos.FirstOrDefault(c => c.NombreCatProducto == categoriasProductos).NombreCatProducto;
            }

            return View(new ListaProductosViewModel
            {
                Productos = productos,
                CategoriasProductos = categoriaActual
            });
        }//fin del metodo ListaProductos

        public IActionResult Detalles(int codigo)
        {
            var producto = _productosRepositorio.GetProductosPorCodigo(codigo);
            if(producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

    }
}
