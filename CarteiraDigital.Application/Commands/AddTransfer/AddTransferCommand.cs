using CarteiraDigital.Domain.Entities;
using MediatR;

namespace CarteiraDigital.Application.Commands.AddTransfer
{
    public class AddTransferCommand : IRequest<int>
    {
        public int IdWallet { get; set; }
        public int IdUser { get; set; }        
        public decimal Value { get; set; }
        public int IdWalletFinalUser { get; set; }
        public int IdFinalUser { get;  set; }
       
       
    }
}
