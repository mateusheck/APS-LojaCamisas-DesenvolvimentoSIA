using LojaCamisas.Application.Mapping;
using LojaCamisas.Application.Interfaces;
using LojaCamisas.Application.Services;
using LojaCamisas.Domain.Interfaces;
using LojaCamisas.Infrastructure.Data;
using LojaCamisas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("LojaCamisas.Infrastructure")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

MapsterConfig.RegisterMappings();

builder.Services.AddScoped<ICamisaRepository, CamisaRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();

builder.Services.AddScoped<ICamisaAppService, CamisaAppService>();
builder.Services.AddScoped<IMarcaAppService, MarcaAppService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
