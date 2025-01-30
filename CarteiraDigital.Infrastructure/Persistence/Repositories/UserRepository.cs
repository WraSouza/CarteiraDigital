using CarteiraDigital.Domain.Entities;
using CarteiraDigital.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarteiraDigital.Infrastructure.Persistence.Repositories
{
    public class UserRepository(CarteiraDbContext dbContext) : IUserRepository
    {
        public async Task<int> AddUserAsync(User user)
        {
           await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        }
    }
}
