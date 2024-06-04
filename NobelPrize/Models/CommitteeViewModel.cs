using Entities;

namespace NobelPrize.Models
{
    public class CommitteeViewModel
    {
        
        public string CommitteeCategory { get; set; }

        public ICollection<Expert> Experts { get; set; }
        public ICollection<Candidate_Committee> CommitteeCandidates { get; set; }
    }
}
