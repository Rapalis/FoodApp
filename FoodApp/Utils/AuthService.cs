using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FoodApp.Models;
using FoodApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FoodApp.Utils
{
    public class AuthService : IAuthService
    {
        public readonly IUserService _userManngager;
        public readonly SymmetricSecurityKey _authSignKey;
        public readonly string _authIssuer;
        public readonly string _authClient;


        public AuthService(IConfiguration configuration, IUserService userManngager)
        {
            _userManngager = userManngager;
            _authSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            _authIssuer = configuration["JWT:ValidIssuer"];
            _authClient = configuration["JWT:ValidAudience"];
        }

        public async Task<string> CreateAccessTokenAsync(User user)
        {
            var userRole = await _userManngager.GetRoleAsync(user.Id);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, userRole)

            };
            // authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            var accessSecurityToken = new JwtSecurityToken
            (
                issuer: _authIssuer,
                audience: _authClient,
                expires: DateTime.UtcNow.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(_authSignKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(accessSecurityToken);
        }

    }
}
