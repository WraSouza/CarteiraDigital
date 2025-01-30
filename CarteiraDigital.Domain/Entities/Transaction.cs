namespace CarteiraDigital.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction(int idBalance,int idUser, decimal value, int idFinalUser)
        {
            IdBalance = idBalance;
            IdUser = idUser;           
            Value = value;
            IdFinalUser = idFinalUser;
            TransactionAt = DateTime.Now;
           
        }

        public int IdBalance { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public decimal Value { get; private set; }
        public int IdFinalUser { get; private set; }
        public User FinalUser { get; private set; }
        public DateTime TransactionAt { get; private set; }
    }
}
