using CarteiraDigital.Application.ViewModel;
using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Repositories;
using MediatR;

namespace CarteiraDigital.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await repository.GetUserByIdAsync(request.Id);

            var requestedUser = new UserViewModel(user.Id, user.FullName, user.CreatedAt);

            return requestedUser;
                                
        }
    }
}
