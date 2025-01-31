using CarteiraDigital.Domain.Entities;

namespace CarteiraDigital.Application.ViewModel
{
    public class TransferViewModel
    {
        public TransferViewModel(int idFinalUser, int idWalletFinalUser, decimal value, DateTime createdAt)
        {
            IdFinalUser = idFinalUser;
            IdWalletFinalUser = idWalletFinalUser;
            Value = value;
            CreatedAt = createdAt;
        }

        public int IdFinalUser { get; set; }
        public int IdWalletFinalUser { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
