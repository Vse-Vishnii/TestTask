using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Developer : DbEntity
    {
        [Required]
        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}
