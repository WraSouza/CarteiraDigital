namespace CarteiraDigital.Application.ViewModel
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            
        }
        public LoginViewModel(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}
