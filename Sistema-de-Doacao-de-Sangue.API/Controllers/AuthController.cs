using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Commands.Users.AuthUser;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces.Services;

namespace Sistema_de_Doacao_de_Sangue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Authenticates the user and generates a JWT token.
        /// </summary>
        /// <param name="command">The authentication command containing user credentials.</param>
        /// <returns>Returns an Ok result with the generated JWT token.</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthUserCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}