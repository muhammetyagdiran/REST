using REST.Entities.DTOs.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace REST.Business.Security
{
    public class JwtAuthManager : IJwtAuthService
    {
        public JwtToken GenerateToken(UserLoginRequestDTO userLoginRequestDTO, IConfiguration configuration)
        {
            JwtToken token = new();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(configuration["JwtSettings:SecurityKey"]));

            SigningCredentials credentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddMinutes(Convert.ToInt16(configuration
                ["JwtSettings:Expiration"]));

            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Name,userLoginRequestDTO.UserName)
            };
       
            JwtSecurityToken jwtSecurityToken = new(
                claims: claims,
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                expires: token.Expiration,
                signingCredentials: credentials
                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            token.RefreshToken = Convert.ToBase64String(number);

            return token;
        }
    }
}

