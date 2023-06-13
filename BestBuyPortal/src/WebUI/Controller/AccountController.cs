using Application.Common.Models;
using Application.UserAccount.Login.Commands;
using Application.UserAccount.Register.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiBaseController
    {
        [HttpPost("[action]")]
        public async Task<ActionResult<Result>> registerRequest(RegisterCommad command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Result>> loginRequest(LoginCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
