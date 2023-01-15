using api_veiculos.DTOs;
using api_veiculos.Filters;
using api_veiculos.Models;
using api_veiculos.Repositories.Interface;
using api_veiculos.Services;
using Microsoft.AspNetCore.Mvc;

public class VeiculoController : ControllerBase
{
    private IServico<Veiculo> _servico;
    public VeiculoController(IServico<Veiculo> servico)
    {
        _servico = servico;
    }
    // GET: Veiculos
    [Logged]
    [HttpGet("/veiculos")]
    public async Task<IActionResult> Index()
    {
        var veiculo = await _servico.TodosAsync();
        return StatusCode(200, veiculo);
    }

     [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var veiculo = (await _servico.TodosAsync()).Find(c => c.Id == id);
        return StatusCode(200, veiculo);
    }
    
    
    // Post: Veiculos
    [Logged]
    [HttpPost("/veiculos")]
    public async Task<IActionResult> Create([FromBody] VeiculoDTO veiculoDTO)
    {
        var veiculo = BuilderServico<Veiculo>.Builder(veiculoDTO);
        await _servico.IncluirAsync(veiculo);
        return StatusCode(201, veiculo);
    }
    
    // Put: Veiculos
    [Logged]
    [HttpPut("/veiculos/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Veiculo veiculo)
    {

        if(id != veiculo.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do veículo precisa coincidir com o id passado pela url"});
        }
        
        await _servico.AtualizarAsync(veiculo);
        return StatusCode(200, veiculo);
    }
    
    // Delete: Veiculos
    [Logged]
    [HttpDelete("/veiculos/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var veiculo = (await _servico.TodosAsync()).Find(v=>v.Id ==id);

        if(veiculo is null)
        {
            return StatusCode(404, new {Mensagem = "O veiculo informado não existe na base de dados"});
        }
        
        await _servico.ApagarAsync(veiculo);
        return StatusCode(204);
    }
}