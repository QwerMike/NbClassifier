using Microsoft.AspNetCore.Mvc;
using NbClassifier.Web.DAL;

namespace NbClassifier.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Classifier")]
    public class ClassifierController : Controller
    {
        public ClassifierController(AppDbContext context)
        {
            _context = context;

            if (!ClassifierService.IsInitialized)
            {
                ClassifierService.Initialize(context);
            }
        }

        private readonly AppDbContext _context;

        // GET api/classifier/"review"
        [HttpGet("{review}")]
        public string Get(string review)
        {
            return ClassifierService.Classify(review);
        }

        // POST api/classifier
        [HttpPost]
        public string Post([FromBody]string review)
        {
            return ClassifierService.Classify(review);
        }
    }
}