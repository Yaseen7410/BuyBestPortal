using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IApplicationDbContext _context;
        private readonly JwtSettings _appsetting;
        private readonly IMapper _mapper;
        public CurrentUserService(IApplicationDbContext context, IOptions<JwtSettings> appSetting, IMapper mapper)
        {
            _context = context;
            _appsetting = appSetting.Value;
            _mapper = mapper;
        }

        public string UserId => throw new NotImplementedException();

        public bool IsUniqueUser(string UserName)
        {
            var User = _context.Set<RegisterNew>().FirstOrDefault(r => r.Email == UserName);
            if (User == null)
                return true;
            else
                return false;
        }
        public RegisterNew login(string UserName, string UserPassword)
        {
            var UserIndb = _context.Set<Domain.Entities.RegisterNew>().FirstOrDefault(r => r.Email == UserName && r.Password == UserPassword);
            if (UserIndb == null) return null;
            //Jwt Token
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_appsetting.Key);
            var TokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(ClaimTypes.Email, UserIndb.Email.ToString()),
                   
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescritor);
            UserIndb.Token = TokenHandler.WriteToken(Token);
            return UserIndb;
        }
    }
}