using Metadados.Data;
using Metadados.Models;
using Metadados.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MetadadosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MetadadosContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Objeto_Service>();
builder.Services.AddScoped<Objeto_configuracao_Service>();
builder.Services.AddScoped<Objeto_localizacao_Services>();
builder.Services.AddScoped<Objeto_tipo_Services>();
builder.Services.AddScoped<Localizacao_tipo_Services>();
builder.Services.AddScoped<Mapeamento_Services>();
builder.Services.AddScoped<Pipeline_Services>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
