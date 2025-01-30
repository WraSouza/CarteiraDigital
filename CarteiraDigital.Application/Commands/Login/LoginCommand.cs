using CarteiraDigital.Application.ViewModel;
using MediatR;

namespace CarteiraDigital.Application.Commands.Login
{
    public class LoginCommand : IRequest<LoginViewModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
