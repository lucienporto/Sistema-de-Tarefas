using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SistemaTarefasDbContext _dbContext;
        public UserRepository(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"The user ID: {id} was not found in the database.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"The user ID: {id} was not found in the database.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
