using System.Collections.Generic;
using project.pole.Models;

namespace project.pole.Data.Base
{
    public interface IObjectWorkRepository: IRepository<ObjectWork>
    {
        public void Create(ObjectWork objectWork);
        public IList<ObjectWork> FindAll(bool dispose = true);
        public IList<ObjectWork> FindAll(long customerId, bool dispose = true);
        public ObjectWork Find(long id, bool dispose = true);
        public void Remove(ObjectWork objectWork);
        public void Remove(long id);
    }
}