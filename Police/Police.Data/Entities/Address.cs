using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class Address
    {
        public Address()
        {
            Criminal = new HashSet<Criminal>();
            Officer = new HashSet<Officer>();
            PoliceReport = new HashSet<PoliceReport>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public virtual ICollection<Criminal> Criminal { get; set; }
        public virtual ICollection<Officer> Officer { get; set; }
        public virtual ICollection<PoliceReport> PoliceReport { get; set; }
    }
}
