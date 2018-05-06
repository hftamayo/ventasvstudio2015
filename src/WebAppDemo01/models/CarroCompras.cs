using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class CarroCompras
    {
        private readonly AppDbContext _appDbContext;
        private CarroCompras(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }//fin del constructor

        public string codigoCarroCompras{ get; set; }
        public List<CarroComprasItems> CarroComprasItems { get; set; }

        public static CarroCompras GetCarroCompras(IServiceProvider services)
        {
            ISession sesion = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var contexto = services.GetService<AppDbContext>();
            string codigoCarro = sesion.GetString("codigoCarro") ?? Guid.NewGuid().ToString();
            sesion.SetString("codigoCarroCompras", codigoCarro);

            return new CarroCompras(contexto) { codigoCarroCompras= codigoCarro};
        }//fin de static CarroComprasDetalles

        public void AgregarItemCarroCompras(Productos productos, int cantidad)
        {
            var carroComprasItem = _appDbContext.CarroComprasItems.SingleOrDefault(
                            cci => cci.Productos.CodigoProducto == productos.CodigoProducto &&
                            cci.codigoCarroCompras == codigoCarroCompras);

           if(carroComprasItem == null)
                {
                carroComprasItem = new CarroComprasItems{
                                codigoCarroCompras = codigoCarroCompras,
                                Productos = productos,
                                cantidadProductoSeleccionado = 1
                            };
                _appDbContext.CarroComprasItems.Add(carroComprasItem);
                }//fin de if(itemComprar)
            else
                {
                carroComprasItem.cantidadProductoSeleccionado++;
                }
            _appDbContext.SaveChanges();
        }//fin de void AgregarItemCarroCompras

        public int EliminarItemCarroCompras(Productos productos)
        {
            var carroComprasItem = _appDbContext.CarroComprasItems.SingleOrDefault(
                cci => cci.Productos.CodigoProducto == productos.CodigoProducto && cci.codigoCarroCompras == codigoCarroCompras);
            var localMonto = 0;

            if(carroComprasItem != null)
            {
                if(carroComprasItem.cantidadProductoSeleccionado > 1)
                {
                    carroComprasItem.cantidadProductoSeleccionado--;
                    localMonto = carroComprasItem.cantidadProductoSeleccionado;
                }
                else
                {
                    _appDbContext.CarroComprasItems.Remove(carroComprasItem);
                }
            }//fin de carroComprasItem null
            _appDbContext.SaveChanges();
            return localMonto;
        }//fin de eliminarItemCarroCompras

        public List<CarroComprasItems> GetCarroComprasItems()
        {
            return CarroComprasItems ??
                (CarroComprasItems =
                _appDbContext.CarroComprasItems.Where(cc => cc.codigoCarroCompras == codigoCarroCompras)
                .Include(cci => cci.Productos)
                .ToList());
        }//fin de GetCarroComprasItems

        public void LimpiarCarroCompras()
        {
            var carroItems = _appDbContext
                .CarroComprasItems
                .Where(carro => carro.codigoCarroCompras == codigoCarroCompras);
            _appDbContext.CarroComprasItems.RemoveRange(carroItems);
            _appDbContext.SaveChanges();
        }//fin de LimpiarCarroCompras

        public decimal GetCarroComprasTotal()
        {
            var totalCarroCompra = _appDbContext.CarroComprasItems.Where(cc => cc.codigoCarroCompras == codigoCarroCompras)
                .Select(cc => cc.Productos.PreVentaProducto * cc.cantidadProductoSeleccionado).Sum();
            return totalCarroCompra;
        }//fin de GetCarroComprasTotal
    }//fin de la clase CarroCompras
}
