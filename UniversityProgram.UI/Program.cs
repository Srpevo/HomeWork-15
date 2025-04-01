using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UniversityProgram.UI;
using UniversityProgram.UI.Apis.StudentApi.Abstarct;
using UniversityProgram.UI.Apis.StudentApi.Impl;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IStudentApi, StudentApi>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5260");
});


builder.Services.AddMudServices();


await builder.Build().RunAsync();
