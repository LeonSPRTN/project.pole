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
            IList<ObjectWork> objectWorks;
            using (_context)
            {
                objectWorks = _context.ObjectWorks.ToList();
            }

            return objectWorks;
        }

        public IList<ObjectWork> FindAll(long customerId)
        {
            IList<ObjectWork> objectWorks;
            using (_context)
            {
                objectWorks = _context.ObjectWorks
                    .Where(o => o.CustomerId == customerId).ToList();
            }

            return objectWorks;
        }

        public ObjectWork Find(long id)
        {
            ObjectWork objectWork;
            using (_context)
            {
                objectWork = _context.ObjectWorks.Find(id);
            }

            return objectWork;
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