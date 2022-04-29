using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers
{
    public abstract class AbstractController<TEntity, TRepository> : Controller 
        where TEntity : DbEntity
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository repository;

        public AbstractController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async virtual Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.ReadAll();
        }

        [HttpGet("{id}")]
        public async virtual Task<ActionResult<TEntity>> Get(int id)
        {
            return await repository.Read(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            if (entity == null)
                return BadRequest();
            await repository.Create(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TEntity>> Put(int id, TEntity newEntity)
        {
            if (id != newEntity.Id)
            {
                return BadRequest();
            }
            await repository.Update(newEntity);
            return Ok(newEntity);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
