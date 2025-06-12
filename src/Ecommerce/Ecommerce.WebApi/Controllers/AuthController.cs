using Ecommerce.Abstractions.Messaging;
using Ecommerce.Contracts.Auth.Commands.SignIn;
using Ecommerce.Contracts.Auth.Commands.SignUp;
using Ecommerce.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        public AuthController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            if (request == null)
            {
                //alguna validación mas...
                return BadRequest("request fue nulo");
            }

            var command = new SignUpCommand(request.Email, request.Password);
            var userId = await _commandDispatcher.DispatchAsync<SignUpCommand, Guid>(command);

            return Ok(userId);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            if (request == null)
            {
                //alguna validación mas...
                return BadRequest("request fue nulo");
            }
            var command = new SignInCommand(request.Email, request.Password);
            var response = await _commandDispatcher.DispatchAsync<SignInCommand, SignInResponse>(command);
            return Ok(response);

        }
    }
}
