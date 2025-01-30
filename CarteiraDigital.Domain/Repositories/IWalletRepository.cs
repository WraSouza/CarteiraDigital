using CarteiraDigital.Domain.Entities;

namespace CarteiraDigital.Domain.Repositories
{
    public interface IWalletRepository
    {
        Task<int> AddWalletAsync(Wallet balance);
        Task<Wallet> GetWalletByIdAsync(int id, int idUser);
        void UpdateWalletAsync(Wallet wallet);
    }
}
