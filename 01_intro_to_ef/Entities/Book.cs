using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_intro_to_ef
{
    // Entities classes
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(200)]    // set string max len
        [Required]          // set not null
        public string Title { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }

        // ----- Navigation Properties
        public virtual ICollection<Author> Authors { get; set; } = new HashSet<Author>();
        public virtual Review? Review { get; set; }

        public override string ToString()
        {
            return $"[{Id}] - Title: {Title}, {Year}";
        }
    }
}