namespace CarteiraDigital.Application.InputModel
{
    internal class GetBalanceUserInputModel
    {
        public GetBalanceUserInputModel(int idBalance, int idUser)
        {
            IdBalance = idBalance;
            IdUser = idUser;
        }

        public int IdBalance { get; set; }
        public int IdUser { get; set; }
    }
}
