using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WSCME.Data;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace WSCME.Api.Controllers
{
    public class TEST
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Guid guid { get; set; }
    }
    [Route("api/[controller]")]
    [Authorize(Roles ="person")]
    public class ValuesController : Controller
    {
        //private readonly ITrainingCentreCategoryRepository repository;
        public ValuesController()
        {
            //this.repository = repository;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
            //IEnumerable<Dictionary<string, dynamic>> d = new List<Dictionary<string, dynamic>>{
            //    new Dictionary<string, dynamic>{
            //        { "id","1"},
            //        { "text","水水"},
            //        { "leaf",true},
            //        { "route","/"}
            //    },
            //    new Dictionary<string, dynamic>{
            //        { "id","2"},
            //        { "text","得到"},
            //        { "leaf",true},
            //        { "route","/"}
            //    }
            //};
            //return new ObjectResult(d);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, TEST test)
        {
            var s = Request;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
