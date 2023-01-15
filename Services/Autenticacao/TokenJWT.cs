
using api_veiculos.DTOs;
using api_veiculos.ModelView;
using Jose;

namespace api_veiculos.Services.Autenticacao;

public class TokenJWT
{
    public static string Builder(AdministradorLogado AdministradorLogado)
    {
        var key = "SEGREDO_do_CoDigoDO-Futuro";

        var payload = new AdministradorJwtDTO
        {
           Id = AdministradorLogado.Id,
           Email = AdministradorLogado.Email,
           Regra = AdministradorLogado.Regra,
           Expiracao = DateTime.Now.AddDays(2)
        };

        string token = Jose.JWT.Encode(payload, key, JwsAlgorithm.none);

        return token;
    }

}