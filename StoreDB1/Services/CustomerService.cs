
using Microsoft.EntityFrameworkCore;
using StoreDB1.Models;
using System.ComponentModel;
using StoreDB1.Services;
using NuGet.Protocol;

namespace StoreDB1.Services
{
    public class CustomerService : ICustomerService

    {
        private readonly StoreDbContext _context;

        public CustomerService (StoreDbContext context)
        {
            _context = context;
        }

         async Task<Customer> ICustomerService.AddUpdateCustomer(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                _context.Add(customer).State = EntityState.Modified;
            }
            else
            {
                _context.Add(customer);
            }
            await _context.SaveChangesAsync();
            return customer;
        }

        async Task<List<Customer>> ICustomerService.GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

         async Task ICustomerService.RemoveCustomer(int CustomerId)
        {
            var customer = await _context.Customers.FindAsync(CustomerId);
            if (customer  != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
