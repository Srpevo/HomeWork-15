using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UniversityProgram.UI;
using UniversityProgram.UI.Apis.StudentApi.Impl;
using UniversityProgram.UI.Handlers;
using MudBlazor.Services;
using UniversityProgram.UI.Apis.StudentApi.Abstract;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ServerAPI",
      client => client.BaseAddress = new Uri("http://localhost:5260"))
    .AddHttpMessageHandler<UPMessageHandler>();

builder.Services.AddTransient<UPMessageHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
  .CreateClient("ServerAPI"));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]!);
});

builder.Services.AddHttpClient<IStudentApi, StudentApi>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5260");
}).AddHttpMessageHandler<UPMessageHandler>();


builder.Services.AddMudServices();


await builder.Build().RunAsync();
