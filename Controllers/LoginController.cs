
namespace api_veiculos.Controllers;

using api_veiculos.DTOs;
using api_veiculos.Models;
using api_veiculos.ModelView;
using api_veiculos.Repositories.Interface;
using api_veiculos.Services.Autenticacao;
using Microsoft.AspNetCore.Mvc;

public class LoginController : ControllerBase
{
    private IServicoAdm<Administrador> _servico;
    public LoginController(IServicoAdm<Administrador> servico)
    {
        _servico = servico;
    }
    // GET: Clientes
    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody]AdministradorDTO administradorDTO)
    {
        if(string.IsNullOrEmpty(administradorDTO.Email) || string.IsNullOrEmpty(administradorDTO.Senha))
            return StatusCode(400, new {
                Mensagem = "Preencha o email e a senha"
            });

        var administrador = await _servico.Login(administradorDTO.Email, administradorDTO.Senha);
        if(administrador is null)
            return StatusCode(404, new {
                Mensagem = "Usuario ou senha não encontrado em nossa base de dados"
            });

        var administradorLogado = Services.BuilderServico<AdministradorLogado>.Builder(administrador);
        administradorLogado.Token = TokenJWT.Builder(administradorLogado);

        return StatusCode(200, administradorLogado);
    }

}