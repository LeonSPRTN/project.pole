using System.Collections.Generic;
using System.Linq;
using project.pole.Data.Base;
using project.pole.Models;

namespace project.pole.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Application context</param>
        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Customer customer)
        {
            using (_context)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
        }

        public Customer Find(long id)
        {
            using (_context)
            {
                return _context.Customers
                    .Find(id);
            }
        }

        public List<Customer> FindAll()
        {
            using (_context)
            {
                return _context.Customers.ToList();
            }
        }

        public void Update(Customer customer)
        {
            using (_context)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
        }

        public void Remove(Customer customer)
        {
            using (_context)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public void Remove(long id)
        {
            using (_context)
            {
                var customer = new Customer
                {
                    Id = id
                };
                _context.Customers.Attach(customer);
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}