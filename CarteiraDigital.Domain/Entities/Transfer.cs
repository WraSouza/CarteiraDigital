namespace CarteiraDigital.Domain.Entities
{
    public class Transfer : BaseEntity
    {
        public Transfer()
        {
            
        }
        public Transfer(int idInitialWallet,int idInitialUser,int idWalletFinalUser, int idFinalUser, decimal value) : base()
        {
            IdInitialWallet = idInitialWallet;
            IdInitialUser = idInitialUser;
            IdWalletFinalUser = idWalletFinalUser;
            IdFinalUser = idFinalUser;
            Value = value;           
            
        }

        public int IdInitialWallet { get; private set; }
        public Wallet FromWallet { get; private set; }
        public int IdInitialUser { get; private set; }
        public int IdWalletFinalUser { get; private set; }
        public Wallet ToWallet { get; private set; }
        public int IdFinalUser { get; private set; }
        public decimal Value { get; private set; }
        
    }
}
