using Entities;

namespace NobelPrize.Models
{
    public class CreateCandidateViewModel
    {   
        public int CandidateId { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string FieldOfScience { get; set; }
        public int CandidacyNumber { get; set; }
        public DateTime CandidacyDate { get; set; }

        public ICollection<Organization>? Organizations { get; set; }
        public ICollection<Committee>? Committees { get; set; }
        public ICollection<Award>? Awards { get; set; }

        public bool Result {  get; set; }
        public DateTime EvaluationDate { get; set; }
    }
}
