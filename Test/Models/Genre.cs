using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Genre : DbEntity
    {
        [Required]
        public string Name { get; set; }

        public List<GenreGame> GenreGames { get; set; }
        public List<Game> Games { get; set; }
    }
}
