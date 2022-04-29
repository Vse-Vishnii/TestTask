using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : AbstractController<Game, GameRepository>
    {
        public GameController(GameRepository repository) : base(repository)
        {
        }
    }
}
