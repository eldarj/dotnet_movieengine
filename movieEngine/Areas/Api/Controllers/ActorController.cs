using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieEngine.Data;
using movieEngine.Web.Areas.Api.Helpers;
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


        #region "Actor's titles endpoints"
        // GET: api/actors/5/titles
        [HttpGet]
        [Route("{id}/titles")]
        public IActionResult GetActorTitles([FromRoute] int id, [FromQuery] string type)
        {
            var actor = db.Actors
                .Include(a => a.Titles)
                .SingleOrDefault(a => a.ActorId == id);
            if (actor == null)
            {
                return NotFound();
            }

            var titles = String.IsNullOrEmpty(type) ?
                db.Titles
                    .Include(t => t.Type)
                    .Include(t => t.Actors)
                    .Where(t => t.Actors.Intersect(actor.Titles).Any())
                    .ToList() :
                db.Titles
                    .Include(t => t.Type)
                    .Include(t => t.Actors)
                    .Where(t => t.Type.Name == type && t.Actors.Intersect(actor.Titles).Any())
                    .ToList();

            return Ok(mapper.Map<List<TitleResponse>>(titles));
        }

        // PUT: api/actors/5/titles
        [HttpPut]
        [Route("{id}/titles")]
        public IActionResult UpdateActorTitles([FromRoute] int id, [FromBody] List<TitleResponse> titles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var actor = db.Actors
                .Include(a => a.Titles)
                .SingleOrDefault(a => a.ActorId == id);
            if (actor == null)
            {
                return NotFound();
            }

            db.TitlesActors.RemoveRange(actor.Titles);
            actor.Titles = titles.Select(t => new TitleActor {
                ActorId = actor.ActorId,
                TitleId = t.Id
            })
            .ToList();

            db.SaveChanges();

            return NoContent();
        }

        #endregion
    }
}
