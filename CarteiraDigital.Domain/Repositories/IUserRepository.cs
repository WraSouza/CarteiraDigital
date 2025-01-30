using CarteiraDigital.Domain.Entities;

namespace CarteiraDigital.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
    }
}
