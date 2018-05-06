using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAppDemo01.models;
using Microsoft.Extensions.Configuration; //extension que se utiliza con IConfigurationRoot
using Microsoft.EntityFrameworkCore; //extension para conexion con SQLServer

namespace WebAppDemo01
{
    public class Startup
    {
        //propiedad para administrar la conexion con el DBMS
        private IConfigurationRoot _configurationRoot;
        //agregacion del metodo constructor de la clase StartUp para instacia de la conexion
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

        }//fin del constructor

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //registrar el AppDBContext para interctuar con la conexion al DBMS
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            //registrar mis clases repositorios y mock ya que todo es un servicio
            //actualizado por implementacion EFCore
            //services.AddTransient<ICatProductosRepositorio, MockCatProductosRepositorio>();
            //services.AddTransient<IProductosRepositorio, MockProductosRepositorio>();
            services.AddTransient<ICatProductosRepositorio, CatProductosRepositorio>();
            services.AddTransient<IProductosRepositorio, ProductosRepositorio>();
            //registros para que la clase CarroCompras pueda trabajar con el DBContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //clase que permite crear un objeto que se asociara con cada usuario que haga
            //uso de la clase CarroCompras. Es como una instancia
            services.AddScoped<CarroCompras>(sp => CarroCompras.GetCarroCompras(sp));
            //agrega soporte MVC a mi proyecto
            services.AddMvc();
            //habilitacion de trabajar con sesiones
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //habilitacion del middleware para sesiones que CarroCompras utilizara
            app.UseSession();
            // configuracion de routing app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "filtrocatproductos",
                    template: "Productos/{action}/{categoriasProductos?}",
                    defaults: new { Controller = "Productos", action = "ListaProductos" });

            routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            DataInicio.AgregarData(app);
        }
    }
}
