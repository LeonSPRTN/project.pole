using project.pole.Models;

namespace project.pole.Data.Base
{
    /// <summary>
    /// Interface Estimate Repository
    /// </summary>
    public interface IEstimateRepository: IRepository<Estimate>
    {
        /// <summary>
        /// Method Create
        /// </summary>
        /// <param name="estimate">Estimate</param>
        public void Create(Estimate estimate);

        /// <summary>
        /// Method Get
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>Estimate</returns>
        public Estimate Get(Customer customer);

        /// <summary>
        /// Method Update
        /// </summary>
        /// <param name="estimate">estimate</param>
        public void Update(Estimate estimate);

        /// <summary>
        /// Method Delete
        /// </summary>
        /// <param name="estimate">estimate</param>
        public void Delete(Estimate estimate);
    }
}