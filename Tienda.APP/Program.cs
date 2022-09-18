using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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


//services.AddDbContext<TiendaContext>(options =>
//{
//    var connectionString = @"Server=DESKTOP-I5LKSLD\\\\SQLEXPRESS; Database=Tienda; User Id=admin; Password = admin;";
//    configuration.GetSection("ConnectionString").Value
//    options.UseSqlServer(connectionString);
//}, ServiceLifetime.Singleton);


var serviceProvider = services.BuildServiceProvider();
//var testIntance = serviceProvider.GetService<Test>();
//testIntance.TestMethord();

using (var result = new TiendaContext())
{

}




  