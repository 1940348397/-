using System.Web.Http;
using WebActivatorEx;
using GZRYVillageWeb;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace GZRYVillageWeb
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "GZRYVillageWeb");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                    {
                        
                    });
        }

        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/GZRYVillageWeb.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
