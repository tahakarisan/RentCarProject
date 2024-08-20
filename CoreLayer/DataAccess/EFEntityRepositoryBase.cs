﻿
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoreLayer.DataAccess
{
    public class EFEntityRepositoryBase<TEntity, TContext>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()

    {
        public bool Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedColor = context.Entry(entity);
                addedColor.State = EntityState.Added;
                return context.SaveChanges() > 0;

            }
        }

        public bool Delete(int id)
        {
            using (TContext context = new TContext())
            {
                var entity = context.Set<TEntity>().Find(id);
                var deletedColor = context.Entry(entity);
                deletedColor.State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
    

        public bool Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedColor = context.Entry(entity);
                updatedColor.State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }
    }
}