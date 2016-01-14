using AuthWebApiKios.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AuthWebApiKios.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MyDbContext db = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.db = new MyDbContext();
            table = db.Set<T>();
        }

        public GenericRepository(MyDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate);
        }

        public IEnumerable<T> SelectAll()
        {
            return table.ToList();
            
        }

        public T SelectByID(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}