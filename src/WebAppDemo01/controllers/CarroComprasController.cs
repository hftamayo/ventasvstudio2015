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
    public class CarroComprasController : Controller
    {
        private readonly IProductosRepositorio _productosRepositorio;
        private readonly CarroCompras _carroCompras;

        public CarroComprasController(IProductosRepositorio productosRepositorio, CarroCompras carroCompras)
        {
            _productosRepositorio = productosRepositorio;
            _carroCompras = carroCompras;
        }//fin del constructor

        public ViewResult Index()
        {
            var comprasItems = _carroCompras.GetCarroComprasItems();
            _carroCompras.CarroComprasItems = comprasItems;

            var carrocomprasViewModel = new CarroComprasViewModel
            {
                CarroCompras = _carroCompras,
                CarroComprasTotal = _carroCompras.GetCarroComprasTotal()
            };
            return View(carrocomprasViewModel);
        }//fin del metodo ViewResult index 

        public RedirectToActionResult AgregarAlCarroCompras(int codigoProducto)
        {
            var productoSeleccionado = _productosRepositorio.Productos.FirstOrDefault(p => p.CodigoProducto == codigoProducto);
            if(productoSeleccionado != null)
            {
                _carroCompras.AgregarItemCarroCompras(productoSeleccionado, 1);
            }
            return RedirectToAction("Index");
        }//fin de AgregarAlCarroCompras

        public RedirectToActionResult EliminarDelCarroCompras(int codigoProducto)
        {
            var productoSeleccionado = _productosRepositorio.Productos.FirstOrDefault(p => p.CodigoProducto == codigoProducto);
            if (productoSeleccionado != null)
            {
                _carroCompras.EliminarItemCarroCompras(productoSeleccionado);
            }
            return RedirectToAction("Index");
        }//fin de EliminarDelCarroCompras
    }
}
