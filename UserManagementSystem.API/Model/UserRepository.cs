using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.API.Model.Interface;
using UserManagementSystem.Model;

namespace UserManagementSystem.API.Model
{
    public class UserRepository : IUser
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<User> CreateUser(User newUser)
        {
            var result = await appDbContext.User.AddAsync(newUser);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUser(int id)
        {
            var result = await appDbContext.User.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                appDbContext.User.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await appDbContext.User.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await appDbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> UpdateUser(User updatedUser)
        {
            var result = await appDbContext.User.FirstOrDefaultAsync(x => x.Id == updatedUser.Id);


            result.HouseNumber = updatedUser.HouseNumber;
            result.FirstName = updatedUser.FirstName;
            result.Surname = updatedUser.Surname;
            result.SaIdNumber = updatedUser.SaIdNumber;
            result.PostalCode = updatedUser.PostalCode;
            result.ComplexName = updatedUser.ComplexName;
            result.CellNumber = updatedUser.CellNumber;
            result.Address = updatedUser.Address;
            await appDbContext.SaveChangesAsync();
            return result;

        }
    }
}
