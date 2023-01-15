
namespace api_veiculos.Controllers;

using api_veiculos.Filters;
using api_veiculos.Models;

using api_veiculos.Repositories.Interface;

using Microsoft.AspNetCore.Mvc;

public class HomeController : ControllerBase
{
    private IServicoAdm<Administrador> _servico;
    public HomeController(IServicoAdm<Administrador> servico)
    {
        _servico = servico;
    }

    // GET: Clientes
    [Logged]
    [HttpGet("/")]
    public IActionResult Index()
    {
        return StatusCode(200, new Home{Message = "Bem vindo a área restrita"});
    }
}