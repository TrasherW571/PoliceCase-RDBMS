using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class Crime
    {
        public Crime()
        {
            ArrestingReport = new HashSet<ArrestingReport>();
            PoliceReport = new HashSet<PoliceReport>();
        }

        public int CrimeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArrestingReport> ArrestingReport { get; set; }
        public virtual ICollection<PoliceReport> PoliceReport { get; set; }
    }
}
