using Microsoft.IdentityModel.Tokens;
using System.Text;

public class AuthOptions
{
    private string? issuer = "AparshukovAspCore"; // издатель токена
    private string? audience = "AparshukovVue"; // потребитель токена

    private string? _securityKey;

    public string? Issuer { get => issuer; private set => issuer = value; }
    public string? Audience { get => audience; private set => audience = value; }

    public AuthOptions(IConfiguration configuration)
    {
        _securityKey = configuration.GetSection("SecurityKey").Value;
        Issuer = configuration.GetSection("Issuer").Value;
        Audience = configuration.GetSection("Audience").Value;
    }

    public SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
}
