using CarteiraDigital.Application.ViewModel;
using CarteiraDigital.Domain.Repositories;
using MediatR;

namespace CarteiraDigital.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUserRepository repository) : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<UserViewModel> users = [];

            var allUsers = await repository.GetAllUsersAsync();

            foreach(var user in allUsers)
            {
                UserViewModel viewModel = new(user.Id, user.FullName, user.CreatedAt);

                users.Add(viewModel);
            }

            return users;
        }
    }
}
