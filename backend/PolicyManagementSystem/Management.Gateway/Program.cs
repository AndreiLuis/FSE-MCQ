using Microsoft.Extensions.DependencyInjection;
using MMLib.SwaggerForOcelot.DependencyInjection;
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
                    //.AddJsonFile("ocelot.json")
                    .AddEnvironmentVariables()
                    .AddOcelotWithSwaggerSupport(option =>
                    {
                        option.Folder = "Routes";
                    });
            })
            .ConfigureServices(service => {
                service.AddOcelot();
                service.AddSwaggerForOcelot(service.BuildServiceProvider().GetService<IConfiguration>());
                //service.AddSwaggerGen();
                service.AddMvcCore().AddApiExplorer();
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                //add your logging
            })
            .UseIISIntegration()
            .Configure(app =>
            {
                app.UseOcelot().Wait();
                app.UseSwaggerForOcelotUI(option =>
                {
                    option.PathToSwaggerGenerator = "/swagger/docs";
                });
            })
            .Build()
            .Run();
