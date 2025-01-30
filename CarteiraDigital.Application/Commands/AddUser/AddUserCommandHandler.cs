using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Repositories;
using CarteiraDigital.Infrastructure.Auth;
using MediatR;

namespace CarteiraDigital.Application.Commands.AddUser
{
    public class AddUserCommandHandler(IUserRepository userRepository, IAuthService authService) : IRequestHandler<AddUserCommand, int>
    {
        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var hash = authService.ComputeHash(request.Password);

            var user = new User(request.FullName, request.UserName, hash);

            var id = await userRepository.AddUserAsync(user);

            return id;
        }
    }
}
