using Entities;

namespace NobelPrize.Models
{
    public class UpdateCandidateViewModel
    {
        public int CandidateId { get; set; }
        public int AwardId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string FieldOfScience { get; set; }
        public int CandidacyNumber { get; set; }
        public DateTime CandidacyDate { get; set; }
        public string DescriptorName { get; set; }
        public string Category { get; set; }

        public ICollection<Organization>? Organizations { get; set; }
        public ICollection<Committee>? Committees { get; set; }
        public ICollection<Award>? Awards { get; set; }

        public bool Result { get; set; }
        public DateTime EvaluationDate { get; set; }
    }
}
