using MediatR;

namespace CarteiraDigital.Application.Commands.AddBalance
{
    public class AddBalanceCommand : IRequest<int>
    {
        public int IdUser { get; set; }
        public decimal Value { get; set; }
    }
}
