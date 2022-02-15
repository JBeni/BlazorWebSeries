using Blazored.Toast;
using BlazorWebSeries.Client;
using BlazorWebSeries.Client.AuthProviders;
using BlazorWebSeries.Client.HttpRepository;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

try
{

    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Services.AddOptions();
    builder.Services.AddBlazoredToast();
    builder.Services.AddMatBlazor();
    builder.Services.AddLoadingBar();

    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7085/api/") });
    builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();

    builder.Services.AddAuthorizationCore();
    builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

    builder.UseLoadingBar();
    await builder.Build().RunAsync();
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.Message);
}
