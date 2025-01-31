using CarteiraDigital.Application.Commands.AddTransfer;
using CarteiraDigital.Application.InputModel;
using CarteiraDigital.Application.Queries.GetTransferByDate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddTransferCommand command)
        {
            if (command is null)
            {
                return BadRequest("É Necessário informar todos os campos");
            }
            var id = await mediator.Send(command);

            return Ok(id);
        }

        [HttpPost("/busca-transferencias-por-data")]
        public async Task<IActionResult> GetTransferByIdAndDate(int id,[FromBody]TransferByDateInputModel model)
        {
            if(model is null)
            {
                return BadRequest();
            }

            var transfers = new GetTransferByDateQuery(id, model.InitialDate, model.FinalDate);

            var allTransfers = await mediator.Send(transfers);

            return Ok(allTransfers);
        }
    }
}
