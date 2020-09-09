using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class ArrestingReport
    {
        public ArrestingReport()
        {
            CaseFolder = new HashSet<CaseFolder>();
        }

        public int ReportId { get; set; }
        public DateTime ArrestDate { get; set; }
        public int CriminalId { get; set; }
        public int CrimeId { get; set; }

        public virtual Crime Crime { get; set; }
        public virtual Criminal Criminal { get; set; }
        public virtual ICollection<CaseFolder> CaseFolder { get; set; }
    }
}
