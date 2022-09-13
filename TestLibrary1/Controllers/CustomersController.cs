using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWIndLinqEfLibrary2.Controllers;
using NorthWIndLinqEfLibrary2.Models;
using Microsoft.EntityFrameworkCore;

namespace NorthWIndLinqEfLibrary2.Controllers
{
    public class CustomersController {

        private readonly AppDbContext _context = null!;
        public CustomersController(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAll() {
            return await _context.Customers.OrderBy(c => c.CompanyName).ToListAsync();
        }

        public async Task<Customer?> GetByPK(string customerId) {
            //Customer? cust = await _context.Customers.SingleOrDefaultAsync(e => e.CustomerId == customerId);
            return await _context.Customers.FindAsync(customerId);
        }
        /*
        public IEnumerable<Customer> Contains(string subString) {
            IEnumerable<Customer> customers = from c in _context.Customers
                                              where c.CompanyName.Contains(subString)
                                              orderby c.CompanyName
                                              select c;
            return customers;
        }
        */
        public async Task Update(string customerId, Customer customer) {
            if (customerId != customer.CustomerId) {
                throw new ArgumentException("Customer id doesn't match customer instance!");
            }
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<Customer> Insert(Customer customer) {
            if (customer.CustomerId.Length != 5) {
                throw new ArgumentException("Inserting a new customer requires the customerId be set to zero!");
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(string customerId) {
            Customer? cust = await GetByPK(customerId);
            if (cust is null) {
                throw new Exception("Customer not found!");
            }
            _context.Customers.Remove(cust);
            await _context.SaveChangesAsync();
        }
    }
}

