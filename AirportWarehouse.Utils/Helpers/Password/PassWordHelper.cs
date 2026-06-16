using AirportWarehouse.Core.ConfigOptions;
using AirportWarehouse.Core.Exceptions;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace AirportWarehouse.Utils.Helpers.Password;

public class PassWordHelper : IPassWordHelper
{
    public PassWordHelper(IOptions<PasswordOptions> options)
    {
        _options = options.Value;
    }
    private readonly PasswordOptions _options;


    public string HashPassword(string plaintText)
    {
        using var algorithm = new Rfc2898DeriveBytes(
               plaintText,
               _options.SaltSize,
               _options.Iterations,
                HashAlgorithmName.SHA256
               );
        var key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return $"{_options.Iterations}.{salt}.{key}";
    }

    public void Check(string hash, string password)
    {
        var parts = hash.Split('.');
        if (parts.Length != 3)
        {
            throw new FormatException("Unexpected hash format");
        }

        var iterations = Convert.ToInt32(parts[0])!;
        var salt = Convert.FromBase64String(parts[1])!;
        var key = Convert.FromBase64String(parts[2])!;

        using var algorithm = new Rfc2898DeriveBytes(
            password,
            salt,
            iterations,
            HashAlgorithmName.SHA256);
        var keyToCheck = algorithm.GetBytes(key.Length);


        if (!keyToCheck.SequenceEqual(key))
            throw new CredentialsException("Check your credentials");
    }
}
