using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_intro_to_ef
{
    public class Review
    {
        // Primary + Foreign Key
        [Key]                   // set primary key
        [ForeignKey("Book")]    // set foreign key
        public int BookId { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }

        // Relationship Type: One to One 1...1 
        public virtual Book Book { get; set; }
    }
}
