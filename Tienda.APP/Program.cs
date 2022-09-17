using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tienda.APP;

//1. Create a service collection for DI
var serviceCollection = new ServiceCollection();

//2. Build a configuration https://www.youtube.com/watch?v=tQdNlju2UXo
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .AddJsonFile("appsettings.json")
    .Build();

Console.WriteLine(configuration);

//3. Add the configuration to the service collection.
serviceCollection.AddSingleton<IConfiguration>(configuration);
serviceCollection.AddSingleton<Test>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var testIntance = serviceProvider.GetService<Test>();
testIntance.TestMethord();