namespace _01_intro_to_ef
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // ----- Navigation Properties
        public virtual ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    }
}