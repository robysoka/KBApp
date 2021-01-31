using KBDataAccessLibrary.Models;
using KBDataAccessLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(KBContext context) :
            base(context)
        {
        }

        public KBContext KBContext
        {
            get { return Context as KBContext; }
        }
    }
}
