using CarteiraDigital.Domain.Entities;

namespace CarteiraDigital.Domain.Repositories
{
    public interface ITransferRepository
    {
        Task<int> AddTransferAsync(Transfer transfer);
        Task<Transfer> GetAllTransferByIdUser(int id);
        Task<List<Transfer>> GetTransferByIdUserAndDate(int idUser, DateTime initialDate, DateTime endDate);
    }
}
