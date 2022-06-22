using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesPhoneBook.Data;
using RazorPagesPhoneBook.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RazorPagesPhoneBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesPhoneBookContext")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
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

app.UseAuthorization();

app.MapRazorPages();
//var defaultCulture = new CultureInfo("es-UY");
//var localizationOptions = new RequestLocalizationOptions
//{
//    DefaultRequestCulture = new RequestCulture(defaultCulture),
//    SupportedCultures = new List<CultureInfo> { defaultCulture },
//    SupportedUICultures = new List<CultureInfo> { defaultCulture }
//};
//app.UseRequestLocalization(localizationOptions);

app.Run();
