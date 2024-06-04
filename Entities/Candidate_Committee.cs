using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Candidate_Committee
    {
        
        public int? CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
        public int? CommitteeId { get; set; }
        public Committee? Committee { get; set; }
        public DateTime EvaluationDate { get; set; }
        public bool Result { get; set; }
    }
}
