using IdentityManagementSample.WebApiCore.Handler;
using Owin;
using System.Net;
using System.Web.Http;

namespace IdentityManagementSample.WebApiCore
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var config = new HttpConfiguration();
            builder.UseWebApi(config);
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new AuthenticationHandler());

            var listener = builder.Properties["System.Net.HttpListener"] as HttpListener;
            listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
        }
    }
}