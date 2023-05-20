using System;
using Domain;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace Security
{
    public class JWTAuthenticationService : IJWTAuthenticationService
    {
        IConfiguration _Configuration;

        public JWTAuthenticationService(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public JWTTokenDTO RefreshToken(string ExpiredToken)
        {
            var Identity = GetClaimsFromExpiredToken(ExpiredToken);
            if (Identity == null)
                return null;

            return new JWTTokenDTO
            {
                Token = GenerateToken(Identity.Name),
                RefreshToken = GenerateRefreshToken()
            };
        }

        public JWTTokenDTO GetToken(string UserName)
        {
            return new JWTTokenDTO
            {
                Token = GenerateToken(UserName),
                RefreshToken = GenerateRefreshToken()
            };
        }

        public string GetIdentity(string ExpiredToken)
        {
            var Identity = GetClaimsFromExpiredToken(ExpiredToken);
            if (Identity == null)
                return string.Empty;

            return Identity.Name;
        }

        private string GenerateToken(string ClaimIdentity)
        {
            var TokenKey = Encoding.UTF8.GetBytes(_Configuration.GetValue<string>("JWT:Key"));
            var TokenExpirationTimeInMinutes = _Configuration.GetValue<int>("JWT:ExpirationTimeInMinutes");

            return new JsonWebTokenHandler()
                .CreateToken(new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, ClaimIdentity)
                    }),
                    Expires = DateTime.Now.AddMinutes(TokenExpirationTimeInMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey), SecurityAlgorithms.HmacSha256Signature)
                });
        }

        private string GenerateRefreshToken()
        {
            var RandomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(RandomNumber);
                return Convert.ToBase64String(RandomNumber);
            }
        }

        private ClaimsIdentity GetClaimsFromExpiredToken(string JWTToken)
        {
            var Key = Encoding.UTF8.GetBytes(_Configuration.GetValue<string>("JWT:Key"));
            var ValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Key)
            };

            var TokenHandler = new JsonWebTokenHandler();
            var ValidationResult = TokenHandler.ValidateToken(JWTToken, ValidationParameters);
            if (!ValidationResult.IsValid)
                return null;

            return ValidationResult.ClaimsIdentity;
        }
    }
}
