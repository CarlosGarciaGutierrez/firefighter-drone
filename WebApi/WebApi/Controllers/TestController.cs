using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class TestController : ControllerBase
    {
        private readonly IInc _inc;

        public TestController(IInc inc)
        {
            _inc = inc;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            return "¡Gracias " + id + "!";
        }

        [HttpPost("{id}")]
        public string Post([FromBody]Dummy dum)
        {
            if (!ModelState.IsValid)
                return "El modelo no es válido";

            return _inc.Inc() + " -> " + dum.i + dum.s + dum.d;
        }

        [HttpPut("{id}")]
        public void Put(string id)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}