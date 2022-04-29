using Test.Models;

namespace Test.Repositories
{
    public class GenreRepository : Repository<Genre>
    {
        public GenreRepository(GamesContext db) : base(db)
        {
        }
    }
}
