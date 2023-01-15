namespace api_veiculos.DTOs;

public record VeiculoDTO
{
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public string Marca {get;set;} = default!;
    public string Modelo {get;set;} = default!;
    public int Ano {get;set;} = default!;
}