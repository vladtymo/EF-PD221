namespace _01_intro_to_ef
{
    public class Author
    {
        // Primary Key convention: Id ID id EntityName+Id (AuthorId) 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }

        // Foreign Key convention: RelatedEntityName+PK
        public int CountryId { get; set; }

        // ----- Navigation Properties
        public Country Country { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}