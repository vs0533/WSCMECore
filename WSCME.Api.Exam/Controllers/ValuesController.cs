using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSCME.Domain;
using WSCME.Service;
using Microsoft.EntityFrameworkCore;

namespace WSCME.Api.Exam.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITESTLibraryCategoryServices testlibrarycategoryService;
        public ValuesController(ITESTLibraryCategoryServices testlibrarycategoryService)
        {
            this.testlibrarycategoryService = testlibrarycategoryService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            try
            {
                //testlibrarycategoryService.Create(value);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
