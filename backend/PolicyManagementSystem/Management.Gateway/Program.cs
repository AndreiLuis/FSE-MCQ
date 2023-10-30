using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

new WebHostBuilder()
            .UseKestrel(options =>
            {
                options.ListenAnyIP(443, listenOptions =>
                {
                    listenOptions.UseHttps("aspnetapp.pfx", "crypticpassword");
                });
            })
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                    .AddJsonFile("ocelot.json")
                    .AddEnvironmentVariables();
            })
            .ConfigureServices(s => {
                s.AddOcelot();
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                //add your logging
            })
            .UseIISIntegration()
            .Configure(app =>
            {
                app.UseOcelot().Wait();
            })
            .Build()
            .Run();
