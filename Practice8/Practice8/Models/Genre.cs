using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practice_8.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Music> Musics { get; set; }
    }
}
