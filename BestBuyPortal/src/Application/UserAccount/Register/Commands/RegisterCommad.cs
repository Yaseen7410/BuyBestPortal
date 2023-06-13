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

namespace Application.UserAccount.Register.Commands
{
   public class RegisterCommad :RegisterDTO, IRequest<Result>
    {
    }
public class RegisterCommandHandler : IRequestHandler<RegisterCommad, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
   

    public RegisterCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        
    }

        public async Task<Result> Handle(RegisterCommad request, CancellationToken cancellationToken)
        {
        try
        {
            var regs = new Domain.Entities.RegisterNew();
           
            var emailmessage = "Email Exists";
                var log = await _context.Set<Domain.Entities.RegisterNew>().FirstOrDefaultAsync(x => x.Email == request.Email);
                if (log == null)
                {
                    regs.Name = request.Name;
                    regs.Address = request.Address;
                    regs.Email = request.Email;
                    
                    regs.Password =request.Password;
                    regs.CreatedBy = request.Name;
                    _context.Set<Domain.Entities.RegisterNew>().AddRange(regs);
                    await _context.SaveChangesAsync(cancellationToken);
                    return Result.Success(new string[] { "Record SuccessFully Saved" });

                }
                else
                {
                    return Result.Failure(new string[] { emailmessage });
                }
        }
        catch (Exception eg)
        {
            return Result.Failure(new string[] { eg.Message });
        }
    }

    }

}
