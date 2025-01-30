using CarteiraDigital.Application.ViewModel;
using CarteiraDigital.Domain.Repositories;
using CarteiraDigital.Infrastructure.Auth;
using MediatR;

namespace CarteiraDigital.Application.Commands.Login
{
    public class LoginCommandHandler(IAuthService authService, IUserRepository userRepository) : IRequestHandler<LoginCommand, LoginViewModel>
    {
        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var hash = authService.ComputeHash(request.Password);

            var users = await userRepository.GetAllUsersAsync();

            var userSelected = users.SingleOrDefault(s => s.UserName == request.UserName && s.Password == hash);

            if (userSelected != null)
            {
                var token = authService.GenerateToken(request.UserName);

                LoginViewModel viewModel = new LoginViewModel(token);

                return viewModel;
            }

            return new LoginViewModel();
        }
    }
}
