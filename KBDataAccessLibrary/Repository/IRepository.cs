using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KBDataAccessLibrary.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //TODO: Ar trebui sa implementez si metode de update in Repository Pattern?
        //GET
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //ADD
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities); //Add list of objects

        //UPDATE
        void Update(TEntity entity);

        //REMOVE
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities); //Remove list of objects
    }
}
