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
        public static string GetHashedPassword(string password, int iterationCount = 10000)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterationCount,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public static string GetToken(this IJokJaBreIdentityModel user, IConfiguration configuration) 
        {
            if (user != null)
            {
                var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username)
                };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: configuration["Jwt:Site"],
                  audience: configuration["Jwt:Site"],
                  expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
        }
    }
}
