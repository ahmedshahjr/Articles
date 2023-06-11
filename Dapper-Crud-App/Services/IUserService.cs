using Dapper_Crud_App.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Crud_App.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<int> AddAsync(UserInsert entity);
        Task<User> UpdateAsync(User entity);
        Task<int> DeleteAsync(Guid id);

    }
}
