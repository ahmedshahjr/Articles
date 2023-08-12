using DotNetCore.CAP;
using Service1.Data;
using Service1.Models;
using System.Text.Json;

namespace Service1.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ServiceDbContext _dbContext;
        private readonly ICapPublisher _capPublisher;

        public CustomerService(ServiceDbContext dbContext, ICapPublisher capPublisher)
        {
            _dbContext = dbContext;
            _capPublisher = capPublisher;
        }

        public async Task<bool> AddCustomer(CustomerInsert customerInsert)
        {
            Customer customer = new Customer
            {
                FirstName = customerInsert.FirstName,
                LastName = customerInsert.LastName,
                MobilNumber = customerInsert.MobilNumber,
            };

            await _dbContext.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            var content = JsonSerializer.Serialize(customer);
            await _capPublisher.PublishAsync<string>("CustomerAdded", content);
            return true;
        }
    }
}
