using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarteiraDigital.Infrastructure.Persistence.Repositories
{
    public class TransferRepository(CarteiraDbContext dbContext) : ITransferRepository
    {
        public async Task<int> AddTransferAsync(Transfer transfer)
        {
            await dbContext.Transfers.AddAsync(transfer);

            await dbContext.SaveChangesAsync();

            return transfer.Id;
        }

        public async Task<Transfer> GetAllTransferByIdUser(int id)
        {
             //throw new NotImplementedException();
            return await dbContext.Transfers                           
                           .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Transfer>> GetTransferByIdUserAndDate(int idUser, DateTime initialDate, DateTime endDate)
        {
            var transfers = await dbContext.Transfers.Where(x => x.IdInitialUser == idUser && (x.CreatedAt >= initialDate && x.CreatedAt <= endDate)).ToListAsync();
            
            //foreach (var transfer in transfers)
            //{
            //    Transfer newTransfer = new Transfer(transfer.IdInitialWallet, transfer.IdInitialUser, transfer.IdWalletFinalUser, transfer.IdFinalUser, transfer.Value);

            //    return n
            //}
            return transfers;
        }
    }
}
