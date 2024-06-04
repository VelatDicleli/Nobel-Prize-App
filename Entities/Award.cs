using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Award
    {   
        public int AwardId { get; set; }
        public string DescriptorName { get; set; }
        public string Category { get; set; }

        public ICollection<Candidate_Award> CandidateAwards { get; set; }
    }
}
