using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NbClassifier.Web.DAL.Entities
{
    public class Category
    {
        public Category()
        {
            this.ReviewCategories = new HashSet<ReviewCategory>();
        }

        [Key]
        public int CategoryId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ReviewCategory> ReviewCategories { get; set; }
    }
}
