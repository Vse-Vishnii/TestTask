using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class GenreGame : DbEntity
    {
        [ForeignKey("Game")]
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [ForeignKey("Genre")]
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public GenreGame()
        {

        }
    }
}
