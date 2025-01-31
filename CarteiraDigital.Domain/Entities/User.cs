namespace CarteiraDigital.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string userName, string password) : base()
        {
            FullName = fullName;
            UserName = userName;
            Password = password;

            WalletUser = [];            
        }

        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public List<Wallet> WalletUser { get; private set; }

    }
}
