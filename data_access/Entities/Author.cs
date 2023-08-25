using data_access.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_access
{
    public class Author : IEntity
    {
        // Primary Key convention: Id ID id EntityName+Id (AuthorId) 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? Rating { get; set; }
        public string FullName => Name + " " + Surname;

        // Foreign Key convention: RelatedEntityName+PK
        public int? CountryId { get; set; }

        // ----- Navigation Properties

        // Relationship Type: Zero or One to Many (0/1...*)
        public virtual Country? Country { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}