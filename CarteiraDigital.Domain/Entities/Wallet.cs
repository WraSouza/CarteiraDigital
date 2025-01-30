using Microsoft.AspNetCore.Identity;

namespace CarteiraDigital.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public Wallet()
        {
            
        }
        public Wallet(int idUser, decimal value) : base()
        {            
            IdUser = idUser;
            Value = value;           
            
        }

        public int IdUser { get; private set; }
        public User User { get; private set; }
        public decimal Value { get; private set; }

        public void UpdateWallet(decimal value)
        {

           Value += value;
        }
      
    }
}