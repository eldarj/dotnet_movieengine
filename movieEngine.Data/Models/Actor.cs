using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace movieEngine.Data.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        /**
         * JsonIgnore - for the purpose of this test-project, just ignore some entity 
         * model fields during serialization (otherwise the API should always map and return response/view models and not entities)
         */
        [JsonIgnore]
        public virtual ICollection<TitleActor> Titles { get; set; }
    }
}
