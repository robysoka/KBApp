using KBDataAccessLibrary.DataAccess;
using KBDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Repository
{
    public class AgeCategoryRepository : Repository<AgeCategory>, IAgeCategoryRepository
    {
        public AgeCategoryRepository(KBContext context) : base(context)
        {
        }

        public KBContext KBContext
        {
            get { return Context as KBContext; }
        }
    }
}
