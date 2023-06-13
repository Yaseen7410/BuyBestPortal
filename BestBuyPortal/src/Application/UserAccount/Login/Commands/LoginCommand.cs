using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserAccount.Login.Commands
{
    public  class LoginCommand:LoginDTO,IRequest<Result>
    {
       public class LoginCommandHandler:IRequestHandler<LoginCommand,Result>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            private ICurrentUserService _currentUserService;
            public LoginCommandHandler(IApplicationDbContext context,IMapper mapper,ICurrentUserService currentUserService)
            {
                _context = context;
                _mapper = mapper;
                _currentUserService = currentUserService;
            }

            public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                try
                {
                     var logindetails = await _context.Set<Domain.Entities.RegisterNew>().FirstOrDefaultAsync(x => x.Name == request.Name);
                    if (logindetails != null)
                    {
                        if (logindetails.Password == request.Password)
                        {
                            var jwtToken = _currentUserService.login(logindetails.Email,logindetails.Password);
                            var res = new
                            {
                                message = "User Login Successfully",
                                token = jwtToken
                            };
                            return Result.Success(res);
                        
                            
                        }
                        else
                        {
                            return Result.Failure(new string[] { "Invalid  Password" });
                        }
                    }
                    else
                    {
                        return Result.Failure(new string[] { "Invalid Email or Password" });
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

    }
}
