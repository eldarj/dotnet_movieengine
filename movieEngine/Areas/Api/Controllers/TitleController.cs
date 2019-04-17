using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieEngine.Data;
using movieEngine.Data.Models;
using movieEngine.Web.Areas.Api.Helpers;
using movieEngine.Web.Areas.Api.Models;

namespace movieEngine.Web.Areas.Api.Controllers
{
    [Route("api/titles")]
    public class TitleController : MyBaseApiController
    {
        public TitleController(MyDbContext ctx, IMapper mapper) : base(ctx, mapper) { }

        // GET: api/titles?type=movie
        //  - With query param 'type' as: Optional, Caseinsensitive
        [HttpGet]
        public IActionResult Get([FromQuery] string type)
        {
            var titles = String.IsNullOrEmpty(type) ? 
                db.Titles
                    .Include(t => t.Type)
                    .ToList() : 
                db.Titles
                    .Include(t => t.Type)
                    .Where(t => t.Type.Name == type)
                    .ToList();

            return Ok(mapper.Map<List<TitleResponse>>(titles));
        }


        // GET: api/titles/5
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var title = db.Titles.Find(id);
            if (title != null)
            {
                return Ok(mapper.Map<TitleResponse>(title));
            }

            return NotFound();
        }


        // POST: api/titles
        [HttpPost]
        public IActionResult Create([FromBody] TitleResponse obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newTitle = mapper.Map<Title>(obj);
            db.Titles.Add(newTitle);
            db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = newTitle.TitleId }, mapper.Map<TitleResponse>(newTitle));
        }

        // PUT: api/titles/5
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TitleResponse obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var title = db.Titles.Find(id);
            if (title == null)
            {
                return NotFound();
            }

            title.Name = obj.Name;
            title.Description = obj.Description;
            //title.Image;
            title.Rating = obj.Rating;
            title.Released = DateTime.ParseExact(obj.Released, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var type = db.TitleTypes.Where(tp => tp.Name.ToLower() == obj.Name.ToLower()).FirstOrDefault();
            if (type != null)
                title.Type = type;

            db.SaveChanges();

            return NoContent();
        }

        // DELETE: api/title/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var title = db.Titles.Find(id);
            if (title == null)
            {
                return NotFound();
            }

            db.Titles.Remove(title);
            db.SaveChanges();

            return NoContent();
        }
    }
}