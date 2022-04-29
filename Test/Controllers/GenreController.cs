using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : AbstractController<Genre, GenreRepository>
    {
        public GenreController(GenreRepository repository) : base(repository)
        {
        }
    }
}
