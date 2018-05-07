using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using aliengallery.Services;

namespace aliengallery
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                 services.AddSingleton<AppState>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
