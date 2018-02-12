using System;
using System.Collections.Generic;

namespace Database.DBObjects
{
    public partial class WorkSpace
    {
        public WorkSpace()
        {
            Graph = new HashSet<Graph>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DataFile { get; set; }
        public string DataFormat { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Graph> Graph { get; set; }
    }
}
