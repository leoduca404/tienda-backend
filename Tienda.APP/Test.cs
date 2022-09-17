using Microsoft.Extensions.Configuration;

namespace Tienda.APP
{
    public class Test
    {
        private readonly IConfiguration configuration;

        public Test(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void TestMethord()
        {
            var dataFromJsonFile = configuration.GetSection("ConnectionString").Value;         
        }
    }
}
