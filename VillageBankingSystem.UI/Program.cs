using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VillageBankingSystem.UI;
using VillageBankingSystem.UI.Services.Interfaces;
using VillageBankingSystem.UI.Services.Implementations;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ILoanManagementService, LoanManagementService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ISavingsService, SavingsService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
