using System;
using System.Collections.Generic;
using System.Text;

namespace movieEngine.Data.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual ICollection<TitleActor> Titles { get; set; } // titles that this actor acted in
    }
}
