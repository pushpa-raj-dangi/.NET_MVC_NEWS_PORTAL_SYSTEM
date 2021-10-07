using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsWebApp.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

        T Get(int id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Savechanges();



    }
}
