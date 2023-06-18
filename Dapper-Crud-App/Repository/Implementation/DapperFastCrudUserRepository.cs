using Dapper_Crud_App.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Dapper_Crud_App.Options;
using Microsoft.Extensions.Options;
using Dapper.FastCrud;
using System.Linq;
using Dapper_Crud_App.Repository.Infrastructure;

namespace Dapper_Crud_App.Repository.Implementation
{
    public class DapperFastCrudUserRepository : IDapperFastCrudUserRepository
    {
        private readonly DatabaseConfigurationOptions _databaseConfiguration;
        public string ConnectionString { get; set; }

        public DapperFastCrudUserRepository(IOptions<DatabaseConfigurationOptions> configuration)
        {

            _databaseConfiguration = configuration.Value;
            ConnectionString = _databaseConfiguration.ConnectionString;
        }
        public async Task<int> DeleteAsync(Guid id)
        {
            var response = 0;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var result = await db.DeleteAsync(new User { Id = id });
                if (result)
                {
                    response = 1;
                }
                return response;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var users = await db.FindAsync<User>();

                return users;
            }
        }

        public async Task<User> GetAsync(Guid id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                User author = await db.GetAsync(new User { Id = id });

                return author;
            }
        }

        public async Task<int> InsertAsync(UserInsert entity)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var user = new User
                {
                    Name = entity.Name,
                    Description = entity.Description,
                };
                await db.InsertAsync(user);
            }
            return 1;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                await db.UpdateAsync(entity);
            }
            return entity;
        }
    }
}
