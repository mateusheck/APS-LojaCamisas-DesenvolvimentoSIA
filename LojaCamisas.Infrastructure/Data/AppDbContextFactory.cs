using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LojaCamisas.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Define o caminho base como a localização do projeto Web (o projeto de startup).
            // Isso é mais robusto para o EF Core Tool.
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "LojaCamisas.Web");

            // Se o Scaffolding estiver sendo executado, o CurrentDirectory pode ser o projeto Infra.
            // O caminho ".." volta para a pasta da solução e depois entra no projeto Web.

            // 1. Constrói a configuração
            var configuration = new ConfigurationBuilder()
                // Define o caminho de onde buscar o appsettings.json
                .SetBasePath(basePath)
                // Adiciona o arquivo appsettings.json
                .AddJsonFile("appsettings.json", optional: false)
                // .Build() DEVE ser a última chamada na cadeia de ConfigurationBuilder
                .Build();

            // 2. Obtém a string de conexão
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 3. Cria o DbContextOptions
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(connectionString);

            // 4. Retorna a instância
            return new AppDbContext(builder.Options);
        }
    }
}