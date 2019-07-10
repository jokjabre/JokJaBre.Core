using JokJaBre.Core.Auth.Objects;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JokJaBre.Core.Auth.Identity
{
    public static class JokJaBreIdentity
    {
        public static string HashPassword(this IJokJaBreIdentityModel user, IConfiguration configuration, int iterationCount = 10000)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = Encoding.Unicode.GetBytes(configuration["JokJaBre:Salt"]);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: user.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: iterationCount,
                    numBytesRequested: 256 / 8));

            user.Password = hashed;

            return hashed;
        }

        public static string GetToken(this IJokJaBreIdentityModel user, IConfiguration configuration)
        {
            if (user == null) return null;

            var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username)
                };
            var signinKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(configuration["JokJaBre:Auth:SigningKey"]));

            int expiryInMinutes = Convert.ToInt32(configuration["JokJaBre:Auth:ExpiresIn"]);

            var token = new JwtSecurityToken(
              claims: claim,
              issuer: configuration["JokJaBre:Auth:Site"],
              audience: configuration["JokJaBre:Auth:Site"],
              expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
              signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
