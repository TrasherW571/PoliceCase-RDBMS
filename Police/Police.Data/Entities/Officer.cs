using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class Officer
    {
        public Officer()
        {
            AutopsyReport = new HashSet<AutopsyReport>();
            PoliceReport = new HashSet<PoliceReport>();
        }

        public int OfficerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<AutopsyReport> AutopsyReport { get; set; }
        public virtual ICollection<PoliceReport> PoliceReport { get; set; }
    }
}
