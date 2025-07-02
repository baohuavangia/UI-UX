using MenShopUI;
using MenShopUI.Services.BranchProduct;
using MenShopUI.Services.Color;
using MenShopUI.Services.Fabric;
using MenShopUI.Services.Size;
using MenShopUI.Services.OrderCustomer;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IFabricService, FabricService>();
builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped<IBranchProductService, BranchProductService>();
builder.Services.AddScoped<IOrderCustomerService, OrderCustomerService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorBootstrap();
await builder.Build().RunAsync();
