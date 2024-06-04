using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }

        public ICollection<Candidate_Organization> OrganizationCandidates { get; set; }
    }
}
