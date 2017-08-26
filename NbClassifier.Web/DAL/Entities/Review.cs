using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NbClassifier.Web.DAL.Entities
{
    public class Review
    {
        public Review()
        {
            this.Categories = new HashSet<Category>();
        }

        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Language { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
