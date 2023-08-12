using Service1.Models;

namespace Service1.Services
{
    public interface ICustomerService
    {
        Task<bool> AddCustomer(CustomerInsert order);

    }
}
