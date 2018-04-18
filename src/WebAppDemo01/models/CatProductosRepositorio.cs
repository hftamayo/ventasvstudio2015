using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;//operaciones con las conexiones

namespace WebAppDemo01.models
{
    public class CatProductosRepositorio: ICatProductosRepositorio
    {
        private readonly AppDbContext _appDbContext;

        //metodo constructor 
        public CatProductosRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }//fin del constructor

        //extension de los metodos disponibles en la clase interface
        public IEnumerable<CatProductos> CategoriasProductos => _appDbContext.CategoriasProductos;

    }
}
