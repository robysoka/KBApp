using KBDataAccessLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly KBContext _context;
        public UnitOfWork(KBContext context)
        {
            _context = context;
            AgeCategories = new AgeCategoryRepository(_context);
        }

        public IAgeCategoryRepository AgeCategories { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
