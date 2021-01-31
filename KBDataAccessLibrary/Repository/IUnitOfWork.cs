using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KBDataAccessLibrary.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAgeCategoryRepository AgeCategories { get; }

        IGroupRepository Groups { get; }

        Task<int> Complete();
    }
}
