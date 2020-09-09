using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class AutopsyReport
    {
        public int ReportId { get; set; }
        public string MannerOfDeath { get; set; }
        public string CauseOfDeath { get; set; }
        public int Examiner { get; set; }
        public DateTime DateExamined { get; set; }
        public int VictimId { get; set; }
        public int CaseId { get; set; }

        public virtual CaseFolder Case { get; set; }
        public virtual Officer ExaminerNavigation { get; set; }
        public virtual Victim Victim { get; set; }
    }
}
