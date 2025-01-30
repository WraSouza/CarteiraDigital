using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Repositories;
using MediatR;

namespace CarteiraDigital.Application.Commands.AddBalance
{
    public class AddBalanceCommandHandler(IWalletRepository repository) : IRequestHandler<AddBalanceCommand, int>
    {
        public async Task<int> Handle(AddBalanceCommand request, CancellationToken cancellationToken)
        {
            var balance = new Wallet(request.IdUser, request.Value);

            var id = await repository.AddWalletAsync(balance);

            return id;
        }
    }
}
