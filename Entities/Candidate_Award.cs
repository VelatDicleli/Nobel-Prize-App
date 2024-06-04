using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Candidate_Award
    {
        
        public int? CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
        public int? AwardId { get; set; }
        public Award? Award { get; set; }
    }
}
