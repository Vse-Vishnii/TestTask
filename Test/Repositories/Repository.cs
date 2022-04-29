using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : DbEntity
    {
        protected readonly GamesContext db;

        public Repository(GamesContext db)
        {
            this.db = db;
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            db.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<TEntity>> ReadAll()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> Read(int id)
        {
            return await db.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> Update(TEntity newEntity)
        {
            var entity = db.Set<TEntity>().Find(newEntity.Id);
            newEntity.GetType()
                .GetProperties()
                .Where(p => p.GetValue(newEntity) != null)
                .ToList()
                .ForEach(p => entity.GetType().GetProperty(p.Name).SetValue(entity, p.GetValue(newEntity)));
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Delete(int id)
        {
            var entity = db.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return entity;
            }
            db.Remove(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        protected void Save(TEntity entity)
        {
            db.ChangeTracker.TrackGraph(entity, node =>
                node.Entry.State = !node.Entry.IsKeySet ? EntityState.Added : EntityState.Unchanged);
        }
    }
}
