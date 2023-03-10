using System.Security.Cryptography;
using System.Text;

namespace api_veiculos.Services;
public class HashService
{
    public static string Hash(string input)
    {
        using var sha1 = SHA1.Create();
        return Convert.ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(input)));
    }
}