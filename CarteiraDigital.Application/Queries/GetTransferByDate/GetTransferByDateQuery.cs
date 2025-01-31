using CarteiraDigital.Application.ViewModel;
using MediatR;

namespace CarteiraDigital.Application.Queries.GetTransferByDate
{
    public class GetTransferByDateQuery : IRequest<List<TransferViewModel>>
    {
        public GetTransferByDateQuery(int id, DateTime initialDate, DateTime finalDate)
        {
            Id = id;
            InitialDate = initialDate;
            FinalDate = finalDate;
        }

        public int Id { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}
