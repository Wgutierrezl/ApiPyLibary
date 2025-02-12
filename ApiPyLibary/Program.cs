using ApiPyLibary;
using ApiPyLibary.Servicios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://127.0.0.1:8000/") });
builder.Services.AddScoped<IServiciosAutor, ServiciosAutor>();
builder.Services.AddScoped<IServiciosLibros, ServiciosLibros>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
