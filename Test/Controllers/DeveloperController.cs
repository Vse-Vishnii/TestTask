using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : AbstractController<Developer, DeveloperRepository>
    {
        public DeveloperController(DeveloperRepository repository) : base(repository)
        {
        }
    }
}
