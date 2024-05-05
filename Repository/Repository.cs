using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FPT_JOBPORTAL.Repository.IRepository;
using FPT_JOBPORTAL.Data;
using Microsoft.EntityFrameworkCore;

namespace FPT_JOBPORTAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.JobModel.Include(u => u.Category);
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public T Get(Expression<Func<T, bool>> predicate, string? includeProperty = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(predicate);
            if (!String.IsNullOrEmpty(includeProperty))
            {
                query.Include(includeProperty).ToList();
            }
            return query.FirstOrDefault();
        }
        public IEnumerable<T> GetAll(string? includedProperty = null)
        {
            IQueryable<T> query = dbSet;
            if (!String.IsNullOrEmpty(includedProperty))
            {
                query.Include(includedProperty).ToList();
            }
            return query.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, string? includeProperty = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(predicate);
            if (!String.IsNullOrEmpty(includeProperty))
            {
                query.Include(includeProperty).ToList();
            }
            return query.ToList();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
