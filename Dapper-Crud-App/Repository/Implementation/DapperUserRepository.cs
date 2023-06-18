using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Data;
using Dapper_Crud_App.Options;
using System.Data.SqlClient;
using Dapper_Crud_App.Entities;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Dapper_Crud_App.Repository.Infrastructure;

namespace Dapper_Crud_App.Repository.Implementation
{
    public class DapperUserRepository : IDapperUserRepository
    {

        private readonly DatabaseConfigurationOptions _databaseConfiguration;
        public string ConnectionString { get; set; }

        public DapperUserRepository(IOptions<DatabaseConfigurationOptions> configuration)
        {

            _databaseConfiguration = configuration.Value;
            ConnectionString = _databaseConfiguration.ConnectionString;
        }

        public async Task<int> InsertAsync(UserInsert entity)
        {
            try
            {
                var user = new User
                {
                    Description = entity.Description,
                    Name = entity.Name,
                };
                var query = "Insert into Users (Id,Name,Description) VALUES (@Id,@Name,@Description)";
                using (var db = new SqlConnection(ConnectionString))
                {
                    await db.OpenAsync();
                    return await db.ExecuteAsync(query, user);

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task<User> GetAsync(Guid id)
        {
            try
            {
                var query = "SELECT * FROM Users WHERE Id = @Id";
                using (var db = new SqlConnection(ConnectionString))
                {
                    await db.OpenAsync();
                    return await db.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                var sql = "SELECT * FROM users";
                using (var db = new SqlConnection(ConnectionString))
                {
                    await db.OpenAsync();
                    return await db.QueryAsync<User>(sql);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<User> UpdateAsync(User entity)
        {
            try
            {
                var query = "UPDATE Users SET Name = @Name, Description = @Description WHERE Id = @Id";

                using (var db = new SqlConnection(ConnectionString))
                {
                    await db.OpenAsync();
                    await db.ExecuteAsync(query, entity);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return await Task.FromResult(entity);
        }
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                var query = "DELETE FROM Users WHERE Id = @Id";
                using (var db = new SqlConnection(ConnectionString))
                {
                    await db.OpenAsync();
                    var result = await db.ExecuteAsync(query, new { Id = id });
                    return result;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
