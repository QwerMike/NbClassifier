using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NbClassifier.Web.DAL.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public string Language { get; set; }

        public List<Category> Categories { get; set; }
    }
}
