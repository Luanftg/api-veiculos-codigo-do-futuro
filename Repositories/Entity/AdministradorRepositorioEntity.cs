

using api_veiculos.Models;
using api_veiculos.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_veiculos.Repositories.Entity;

public class AdministradorRepositorioEntity : IServicoAdm<Administrador>
{
    private ContextoEntity contexto;
    public AdministradorRepositorioEntity()
    {
        contexto = new ContextoEntity();
    }

    //private string? conexao = null;

    public async Task<List<Administrador>> TodosAsync()
    {
        return await contexto.Administradores.ToListAsync();
    }

    public async Task<Administrador?> Login(string email, string senha)
    {
        return await contexto.Administradores.Where(a => a.Email == email && a.Senha == senha).FirstOrDefaultAsync();
    }

    public async Task IncluirAsync(Administrador administrador)
    {
        contexto.Administradores.Add(administrador);
        await contexto.SaveChangesAsync();
    }

    public async Task<Administrador> AtualizarAsync(Administrador administrador)
    {
        contexto.Entry(administrador).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return administrador;
    }

    public async Task ApagarAsync(Administrador administrador)
    {
        var obj = await contexto.Administradores.FindAsync(administrador.Id);
        if(obj is null) throw new Exception("Administrador não encontrado");
        contexto.Administradores.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}