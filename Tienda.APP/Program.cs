using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.UseCase;
using Infraestructure.Querys;
using Infraestructure.Command;
using Tienda.APP.Controllers;
using Tienda.APP;
using Tienda.APP.Services;
using Tienda.APP.Helpers;
using Tienda.APP.Ventas.Services;

//1. Create a service collection for DI
ServiceCollection services = new ServiceCollection();

//2. Build a configuration https://www.youtube.com/watch?v=tQdNlju2UXo
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .AddJsonFile("appsettings.json")
    .Build();

//3. Add the configuration to the service collection.
services.AddSingleton<IConfiguration>(configuration);

services.AddSingleton<IProductoServices,ProductoServices>();
services.AddSingleton<IProductoQuery, ProductoQuery>();
services.AddSingleton<IProductoCommand, ProductoCommand>();
services.AddSingleton<ServicesProducto>();

services.AddSingleton<IOrdenServices,ClienteServices>();
services.AddSingleton<IOrdenQuery, ClienteQuery>();
services.AddSingleton<IOrdenCommand, ClienteCommand>();
services.AddSingleton<ServicesCliente>();

services.AddSingleton<ICarritoServices,CarritoServices>();
services.AddSingleton<ICarritoQuery, CarritoQuery>();
services.AddSingleton<ICarritoCommand, CarritoCommand>();
services.AddSingleton<ServicesCarrito>();
services.AddSingleton<Menu>();
services.AddSingleton<LogicaPantalla>();
services.AddSingleton<Reportes>();


services.AddDbContext<TiendaContext>(options =>
{
    var connectionString = configuration.GetSection("ConnectionString").Value;
    options.UseSqlServer(connectionString);
}, ServiceLifetime.Singleton);

var serviceProvider = services.BuildServiceProvider();

var menu = serviceProvider.GetService<Menu>();
if (menu != null) {await menu.InicializarMenuPrincipal(); }
