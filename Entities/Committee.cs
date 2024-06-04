using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Committee
    {
        public int CommitteeId { get; set; }
        public string CommitteeCategory { get; set; }

        public ICollection<Expert> Experts { get; set; }
        public ICollection<Candidate_Committee> CommitteeCandidates { get; set; }
    }
}
