using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;

namespace SelfHost.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:5566");

            config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );


            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                Type valuesControllerType = typeof(APIServiceLib.TestController);

                // Set our own assembly resolver where we add the assemblies we need
                //APIAssembliesResolver assemblyResolver = new APIAssembliesResolver();
                //config.Services.Replace(typeof(IAssembliesResolver), assemblyResolver);

                server.OpenAsync().Wait();                
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }

    public class APIAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
            var controllersAssembly = Assembly.LoadFrom(@"C:\somePath\controllerlib.dll");
            baseAssemblies.Add(controllersAssembly);
            return assemblies;
        }
    }
}