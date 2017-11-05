using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class User
    {
        public User()
        {
            WorkSpace = new HashSet<WorkSpace>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int LanguageId { get; set; }

        public Language Language { get; set; }
        public ICollection<WorkSpace> WorkSpace { get; set; }
    }
}
