using Jose;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AutoRepairShop.Api.Authentication
{
    public static class Auth
    {
        public static string key = "9A4ACF46281667CA7A5967A5A6EE2906F0CDFBB80D29C38A19BE7CE02023C81D";
        private static byte[] KeyBytes => Encoding.UTF8.GetBytes(key);
        private const JwsAlgorithm algorithm = JwsAlgorithm.HS256;

        public static string EncodeToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyBytes), SecurityAlgorithms.HmacSha256Signature),
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
        public static string Encode(string password)
        {
            return JWT.Encode(password, KeyBytes, algorithm);
        }
    }
}