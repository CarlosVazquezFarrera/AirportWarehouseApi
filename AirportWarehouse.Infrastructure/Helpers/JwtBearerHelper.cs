using AirportWarehouse.Infrastructure.Configuration;
using AirportWarehouse.Infrastructure.Interfaces;
using AirportWarehouse.Infrastructure.Service;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AirportWarehouse.Infrastructure.Helpers
{
    public class JwtBearerHelper : IJwtBearer
    {
        public JwtBearerHelper(IOptions<JwtSettings> jwtSetting, ConfigSettings settings)
        {
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));
            _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);;
            _jwtHeader = new JwtHeader(_signingCredentials);
            _jwtSetting = jwtSetting;
        }
        private readonly IOptions<JwtSettings> _jwtSetting;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;

        public string GetJwtToken(string Name, string Email, Guid Id, Guid AirportId)
        {

            var claims = new List<Claim>() 
            {
                new(ClaimTypes.Name, Name),
                new(ClaimTypes.Email, Email),
                new(ClaimTypes.NameIdentifier, Id.ToString()),
                new("AirportId", AirportId.ToString())
            };
            var payload = new JwtPayload (_jwtSetting.Value.Issuer, _jwtSetting.Value.Audience, claims, DateTime.Now, DateTime.UtcNow.AddHours(12));
            var token = new JwtSecurityToken(_jwtHeader, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
