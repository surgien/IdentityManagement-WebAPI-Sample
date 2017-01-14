using Microsoft.Owin.Hosting;
using System;

namespace IdentityManagementSample.WebApiCore
{
    public class WebApiService : IDisposable
    {
        private IDisposable _webApp;

        public void Dispose()
        {
            _webApp.Dispose();
        }

        public void Start(string uri)
        {
            var options = new StartOptions();

            options.Urls.Add(uri);
            
            _webApp = WebApp.Start<Startup>(options);
        }
    }
}
