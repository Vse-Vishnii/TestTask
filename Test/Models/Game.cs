using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Game : DbEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Developer")]
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        public List<GenreGame> GenreGames { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
