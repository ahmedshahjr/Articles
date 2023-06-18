using Dapper_Crud_App.Entities;
using Dapper_Crud_App.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Dapper_Crud_App.Services
{
    public class UserService : IUserService
    {
      //  private readonly IDapperUserRepository _userRepository;
        private readonly IDapperFastCrudUserRepository _userRepository;

        public UserService(IDapperFastCrudUserRepository userRepository)
        {
            _userRepository = userRepository;
        }   
        public async Task<int> AddAsync(UserInsert entity)
        {
          return  await _userRepository.InsertAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
          return  await _userRepository.DeleteAsync(id);

        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
          return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }
    }
}
