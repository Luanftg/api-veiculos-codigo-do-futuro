
using api_veiculos.Repositories.Interface;

namespace api_veiculos.Repositories.Interface;

public interface IServicoAdm<T> : IServico<T>
{
    Task<T?> Login(string email, string senha);
}