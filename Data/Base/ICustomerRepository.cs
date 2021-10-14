using System.Collections.Generic;
using project.pole.Models;

namespace project.pole.Data.Base
{
    /// <summary>
    /// Interface Customer Repository
    /// </summary>
    public interface ICustomerRepository: IRepository<Customer>
    {
        /// <summary>
         /// Adds Customer data to database
         /// </summary>
         /// <param name="customer">Customer</param>
         public void Create(Customer customer);

        /// <summary>
        /// Finds Customer record by id
        /// </summary>
        /// <param name="id">model id</param>
        /// <returns>Return Customer</returns>
        public Customer Find(long id);

        /// <summary>
        /// Retrieves all Customer records
        /// </summary>
        /// <returns>Customers list</returns>
        public List<Customer> FindAll();

        /// <summary>
        /// Updates Customer record in database
        /// </summary>
        /// <param name="customer">Customer</param>
        public void Update(Customer customer);

        /// <summary>
        /// Deletes Customer record in database
        /// </summary>
        /// <param name="customer"></param>
        public void Remove(Customer customer);

    }
}