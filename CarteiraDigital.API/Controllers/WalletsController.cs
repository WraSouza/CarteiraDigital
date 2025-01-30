using CarteiraDigital.Application.Commands.AddBalance;
using CarteiraDigital.Application.Commands.UpdateWallet;
using CarteiraDigital.Application.Queries.GetBalanceById;
using CarteiraDigital.Application.Queries.InputModel;
using CarteiraDigital.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletsController(IMediator mediator, CarteiraDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddBalanceCommand command)
        {
            if (command.Value < 0)
            {
                return BadRequest("Valor Não Pode Ser Menos que 0");
            }

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("/consulta-saldo")]
        public async Task<IActionResult> GetById(GetBalanceUserInputModel model)
        {
            var balanceUser = new GetBalanceByIdQuery(model.IdBalance, model.IdUser);

            var balance = await mediator.Send(balanceUser);

            return Ok(balance);
        }

        [HttpPut("/adicionar-saldo")]
        public async Task<IActionResult> Update(UpdateWalletCommand model)
        { 
            if(model.IdUser <=0 || model.IdWallet <= 0)
            {
                return BadRequest("Id Inválido. Valor Informado Deve Ser Maior que 0");
            }

            var id = await mediator.Send(model);

            if(id == 0)
            {
                return NotFound("Usuário Não Encontrado");
            }

            return NoContent();
        }
    }
}
