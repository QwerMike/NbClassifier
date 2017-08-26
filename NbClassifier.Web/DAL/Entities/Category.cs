using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NbClassifier.Web.DAL.Entities
{
    public class Category
    {
        public Category()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Key]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
