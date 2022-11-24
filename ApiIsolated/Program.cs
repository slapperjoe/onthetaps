using Microsoft.Extensions.Hosting;



using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Net.Http.Headers;
using System;
using OnTheTaps.Shared.Models;

IConfiguration config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var host = new HostBuilder()
      .ConfigureFunctionsWorkerDefaults()
        .ConfigureServices(builder =>
        {
           builder.AddDbContext<BigBeerDataCoreContext>(opt =>
                                   opt.UseSqlServer(
                                       config["DBConnection"]
                                   ));
        })
      .Build();

await host.RunAsync();
