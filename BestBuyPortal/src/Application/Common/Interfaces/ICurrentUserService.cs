using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsUniqueUser(string UserName);
        RegisterNew login(string UserName, string UserPassword);
    }
}
