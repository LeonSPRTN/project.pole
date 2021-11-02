using project.pole.Models;

namespace project.pole.Data.Base
{
    public interface IEstimateRepository: IRepository<Estimate>
    {
        public void Create(Estimate estimate);
    }
}