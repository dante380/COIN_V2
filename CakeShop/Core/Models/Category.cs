using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FavoursShop.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Favour> Favours { get; set; }

        public Category()
        {
            Favours = new Collection<Favour>();
        }
    }
}
