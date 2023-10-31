global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using System.Data;
global using System.Linq.Expressions;
global using EmployeesManagementBE.Const;
global using EmployeesManagementBE.Models;

namespace EmployeesManagementBE.Repositories.Base
{
    public class BaseRepositoy<T> : IBaseRepositoy<T> where T : class
    {
        protected EmployeesManagementContext _Context;
        public BaseRepositoy(EmployeesManagementContext Context)
        {
            _Context = Context;
        }

        public IEnumerable<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public T GetById(int Id)
        {
            return _Context.Set<T>().Find(Id);
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _Context.Set<T>().FindAsync(Id);
        }
        public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query.SingleOrDefault(criteria);
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return await query.SingleOrDefaultAsync(criteria);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query.Where(criteria).ToList();

        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return await query.Where(criteria).ToListAsync();

        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return _Context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return await _Context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int take, int skip, string[] includes)
        {
            IQueryable<T> query = _Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query.Where(match).Skip(skip).Take(take).ToList();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match, int take, int skip, string[] includes)
        {
            IQueryable<T> query = _Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return await query.Where(match).Skip(skip).Take(take).ToListAsync();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _Context.Set<T>().Where(criteria);
            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (take.HasValue)
                query = query.Take(take.Value);
            if (orderby != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderby);
                else
                    query = query.OrderByDescending(orderby);

            }
            return query.ToList();

        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _Context.Set<T>().Where(criteria);
            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (take.HasValue)
                query = query.Take(take.Value);
            if (orderby != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderby);
                else
                    query = query.OrderByDescending(orderby);

            }
            return await query.ToListAsync();

        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes, int? take, int? skip, Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _Context.Set<T>().Where(criteria);
            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (take.HasValue)
                query = query.Take(take.Value);
            if (orderby != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderby);
                else
                    query = query.OrderByDescending(orderby);

            }
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes, int? take, int? skip, Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _Context.Set<T>().Where(criteria);
            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (take.HasValue)
                query = query.Take(take.Value);
            if (orderby != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderby);
                else
                    query = query.OrderByDescending(orderby);

            }
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public T Add(T entity)
        {
            _Context.Set<T>().Add(entity);
            return entity;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
            _Context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _Context.Set<T>().AddRange(entities);
            _Context.SaveChanges();
            return entities;

        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _Context.Set<T>().AddRangeAsync(entities);
            _Context.SaveChanges();
            return entities;

        }

        public T Update(T entity)
        {
            _Context.Update(entity);
            _Context.SaveChanges();
            return entity;
        }
       
        public void Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
            _Context.SaveChanges();
        }

        public void Attach(T entity)
        {
            _Context.Set<T>().Attach(entity);
            _Context.SaveChanges();
        }

        public int Count()
        {
            return _Context.Set<T>().Count();
        }
        public async Task<int> CountAsync()
        {
            return await _Context.Set<T>().CountAsync();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _Context.Set<T>().Count(criteria);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _Context.Set<T>().CountAsync(criteria);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _Context.Set<T>().RemoveRange(entities);
            _Context.SaveChanges();
        }
        public async Task<T> OrderAsync(Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending)
        {
            if (orderByDirection == OrderBy.Ascending)
                return await _Context.Set<T>().OrderBy(orderby).FirstOrDefaultAsync();
            else
                return await _Context.Set<T>().OrderByDescending(orderby).FirstOrDefaultAsync();
        }
    }
}
