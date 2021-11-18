using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using project.pole.Models;

namespace project.pole.Data.Base
{
    public interface ISettingEstimateRepository: IRepository<SettingEstimate>
    {
        public SettingEstimate Find(bool dispose = true);

        public void Create(SettingEstimate settingEstimate);

        public void Update(SettingEstimate settingEstimate);
    }
}