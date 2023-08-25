using data_access.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_access
{
    // Entities classes
    public class Book : IEntity
    {
        public int Id { get; set; }
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