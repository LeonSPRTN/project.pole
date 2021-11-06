using System;
using project.pole.Data.Base;
using project.pole.Data.Repositories;
using project.pole.Models;

namespace project.pole.Data
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed = false;
        private ApplicationContext context = new ApplicationContext();
        private CustomerRepository _customerRepository;
        private ObjectWorkRepository _objectWorkRepository;

        public CustomerRepository Customer => _customerRepository ??= new CustomerRepository(context);
        public ObjectWorkRepository ObjectWork => _objectWorkRepository ??= new ObjectWorkRepository(context);

        public void Save() => context.SaveChanges();


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}