using CarteiraDigital.Application.ViewModel;
using CarteiraDigital.Domain.Repositories;
using MediatR;

namespace CarteiraDigital.Application.Queries.GetBalanceById
{
    public class GetBalanceByIdQueryHandler(IWalletRepository repository) : IRequestHandler<GetBalanceByIdQuery, BalanceViewModel>
    {
        public async Task<BalanceViewModel> Handle(GetBalanceByIdQuery request, CancellationToken cancellationToken)
        {
            var balance = await repository.GetWalletByIdAsync(request.Id, request.IdUser);

            var balanceUser = new BalanceViewModel(balance.IdUser, balance.User.FullName, balance.Value);

            return balanceUser;
        }
    }
}
