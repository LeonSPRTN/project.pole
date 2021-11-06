using System.Collections.Generic;
using System.Linq;
using project.pole.Data.Base;
using project.pole.Models;

namespace project.pole.Data.Repositories
{
    public class ObjectWorkRepository: IObjectWorkRepository
    {
        private readonly ApplicationContext _context;

        public ObjectWorkRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(ObjectWork objectWork)
        {
            _context.ObjectWorks.Add(objectWork);
        }

        public IList<ObjectWork> FindAll() => _context.ObjectWorks.ToList();

        public IList<ObjectWork> FindAll(long customerId) => _context.ObjectWorks
            .Where(o => o.CustomerId == customerId).ToList();

        public ObjectWork Find(long id) => _context.ObjectWorks.Find(id);

        public void Remove(ObjectWork objectWork)
        {
            _context.ObjectWorks.Remove(objectWork);
        }

        public void Remove(long id)
        {
            using (_context)
            {
                var objectWork = new ObjectWork
                {
                    Id = id
                };
                _context.ObjectWorks.Attach(objectWork);
                _context.ObjectWorks.Remove(objectWork);
                _context.SaveChanges();
            }
        }
    }
}