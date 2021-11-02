using project.pole.Data.Base;
using project.pole.Models;

namespace project.pole.Data.Repositories
{
    public class EstimateRepository: IEstimateRepository
    {
        private readonly ApplicationContext _context;

        public EstimateRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Estimate estimate)
        {
            using (_context)
            {
                _context.Estimates.Add(estimate);
                _context.SaveChanges();
            }
        }
    }
}