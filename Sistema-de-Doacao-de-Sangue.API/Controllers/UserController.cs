using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Doacao_de_Sangue.Application.Commands.Users.AddUser;
using Sistema_de_Doacao_de_Sangue.Application.Queries.Users.GetUserByEmail;

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
        [AllowAnonymous]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Retrieves the complete name of a user by their email.
        /// </summary>
        /// <param name="query">The query containing the user's email.</param>
        /// <returns>Returns an Ok result with the complete name of the user if found.</returns>
        [HttpGet("get-complet-name-by-email")]
        public async Task<IActionResult> GetCompletNameByEmailAsync([FromQuery] GetUserByEmailQuery query)
        {
            var completName = await _mediator.Send(query);
            return Ok(completName);
        }
    }
}