using Microsoft.AspNet.OData.Extensions;
using Owin;
using System.Web.Http;

namespace PetzeyPetApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration.EnableDependencyInjection();
        }
    }
}
