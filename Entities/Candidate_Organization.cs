using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Candidate_Organization
    {
        
        public int? CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
}
