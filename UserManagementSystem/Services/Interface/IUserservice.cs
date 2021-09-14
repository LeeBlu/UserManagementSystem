using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Model;

namespace UserManagementSystem.Services.Interface
{
    public interface IUserservice
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(User updatedUser);
        Task<User> CreateUser(User newUser);
        Task DeleteUser(int id);
    }
}
