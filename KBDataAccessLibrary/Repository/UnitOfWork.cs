using KBDataAccessLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KBDataAccessLibrary.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly KBContext _context;
        public UnitOfWork(KBContext context)
        {
            _context = context;
            AgeCategories = new AgeCategoryRepository(_context);
            Groups = new GroupRepository(_context);
        }

        public IAgeCategoryRepository AgeCategories { get; private set; }
        public IGroupRepository Groups  { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
