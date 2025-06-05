using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice_8.Models
{
    public class Music
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
