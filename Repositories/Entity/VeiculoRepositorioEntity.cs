

using api_veiculos.Models;
using api_veiculos.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace api_veiculos.Repositories.Entity;

public class VeiculoRepositorioEntity : IServico<Veiculo>
{
    private ContextoEntity contexto;
    public VeiculoRepositorioEntity()
    {
        contexto = new ContextoEntity();
    }

    public async Task<List<Veiculo>> TodosAsync()
    {
        return await contexto.Veiculos.ToListAsync();
    }

    public async Task IncluirAsync(Veiculo veiculo)
    {
        contexto.Veiculos.Add(veiculo);
        await contexto.SaveChangesAsync();
    }

    public async Task<Veiculo> AtualizarAsync(Veiculo veiculo)
    {
        contexto.Entry(veiculo).State = EntityState.Modified;
        await contexto.SaveChangesAsync();

        return veiculo;
    }

    public async Task ApagarAsync(Veiculo veiculo)
    {
        var obj = await contexto.Veiculos.FindAsync(veiculo.Id);
        if(obj is null) throw new Exception("Veiculo não encontrado");
        contexto.Veiculos.Remove(obj);
        await contexto.SaveChangesAsync();
    }
}