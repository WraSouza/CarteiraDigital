using CarteiraDigital.Application.Commands.AddUser;
using CarteiraDigital.Application.Commands.Login;
using CarteiraDigital.Application.Queries.GetAllUsers;
using CarteiraDigital.Application.Queries.GetUserById;
using CarteiraDigital.Infrastructure.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CarteiraDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator, IMemoryCache cache, IAuthService authService) : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(AddUserCommand command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var allUsers = new GetAllUsersQuery();

            var users = await mediator.Send(allUsers);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Precisa Conter um Número Maior que 0");
            }

            var userById = new GetUserByIdQuery(id);

            var user = await mediator.Send(userById);

            return Ok(user);
        }

        [HttpPut("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand model)
        {
            var token = await mediator.Send(model);

            return Ok(token);
        }
    }
}
