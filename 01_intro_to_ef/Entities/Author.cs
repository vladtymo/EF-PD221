using System.ComponentModel.DataAnnotations.Schema;

namespace _01_intro_to_ef
{
    //[Table("Writers")] // set table name in db
    public class Author
    {
        // Primary Key convention: Id ID id EntityName+Id (AuthorId) 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //[Column("DateOfBirth")] // set column name in db
        public DateTime? Birthdate { get; set; }
        public int? Rating { get; set; }

        //[NotMapped] // ignore column in db
        public string FullName => Name + " " + Surname;

        // Foreign Key convention: RelatedEntityName+PK
        public int? CountryId { get; set; }

        // ----- Navigation Properties

        // Relationship Type: Zero or One to Many (0/1...*)
        public virtual Country? Country { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}