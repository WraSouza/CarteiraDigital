using CarteiraDigital.Application.ViewModel;
using CarteiraDigital.Domain.Repositories;
using MediatR;

namespace CarteiraDigital.Application.Queries.GetTransferByDate
{
    public class GetTransferByDateQueryHandler(ITransferRepository repository) : IRequestHandler<GetTransferByDateQuery, List<TransferViewModel>>
    {
        public async Task<List<TransferViewModel>> Handle(GetTransferByDateQuery request, CancellationToken cancellationToken)
        {
            List<TransferViewModel> allTransfers = [];
            
            var transfers = await repository.GetTransferByIdUserAndDate(request.Id, request.InitialDate, request.FinalDate);

            foreach (var transfer in transfers)
            {
                var newTransfer = new TransferViewModel(transfer.IdFinalUser, transfer.IdWalletFinalUser, transfer.Value, transfer.CreatedAt);

                allTransfers.Add(newTransfer);
            }

            return allTransfers;
        }
    }
}
