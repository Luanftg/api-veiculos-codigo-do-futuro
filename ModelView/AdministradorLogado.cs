namespace api_veiculos.ModelView;

public record AdministradorLogado
{
    public int Id { get;set; } = default!;
    public string Nome { get;set; } = default!;
    public string Email { get;set; } = default!;
    public string Regra { get;set; } = default!;
    public string Token { get;set; } = default!;
}