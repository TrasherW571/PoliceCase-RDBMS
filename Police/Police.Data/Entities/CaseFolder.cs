using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class CaseFolder
    {
        public CaseFolder()
        {
            AutopsyReport = new HashSet<AutopsyReport>();
            Evidence = new HashSet<Evidence>();
        }

        public int CaseId { get; set; }
        public int PoliceReportId { get; set; }
        public int ArrestingReportId { get; set; }

        public virtual ArrestingReport ArrestingReport { get; set; }
        public virtual PoliceReport PoliceReport { get; set; }
        public virtual ICollection<AutopsyReport> AutopsyReport { get; set; }
        public virtual ICollection<Evidence> Evidence { get; set; }
    }
}
