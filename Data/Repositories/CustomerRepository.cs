using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Adds Customer data to database
        /// </summary>
        /// <param name="customer">Customer</param>
        public void Create(Customer customer)
        {
            using (_context)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Finds Customer record by id
        /// </summary>
        /// <param name="id">model id</param>
        /// <returns>Return Customer</returns>
        public Customer Find(long id)
        {
            using (_context)
            {
                return _context.Customers
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Retrieves all Customer records
        /// </summary>
        /// <returns>Customers list</returns>
        public List<Customer> FindAll()
        {
            using (_context)
            {
                return _context.Customers.ToList();
            }
        }

        /// <summary>
        /// Updates Customer record in database
        /// </summary>
        /// <param name="customer">Customer</param>
        public void Update(Customer customer)
        {
            using (_context)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes Customer record in database
        /// </summary>
        /// <param name="customer"></param>
        public void Remove(Customer customer)
        {
            using (_context)
            {
                _context.Customers.Remove(customer);
                _context.SaveChangesAsync();
            }
        }
    }
}