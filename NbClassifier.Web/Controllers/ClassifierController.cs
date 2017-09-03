using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            return ClassifierService.Classify(review).ToString();
        }

        // POST api/classifier
        [HttpPost]
        public string Post(string review)
        {
            return ClassifierService.Classify(review);
        }
    }
}