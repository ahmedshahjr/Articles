using Dapper_Crud_App.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Crud_App.Repository
{
    public interface IDapperUserRepository
    {
        Task<User> UpdateAsync(User entity);
        Task<int> InsertAsync(UserInsert entity);
        Task<int> DeleteAsync(Guid id);
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
