using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BusinessClockApi.ContractTestsPlaywright;


public class PlaywrightWebApplicationFactory
    : WebApplicationFactory<Program>
{
    private IHost? _host = null;
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var testHost = builder.Build();
        builder.ConfigureWebHost(whb => whb.UseKestrel(opts =>
        {
            opts.Listen(IPAddress.Loopback, GetRandomUnusedPort());
        }));

         _host = builder.Build();
         
        _host.Start();
        var server = _host.Services.GetRequiredService<IServer>();  
        var addresses = server.Features.Get<IServerAddressesFeature>();  
 
        ClientOptions.BaseAddress = addresses!.Addresses  
            .Select(x => new Uri(x))  
            .Last();  
        
        testHost.Start();  
        return testHost;  
    }

    public string ServerAddress  
    {  
        get 
        {  
            EnsureServer();  
            return ClientOptions.BaseAddress.ToString();  
        }  
    }
    private void EnsureServer()  
    {  
        if (_host is null)  
        {  
            // This forces WebApplicationFactory to bootstrap the server  
            using var _ = CreateDefaultClient();  
        }  
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(ConfigureServices);
    }

    protected virtual void ConfigureServices(IServiceCollection serviceProvider)
    {
        // could make this abstract, but this is a template method.
    }
    protected override void Dispose(bool disposing)
    {
        _host?.Dispose();
    }

    // From https://khalidabuhakmeh.com/end-to-end-test-with-aspnet-core-xunit-and-playwright
    private static int GetRandomUnusedPort()
    {
        var listener = new TcpListener(IPAddress.Any, 0);
        listener.Start();
        var port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }
}
