using LojaCamisas.Application.Mapping;
using LojaCamisas.Application.Interfaces;
using LojaCamisas.Application.Services;
using LojaCamisas.Domain.Interfaces;
using LojaCamisas.Infrastructure.Data;
using LojaCamisas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexão com o banco
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("LojaCamisas.Infrastructure")));

// Registrar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Registrar Mapster
MapsterConfig.RegisterMappings();

// Repositórios
builder.Services.AddScoped<ICamisaRepository, CamisaRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();

// Serviços de aplicação
builder.Services.AddScoped<ICamisaAppService, CamisaAppService>();
builder.Services.AddScoped<IMarcaAppService, MarcaAppService>();

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Aplicar migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
