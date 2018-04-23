using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class PatternType
    {
        public PatternType()
        {
            Pattern = new HashSet<Pattern>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Pattern> Pattern { get; set; }

        public object GetObject
        {
            get
            {
                return new { Id, Name };
            }
        }
    }
}
