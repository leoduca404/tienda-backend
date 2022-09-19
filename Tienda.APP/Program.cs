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

//1. Create a service collection for DI
ServiceCollection services = new ServiceCollection();

//2. Build a configuration https://www.youtube.com/watch?v=tQdNlju2UXo
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .AddJsonFile("appsettings.json")
    .Build();

//3. Add the configuration to the service collection.
services.AddSingleton<IConfiguration>(configuration);

services.AddSingleton<IProductoServices, ProductoServices>();
services.AddSingleton<IProductoQuery, ProductoQuery>();
services.AddSingleton<IProductoCommand, ProductoCommand>();
services.AddSingleton<ProductoController>();

services.AddSingleton<IClienteServices, ClienteServices>();
services.AddSingleton<IClienteQuery, ClienteQuery>();
services.AddSingleton<IClienteCommand, ClienteCommand>();
services.AddSingleton<ClienteController>();

services.AddSingleton<Menu>();

services.AddDbContext<TiendaContext>(options =>
{
    var connectionString = @"Server=.\SQLEXPRESS;Database=TiendaLeo;Integrated Security=SSPI;";    
    options.UseSqlServer(connectionString);
}, ServiceLifetime.Singleton);

var serviceProvider = services.BuildServiceProvider();

var menu = serviceProvider.GetService<Menu>();
if (menu != null) { await menu.InicializarMenu(); }
