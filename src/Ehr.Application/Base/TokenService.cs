using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ehr.Contracts.Base;
using Ehr.Core.ExtendMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ehr.Application.Base
{
    public class TokenService: ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<string> CreateToken(string account, string[] roles)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim (ClaimTypes.Name, account),
                new Claim ("UserId", account),
            };

            if (roles != null)
            {
                for (int i = 0; i < roles.Length; i++)
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles[i]));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                         audience: _configuration["Auth:Audience"],
                         issuer: _configuration["Auth:ValidIssuer"],
                         claims: claims,
                         signingCredentials: creds,
                         expires: DateTime.Now.AddMinutes(_configuration["Auth:ExpireTime"].ToDouble())
                     );
            await Task.Yield();
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}