using EmployeeManagementWeb;
using EmployeeManagementWeb.Models;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
<<<<<<< HEAD
builder.Services.AddMudServices();
=======
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
>>>>>>> 5e3f393fb8e68cb5445b23b26adf0cee869468a1
//builder.Services.AddSingleton<WeatherForecastService>();


//Add Http client method
builder.Services.AddHttpClient<IEmployeeService,EmployeeService>(client=>
{
    client.BaseAddress = new Uri("https://localhost:7119/");
});
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7119/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();
