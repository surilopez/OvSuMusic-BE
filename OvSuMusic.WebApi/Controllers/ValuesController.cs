using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OvSuMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Value1", "Value2" };
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            return "Value"+id;
        }

        //POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] string value)
        {
           
        }

        //DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }


    }
}
