
using api_veiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace api_veiculos.Repositories.Entity;

public class ContextoEntity : DbContext
{

    public ContextoEntity() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_CDF");
        if(conexao == null) conexao = "Server=localhost;Database=api_veiculo;Uid=root;Pwd=Luan_17101988;";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
    }

    public DbSet<Veiculo> Veiculos { get; set; } = default!;
    public DbSet<Administrador> Administradores { get; set; } = default!;
} 
