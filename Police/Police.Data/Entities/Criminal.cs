using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class Criminal
    {
        public Criminal()
        {
            ArrestingReport = new HashSet<ArrestingReport>();
        }

        public int CriminalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public DateTime? Dob { get; set; }
        public string BodyMarks { get; set; }
        public byte[] Portrait { get; set; }
        public string Occupation { get; set; }
        public int? CurrentAddress { get; set; }

        public virtual Address CurrentAddressNavigation { get; set; }
        public virtual ICollection<ArrestingReport> ArrestingReport { get; set; }
    }
}
