using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarteiraDigital.Infrastructure.Persistence.Repositories
{
    public class WalletRepository(CarteiraDbContext dbContext) : IWalletRepository
    {
        public async Task<int> AddWalletAsync(Wallet balance)
        {
            await dbContext.Wallets.AddAsync(balance);

            await dbContext.SaveChangesAsync();

            return balance.Id;
        }

        public async Task<Wallet> GetWalletByIdAsync(int id, int idUser)
        {
           return await dbContext.Wallets
                            .Include(u => u.User)
                            .FirstOrDefaultAsync(u => u.Id == id && u.IdUser == idUser);
                            
        }

        public void UpdateWalletAsync(Wallet wallet)
        {
            dbContext.Wallets.Update(wallet);

            dbContext.SaveChanges();           
        }
    }
}
