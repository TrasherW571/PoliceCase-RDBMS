using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class InvolvedPersons
    {
        public int WitnessId { get; set; }
        public int CaseId { get; set; }

        public virtual CaseFolder Case { get; set; }
        public virtual Witness Witness { get; set; }
    }
}
