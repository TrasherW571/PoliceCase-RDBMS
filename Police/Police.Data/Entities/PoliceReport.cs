using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class PoliceReport
    {
        public PoliceReport()
        {
            CaseFolder = new HashSet<CaseFolder>();
        }

        public int ReportId { get; set; }
        public DateTime TimeOccurred { get; set; }
        public DateTime TimeReported { get; set; }
        public string Narrative { get; set; }
        public int ReportingOfficer { get; set; }
        public int CrimeId { get; set; }
        public int CrimeLocation { get; set; }

        public virtual Crime Crime { get; set; }
        public virtual Address CrimeLocationNavigation { get; set; }
        public virtual Officer ReportingOfficerNavigation { get; set; }
        public virtual ICollection<CaseFolder> CaseFolder { get; set; }
    }
}
