using System;
using System.Collections.Generic;
using System.Linq;
using project.pole.Data.Base;
using project.pole.Models;

namespace project.pole.Data.Repositories
{
    public class PriceRepository: IPriceRepository
    {
        private readonly ApplicationContext _context;

        public PriceRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public IList<Price> FindAll(bool dispose = true)
        {
            IList<Price> prices;
            if (dispose)
            {
                using (_context)
                {
                    prices = _context.Prices.ToList();
                }
            }
            else
            {
                prices = _context.Prices.ToList();
            }

            return prices;
        }

        public void Create(Price price)
        {
            using (_context)
            {
                _context.Prices.Add(price);
                _context.SaveChanges();
            }
        }

        public void Remove(long id)
        {
            using (_context)
            {
                var price = new Price
                {
                    Id = id
                };
                _context.Attach(price);
                _context.Prices.Remove(price);
                _context.SaveChanges();
            }
        }
    }
}