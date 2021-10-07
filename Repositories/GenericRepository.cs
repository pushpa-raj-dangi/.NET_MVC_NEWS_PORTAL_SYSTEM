using Microsoft.EntityFrameworkCore;
using NewsWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsWebApp.Repositories
{
    public abstract class GenericRepository<T>
        : IRepository<T> where T : class
    {
        internal readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public virtual IEnumerable<T> All()
        {
            return _context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsQueryable()
                .Where(predicate).ToList();
        }

        public virtual T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public virtual void Delete(T entity)
        {
            _context.Remove<T>(entity);
        }


        public virtual void Savechanges()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            //_context.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            //return _context.Update(entity).Entity;
            _context.Entry(entity).State = EntityState.Detached;
            return entity;


        }


    }
}
