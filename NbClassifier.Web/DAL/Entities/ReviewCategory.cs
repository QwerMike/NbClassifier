using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbClassifier.Web.DAL.Entities
{
    public class ReviewCategory
    {
        public int ReviewId { get; set; }
        public Review Review { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
