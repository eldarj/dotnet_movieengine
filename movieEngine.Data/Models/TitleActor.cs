using System;
using System.Collections.Generic;
using System.Text;

namespace movieEngine.Data.Models
{
    public class TitleActor
    {
        public int TitleId { get; set; }
        public Title Title { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
