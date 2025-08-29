using Microsoft.EntityFrameworkCore;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Aplicacion.Servicios;
using Proyecto.Dominio.Interfaces;
using Proyecto.Infraestructura.Data;
using Proyecto.Infraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

    // Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// AutoMapper Service 

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Dependency Injection para servicios 
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<IInformacionEmpresaService, InformacionEmpresaService>();
// Dependency Injection para repositorios
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<ILibrosRepositorio, LibrosRepositorio>();
builder.Services.AddScoped<IInformacionEmpresaRepositorio, InformacionEmpresaRepositorio>();

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
    pattern: "{area=Dashboard}/{controller=Home}/{action=Index}/{id?}");

app.Run();
