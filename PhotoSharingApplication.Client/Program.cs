using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PhotoSharingApplication.Shared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ICommentsRepository, PhotoSharingApplication.Client.Repositories.ClientCommentsRepository>();

builder.Services.AddScoped(sp => new HttpClient {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

await builder.Build().RunAsync();