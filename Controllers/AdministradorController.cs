
namespace api_veiculos.Controllers;

using api_veiculos.DTOs;
using api_veiculos.Filters;
using api_veiculos.Models;
using api_veiculos.Repositories.Interface;
using api_veiculos.Services;
using Microsoft.AspNetCore.Mvc;


[Route("register")]
[Logged]
public class AdministradorController : ControllerBase
{
    private IServicoAdm<Administrador> _servico;
    public AdministradorController(IServicoAdm<Administrador> servico)
    {
        _servico = servico;
    }

    // GET: Clientes
    [HttpGet("/register")]
    [Permission(Nivel ="adm,editor")]
    public async Task<IActionResult> Index()
    {
        var administradores = await _servico.TodosAsync();

        return StatusCode(200, administradores);
    }
    
    // Post: Administrador
    [HttpPost("/register")]
        [Permission(Nivel ="editor")]
    public async Task<IActionResult> Create([FromBody] AdministradorDTO administradorDTO)
    {
        var administrador = BuilderServico<Administrador>.Builder(administradorDTO);
        await _servico.IncluirAsync(administrador);
        return StatusCode(201, administrador);
    }
    
    // Put: Administrador
    [HttpPut("/register/{id}")]
    [Permission(Nivel ="editor")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Administrador administrador)
    {

        if(id != administrador.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do veículo precisa coincidir com o id passado pela url"});
        }
        
        await _servico.AtualizarAsync(administrador);
        return StatusCode(200, administrador);
    }
    
    // Delete: Administrador
    [HttpDelete("/register/{id}")]
    [Permission(Nivel ="editor")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var administrador = (await _servico.TodosAsync()).Find(v=>v.Id ==id);

        if(administrador is null)
        {
            return StatusCode(404, new {Mensagem = "O administrador informado não existe na base de dados"});
        }
        
        await _servico.ApagarAsync(administrador);
        return StatusCode(204);
    }

}