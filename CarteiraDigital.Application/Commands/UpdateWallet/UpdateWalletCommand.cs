using MediatR;

namespace CarteiraDigital.Application.Commands.UpdateWallet
{
    public class UpdateWalletCommand : IRequest<int>
    {
        public int IdWallet { get; set; }
        public int IdUser { get; set; }
        public decimal Value { get; set; }
    }
}
