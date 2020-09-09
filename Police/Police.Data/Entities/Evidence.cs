using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class Evidence
    {
        public int EvidenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CaseId { get; set; }

        public virtual CaseFolder Case { get; set; }
    }
}
