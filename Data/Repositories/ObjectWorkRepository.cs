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
            using (_context)
            {
                _context.ObjectWorks.Add(objectWork);
                _context.SaveChanges();
            }
        }

        public IList<ObjectWork> FindAll()
        {
            using (_context)
            {
                return _context.ObjectWorks.ToList();
            }
        }

        public IList<ObjectWork> FindAll(long customerId)
        {
            using (_context)
            {
                return _context.ObjectWorks
                    .Where(o=>o.CustomerId == customerId).ToList();
            }
        }

        public void Remove(ObjectWork objectWork)
        {
            using (_context)
            {
                _context.ObjectWorks.Remove(objectWork);
                _context.SaveChanges();
            }
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