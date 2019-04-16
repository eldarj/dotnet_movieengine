using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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

        /**
         * JsonIgnore - for the purpose of this test-project, just ignore some entity 
         * model fields during serialization (otherwise the API should always map and return response/view models and not entities)
         */
        [JsonIgnore]
        public virtual ICollection<TitleActor> Actors { get; set; }
    }
}
