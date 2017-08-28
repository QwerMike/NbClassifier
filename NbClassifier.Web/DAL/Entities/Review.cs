using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NbClassifier.Web.DAL.Entities
{
    public class Review
    {
        public Review()
        {
            this.ReviewCategories = new HashSet<ReviewCategory>();
        }

        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Language { get; set; }

        public ICollection<ReviewCategory> ReviewCategories { get; set; }
    }
}
