using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.models
{
    public class CarroComprasDetalles
    {
        private readonly AppDbContext _appDbContext;
        private CarroComprasDetalles(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }//fin del constructor

        public string codigoCarroComprasDetalles { get; set; }
        public List<CarroCompras> CarroCompras { get; set; }

        public static CarroComprasDetalles GetCarroComprasDetalles(IServiceProvider services)
        {
            ISession sesion = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var contexto = services.GetService<AppDbContext>();
            string codigoCarro = sesion.GetString("codigoCarroComprasDetalles") ?? Guid.NewGuid().ToString();
            sesion.SetString("codigoCarroComprasDetalles", codigoCarro);

            return new CarroComprasDetalles(contexto) { codigoCarroComprasDetalles = codigoCarro };
        }//fin de static CarroComprasDetalles

        public void AgregarItemCarroCompras(Productos productos, int cantidad)
        {
            /*
                        var itemComprar = _appDbContext.CarroCompras.SingleOrDefault(
                            cc => cc.Productos.CodigoProducto == productos.CodigoProducto &&
                            cc.codigoCarroCompras == );

                        if(itemComprar == null)
                        {
                            itemComprar = new CarroCompras{
                                codigoCarroCompras = ;
                                Productos = productos;
                                cantidad = 1;
                            };
                        _appDbContext.CarroCompras.Add(itemComprar);
                        }//fin de if(itemComprar)
                        */
        }//fin de void AgregarItemCarroCompras

    }//fin de la clase CarroComprasDetalle
}
