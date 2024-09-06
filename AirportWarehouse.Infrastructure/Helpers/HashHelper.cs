using System.Security.Cryptography;

namespace AirportWarehouse.Infrastructure.Helpers
{
    public static class HashHelper
    {
        public static string Hash(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(
                password,
                16,
                10000,
                 HashAlgorithmName.SHA256
                );
            var key = Convert.ToBase64String(algorithm.GetBytes(32));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return $"{10000}.{salt}.{key}";
        }

    }
}
