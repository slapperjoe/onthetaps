using Microsoft.Extensions.Hosting;


using BigBeerData.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Net.Http.Headers;
using System;

IConfiguration config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var host = new HostBuilder()
      .ConfigureFunctionsWorkerDefaults()
        .ConfigureServices(builder =>
        {
           builder.AddDbContext<BigBeerContext>(opt =>
                                   opt.UseSqlServer(
                                       config["DBConnection"]
                                   ));
        })
      .Build();

await host.RunAsync();
