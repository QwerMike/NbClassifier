using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NbClassifier.Web.DAL;

namespace NbClassifier.Web.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public TestController(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        // GET api/test
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/test/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var l = _context.Reviews
                .Where(_ => _.ReviewId < id)
                .Select(_ => _.Text)
                .ToList();

            return string.Join(" ", l);
        }
    }
}
