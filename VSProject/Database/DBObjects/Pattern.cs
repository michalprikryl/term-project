using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class Pattern
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Jsonrepresenation { get; set; }
        public int PatternTypeId { get; set; }

        public PatternType PatternType { get; set; }

        public object GetObject
        {
            get
            {
                return new { Id, Name, Text, Jsonrepresenation, PatternTypeId };
            }
        }
    }
}
