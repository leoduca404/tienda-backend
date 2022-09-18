using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Application.Interfaces;
using Application.UseCase;
using Infraestructure.Querys;
using Infraestructure.Command;
using Domain.Entities;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Tienda.APP.Controllers;

//1. Create a service collection for DI
ServiceCollection services = new ServiceCollection();

//2. Build a configuration https://www.youtube.com/watch?v=tQdNlju2UXo
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .AddJsonFile("appsettings.json")
    .Build();

//3. Add the configuration to the service collection.
services.AddSingleton<IConfiguration>(configuration);
services.AddScoped<IProductoServices, ProductoServices>();
services.AddScoped<IProductoQuery, ProductoQuery>();
services.AddScoped<IProductoCommand, ProductoCommand>();

//services.AddSingleton<Test>();
//services.AddSingleton<TiendaContext>();


//services.AddDbContext<TiendaContext>(options =>
//{
//    var connectionString = @"Server=DESKTOP-I5LKSLD\\\\SQLEXPRESS; Database=Tienda; User Id=admin; Password = admin;";
//    configuration.GetSection("ConnectionString").Value
//    options.UseSqlServer(connectionString);
//}, ServiceLifetime.Singleton);
var serviceProvider = services.BuildServiceProvider();

//var testIntance = serviceProvider.GetService<IProductoServices>();


//var testIntance = serviceProvider.GetService<Test>();
//testIntance.TestMethord();

using (TiendaContext context = new TiendaContext())
{
    ProductoCommand productoCommand = new ProductoCommand(context);
    ProductoQuery productoQuery = new ProductoQuery(context);
    ProductoServices productoService = new ProductoServices(productoCommand, productoQuery);
    ProductoController productocontroller= new ProductoController(productoService);

    await productocontroller.AddProducto("Sopa3", "SOPA de verdura", "KNOR", "cod21312", 20.50, "url");
}




  