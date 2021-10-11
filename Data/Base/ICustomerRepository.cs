using project.pole.Models;

namespace project.pole.Data.Base
{
    /// <summary>
    /// Interface Customer Repository
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Method Create
        /// </summary>
        /// <param name="customer">Customer</param>
        public void Create(Customer customer);

        /// <summary>
        /// Method Get
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>Estimate</returns>
        public Estimate Get(Customer customer);

        /// <summary>
        /// Method Get
        /// </summary>
        /// <returns>List Customer</returns>
        public Estimate GetAll();

        /// <summary>
        /// Method Update
        /// </summary>
        /// <param name="customer">Customer</param>
        public void Update(Customer customer);

        /// <summary>
        /// Method Delete
        /// </summary>
        /// <param name="customer">Customer</param>
        public void Delete(Customer customer);
    }
}