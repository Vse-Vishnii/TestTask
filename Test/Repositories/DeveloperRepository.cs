using Test.Models;

namespace Test.Repositories
{
    public class DeveloperRepository : Repository<Developer>
    {
        public DeveloperRepository(GamesContext db) : base(db)
        {
        }
    }
}
