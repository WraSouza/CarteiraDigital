using CarteiraDigital.Domain.Entities;

namespace CarteiraDigital.Application.ViewModel
{
    public class BalanceViewModel
    {
        public BalanceViewModel(int idUser, string user, decimal value)
        {
            IdUser = idUser;
            User = user;
            Value = value;
        }

        public int IdUser { get; private set; }
        public string User { get; private set; }
        public decimal Value { get; private set; }
    }
}
