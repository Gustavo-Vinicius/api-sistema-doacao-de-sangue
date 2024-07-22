using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Commands.Users.AddUser;

namespace Sistema_de_Doacao_de_Sangue.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="command">The command containing user details.</param>
        /// <returns>Returns an Ok result if the user is added successfully.</returns>
        [HttpPost("add-new-user")]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}