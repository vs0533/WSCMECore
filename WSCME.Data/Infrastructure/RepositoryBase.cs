﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace WSCME.Data.Infrastructure
{
    public abstract class RepositoryBase<T,CONTEXT> where T :class where CONTEXT:DbContext
    {
        protected readonly CONTEXT dataContext;
        protected DbSet<T> dbset;
        public RepositoryBase(CONTEXT dataContext)
        {
            try
            {
                this.dataContext = dataContext;
                this.dbset = this.dataContext.Set<T>();
            }
            catch (Exception ex)
            {

            }
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            dbset.RemoveRange(objects);
            //foreach (T obj in objects)
            //    dbset.Remove(obj);
        }
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
    }
}
