using System;
using System.Collections.Generic;

namespace Police.Data.Entities
{
    public partial class Witness
    {
        public int WitnessId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public DateTime? Dob { get; set; }
    }
}
