using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieEngine.Data;
using movieEngine.Web.Areas.Api.Helpers;

namespace movieEngine.Web.Areas.Api.Controllers
{
    [Route("api/actors")]
    public class ActorController : MyBaseApiController
    {
        public ActorController(MyDbContext ctx) : base(ctx) { }

        // GET: api/actors
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Actors.ToList());
        }

        // GET: api/Actor/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Actor
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Actor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
