using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace movieEngine.Data.Models
{
    public class Title // All tv acts are Titles => Titles can be of type Movie or TV Show
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Released { get; set; } = DateTime.Now;
        public double Rating { get; set; } = 0;

        [ForeignKey("Type")]
        public int TitleTypeId { get; set; }

        public TitleType Type { get; set; }

        public virtual ICollection<TitleActor> Actors { get; set; }
    }
}
