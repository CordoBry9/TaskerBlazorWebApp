using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NEWWEBAPP.Client;
using NEWWEBAPP.Client.Services;
using NEWWEBAPP.Client.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

//add httpclient as a service

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

//@inject ITaskerItemService service
builder.Services.AddScoped<ITaskerItemService, TaskerItemService_Client>();

await builder.Build().RunAsync();
