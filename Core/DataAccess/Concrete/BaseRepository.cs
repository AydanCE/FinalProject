﻿using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class BaseRepository<TEntity, TContext>(TContext context) : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context = context;
        public void Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null ? _context.Set<TEntity>().Where(filter).ToList() : _context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
