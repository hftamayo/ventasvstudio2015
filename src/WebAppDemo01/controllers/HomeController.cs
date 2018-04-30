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
    public class HomeController : Controller
    {
        private readonly IProductosRepositorio _productosRepositorio;
        public HomeController(IProductosRepositorio productosRepositorio)
        {
            _productosRepositorio = productosRepositorio;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ProductoOfertaSemana = _productosRepositorio.ProductoOfertaSemana
            };
            return View(homeViewModel);
        }//fin del metodo ViewResult Index
    }//fin de la class Controller
}
