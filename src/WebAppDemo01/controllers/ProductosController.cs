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
        public ViewResult ListaProductos()
        {
            //objetos para mostrar las categorias de los productos
            ListaProductosViewModel listaproductosViewModel = new ListaProductosViewModel();
            listaproductosViewModel.Productos = _productosRepositorio.Productos;
            //pasando intencionalmente un valor a la variable de la clase
            listaproductosViewModel.CategoriasProductos = "Tabletas de Entrenamiento";

            //return View(_productosRepositorio.Productos);
            return View(listaproductosViewModel);
        }//fin del metodo ListaProductos

    }
}
