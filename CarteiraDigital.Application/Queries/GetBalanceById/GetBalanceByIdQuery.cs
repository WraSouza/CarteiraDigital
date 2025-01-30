using CarteiraDigital.Application.ViewModel;
using MediatR;

namespace CarteiraDigital.Application.Queries.GetBalanceById
{
    public class GetBalanceByIdQuery : IRequest<BalanceViewModel>
    {
        public GetBalanceByIdQuery(int id, int idUser)
        {
            Id = id;
            IdUser = idUser;
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
    }
}
