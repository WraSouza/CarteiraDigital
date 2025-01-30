using CarteiraDigital.Application.ViewModel;
using MediatR;

namespace CarteiraDigital.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
       
    }
}
