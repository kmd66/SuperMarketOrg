using Swashbuckle.Application;
using System.Web.Http;

namespace Kama.Organization.API
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Kama.Mefa.Organization.API");
            })
            .EnableSwaggerUi(c =>
            {
            });
        }
    }
}
