using System.Threading.Tasks;
using Test.Models;

namespace Test.Repositories
{
    public class GameRepository : Repository<Game>
    {
        public GameRepository(GamesContext db) : base(db)
        {
        }

        public async override Task<Game> Create(Game entity)
        {
            Save(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
