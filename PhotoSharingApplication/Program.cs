using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PhotoSharingApplication.Components;
using PhotoSharingApplication.Shared.Data;
using PhotoSharingApplication.Shared.Interfaces;
using PhotoSharingApplication.Shared.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//builder.Services.AddSingleton<IPhotosRepository, PhotosListRepository>();
builder.Services.AddScoped<IPhotosRepository, PhotosEFRepository>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();

builder.Services.AddDbContextFactory<PhotosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PhotosDbContext"),
    sqlOptions => sqlOptions.MigrationsAssembly("PhotoSharingApplication")
));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PhotoSharingApplication.Client._Imports).Assembly);

app.Run();
