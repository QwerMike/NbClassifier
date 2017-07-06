using System.ComponentModel.DataAnnotations;

namespace NbClassifier.Web.DAL.Entities
{
    public class Category
    {
        [Key]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
