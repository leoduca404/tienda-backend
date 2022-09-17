using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tienda.APP;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

//1. Create a service collection for DI
ServiceCollection services = new ServiceCollection();

//2. Build a configuration https://www.youtube.com/watch?v=tQdNlju2UXo
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .AddJsonFile("appsettings.json")
    .Build();

//3. Add the configuration to the service collection.
services.AddSingleton<IConfiguration>(configuration);
//services.AddSingleton<Test>();
//services.AddSingleton<TiendaContext>();

var serviceProvider = services.BuildServiceProvider();
//var testIntance = serviceProvider.GetService<Test>();
//testIntance.TestMethord();

services.AddDbContext<TiendaContext>(options =>
{
    options.UseSqlServer(configuration.GetSection("ConnectionString").Value);
});

