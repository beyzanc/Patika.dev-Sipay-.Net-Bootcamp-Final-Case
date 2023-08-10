using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ResiPay.DB;
using ResiPay.DB.Entities;
using ResiPay.Model.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ResiPay.Service.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ResiPayDbContext _dbContext;

        public TokenService(IConfiguration configuration, ResiPayDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public TokenResponseModel GenerateToken(TokenRequestModel request)
        {
            var user = _dbContext.User.SingleOrDefault(u => u.Email == request.Email && u.Password == request.Password);

            if (user == null)
            {
                return new TokenResponseModel
                {
                    Message = "Invalid email or password.",
                    IsSuccess = false,
                    
                };

            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Status),
                new Claim(ClaimTypes.NameIdentifier, user.IdentityNumber),
                new Claim(ClaimTypes.Email, user.Email)

            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var options = new JwtSecurityToken (

                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signingCredentials

            );

            var token = new JwtSecurityTokenHandler().WriteToken(options);

            var newToken = new TokenEntity
            {
                UserId = user.Id,
                TokenCreated = token,
                ExpireDate = options.ValidTo

            };

            _dbContext.SaveChanges();

            return new TokenResponseModel
            {
                AccessToken = token,
                IsSuccess = true,
                Message = "Token is shared."
            };
        }
    }
}
