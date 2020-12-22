using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAgeCategoryRepository AgeCategories { get; }
        int Complete();
    }
}
