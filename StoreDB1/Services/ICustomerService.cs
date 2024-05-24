using StoreDB1.Models;



namespace StoreDB1.Services
{
    public interface ICustomerService
    {
        Task<Models.Customer> AddUpdateCustomer(Models.Customer customer);

        Task<List<Customer>> GetCustomers();

        Task RemoveCustomer(int CustomerId);
    }
}
