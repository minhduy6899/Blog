using MegaSystem.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Domain.RepositoryContracts
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUser();

        Task<User> AddUser(User user);

        Task<bool> DeleteUser(int id);

        Task<User?> GetUserById(int id);

    }
}
