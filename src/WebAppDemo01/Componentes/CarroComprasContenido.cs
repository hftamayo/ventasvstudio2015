using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDemo01.models;
using WebAppDemo01.viewmodels;

namespace WebAppDemo01.Componentes
{
    public class CarroComprasContenido: ViewComponent
    {
        private readonly CarroCompras _carroCompras;
        public CarroComprasContenido(CarroCompras carroCompras)
        {
            _carroCompras = carroCompras;
        }//fin del constructor

        public IViewComponentResult Invoke()
        {
            var productosEnCarroCompra = _carroCompras.GetCarroComprasItems();
            _carroCompras.CarroComprasItems = productosEnCarroCompra;
            var carrocomprasViewModel = new CarroComprasViewModel
            {
                CarroCompras = _carroCompras,
                CarroComprasTotal = _carroCompras.GetCarroComprasTotal()
            };
            return View(carrocomprasViewModel);
        }//vin de IViewComponentResult
    }
}
