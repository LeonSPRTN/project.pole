using System.Linq;
using project.pole.Data.Base;
using project.pole.Models;

namespace project.pole.Data.Repositories
{
    public class SettingEstimateRepository: ISettingEstimateRepository
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Application context</param>
        public SettingEstimateRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public SettingEstimate Find(bool dispose = true)
        {
            SettingEstimate settingEstimate;
            if (dispose)
            {
                using (_context)
                {
                    settingEstimate = _context.SettingEstimates
                        .FirstOrDefault();
                }
            }
            else
            {
                settingEstimate = _context.SettingEstimates
                    .FirstOrDefault();
            }

            return settingEstimate;
        }

        public void Create(SettingEstimate settingEstimate)
        {
            using (_context)
            {
                _context.SettingEstimates.Add(settingEstimate);
                _context.SaveChanges();
            }
        }

        public void Update(SettingEstimate settingEstimate)
        {
            using (_context)
            {
                _context.SettingEstimates.Update(settingEstimate);
                _context.SaveChanges();
            }
        }
    }
}