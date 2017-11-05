﻿using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class Language
    {
        public Language()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso6391code { get; set; }
        public string Iso6393code { get; set; }

        public ICollection<User> User { get; set; }
    }
}
