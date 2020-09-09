using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class Victim
    {
        public Victim()
        {
            AutopsyReport = new HashSet<AutopsyReport>();
        }

        public int VictimId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public DateTime? Dob { get; set; }

        public virtual ICollection<AutopsyReport> AutopsyReport { get; set; }
    }
}
