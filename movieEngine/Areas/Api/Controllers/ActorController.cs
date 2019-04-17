using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieEngine.Data;
using movieEngine.Web.Areas.Api.Helpers;
using movieEngine.Web.Areas.Api.Filters;
using movieEngine.Data.Models;
using movieEngine.Web.Areas.Api.Models;
using AutoMapper;

namespace movieEngine.Web.Areas.Api.Controllers
{
    [Route("api/actors")]
    public class ActorController : MyBaseApiController
    {
        public ActorController(MyDbContext ctx, IMapper mapper) : base(ctx, mapper) { }

        // GET: api/actors
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(mapper.Map<List<ActorRequest>>(db.Actors.ToList()));
        }

        // GET: api/actors/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var actor = db.Actors.SingleOrDefault(a => a.ActorId == id);
            if (actor != null)
            {
                return Ok(mapper.Map<ActorRequest>(actor));
            }

            return NotFound();
        }


        // POST: api/actors
        [HttpPost]
        public IActionResult Create([FromBody] ActorRequest obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newActor = new Actor
            {
                Firstname = obj.Firstname,
                Lastname = obj.Lastname,
                
            };

            db.Actors.Add(newActor);
            return Ok();
        }

        // PUT: api/actors/5
        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] string value)
        {
        }

        // DELETE: api/actors/5
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
        }
    }
}
