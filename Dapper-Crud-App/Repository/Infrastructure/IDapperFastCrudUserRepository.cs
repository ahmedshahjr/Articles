using Dapper_Crud_App.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Dapper_Crud_App.Repository.Infrastructure
{
    public interface IDapperFastCrudUserRepository
    {
        Task<User> UpdateAsync(User entity);
        Task<int> InsertAsync(UserInsert entity);
        Task<int> DeleteAsync(Guid id);
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
