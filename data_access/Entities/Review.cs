using data_access.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public class Review : IEntity
    {
        // Primary + Foreign Key
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }

        // Relationship Type: One to One 1...1 
        public virtual Book Book { get; set; }
    }
}
