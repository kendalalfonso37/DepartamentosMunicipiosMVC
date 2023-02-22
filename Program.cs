using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DepartamentosMunicipiosMVC.Data;
using DepartamentosMunicipiosMVC.Mappers;
using DepartamentosMunicipiosMVC.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add AutoMapperProfile
builder.Services.AddAutoMapper(typeof(Program));

// Inject Repositories in controllers
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
//builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();

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
