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
            return Ok(mapper.Map<List<ActorResponse>>(db.Actors.ToList()));
        }

        // GET: api/actors/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var actor = db.Actors.SingleOrDefault(a => a.ActorId == id);
            if (actor != null)
            {
                return Ok(mapper.Map<ActorResponse>(actor));
            }

            return NotFound();
        }


        // POST: api/actors
        [HttpPost]
        public IActionResult Create([FromBody] ActorResponse obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newActor = mapper.Map<Actor>(obj);
            db.Actors.Add(newActor);
            db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = newActor.ActorId }, mapper.Map<ActorResponse>(newActor));
        }

        // PUT: api/actors/5
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ActorResponse obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var actor = db.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            actor.Firstname = obj.Firstname;
            actor.Lastname = obj.Lastname;

            db.SaveChanges();

            return NoContent();
        }

        // DELETE: api/actors/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var actor = db.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            db.Actors.Remove(actor);
            db.SaveChanges();

            return NoContent();
        }
    }
}
