using Entities;

namespace NobelPrize.Models
{
    public class OrganizationViewModel
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }

        public ICollection<Candidate_Organization> OrganizationCandidates { get; set; }

    }
}
