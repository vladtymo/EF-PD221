namespace _01_intro_to_ef
{
    // Entities classes
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }

        // ----- Navigation Properties
        public ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    }
}