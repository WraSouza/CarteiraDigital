using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Repositories;
using CarteiraDigital.Infrastructure.Persistence;
using MediatR;

namespace CarteiraDigital.Application.Commands.UpdateWallet
{
    public class UpdateWalletCommandHandler(IWalletRepository repository, Wallet wallet, CarteiraDbContext context) : IRequestHandler<UpdateWalletCommand, int>
    {
        public async Task<int> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var wallets = await repository.GetWalletByIdAsync(request.IdWallet, request.IdUser);

                if (wallets != null)
                {
                    wallets.UpdateWallet(request.Value);                    

                    repository.UpdateWalletAsync(wallets);                                      
                }

                return wallets.Id;
            }
            catch (Exception ex)
            {

            }

            return 0;

        }
    }
}
