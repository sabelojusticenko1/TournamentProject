using Tournaments.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tournaments.DAL;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Migrations;

namespace Tournaments.DAL
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext appDbContext { get; set; }

        public RepositoryBase(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public IQueryable<T> FindAll() => appDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            appDbContext.Set<T>().Where(expression);

        public void Create(T entity) => appDbContext.Set<T>().Add(entity);


        public void Update(T entity)
        {
            appDbContext.Set<T>().AddOrUpdate(entity);
            //appDbContext.Set<T>().Attach(entity);
            //appDbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            
        }

        public void Delete(T entity) => appDbContext.Set<T>().Remove(entity);

        public void Save()
        {
            appDbContext.SaveChanges();
        }



        public virtual T GetById(int id)
        {
            
            //Tournament tournament = appDbContext.Tournament.Find(id);
            return appDbContext.Set<T>().Find(id);


        }
    }
}
