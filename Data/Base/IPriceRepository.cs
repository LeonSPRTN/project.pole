using System.Collections.Generic;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using project.pole.Models;

namespace project.pole.Data.Base
{
    public interface IPriceRepository: IRepository<Price>
    {
        public IList<Price> FindAll(bool dispose = true);
        public void Create(Price price);
        public void Remove(long id);
    }
}