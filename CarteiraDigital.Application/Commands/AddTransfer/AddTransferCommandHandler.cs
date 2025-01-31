using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Repositories;
using MediatR;

namespace CarteiraDigital.Application.Commands.AddTransfer
{
    public class AddTransferCommandHandler(ITransferRepository repository, IWalletRepository walletRepository) : IRequestHandler<AddTransferCommand, int>
    {
        public async Task<int> Handle(AddTransferCommand request, CancellationToken cancellationToken)
        {
            var walletUser = await walletRepository.GetWalletByIdAsync(request.IdWallet, request.IdUser);
            
            walletUser.SubtractWallet(request.Value);

            walletRepository.UpdateWalletAsync(walletUser);

            var finalUser = await walletRepository.GetWalletByIdAsync(request.IdWalletFinalUser, request.IdFinalUser);

            finalUser.UpdateWallet(request.Value);

            walletRepository.UpdateWalletAsync(finalUser);

            var newTransfer = new Transfer(request.IdWallet,request.IdUser,request.IdWalletFinalUser, request.IdFinalUser, request.Value);            
            
            var id = await repository.AddTransferAsync(newTransfer);

            return id;
            
        }
    }
}
