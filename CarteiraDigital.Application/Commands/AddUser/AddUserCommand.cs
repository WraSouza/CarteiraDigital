using MediatR;

namespace CarteiraDigital.Application.Commands.AddUser
{
    public class AddUserCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
