using data_access.Entities;

namespace data_access
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // ----- Navigation Properties
        public virtual ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    }
}