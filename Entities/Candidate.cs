using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string FieldOfScience { get; set; }
        public int CandidacyNumber { get; set; }
        public DateTime CandidacyDate { get; set; }

        public ICollection<Candidate_Organization> CandidateOrganizations { get; set; }
        public ICollection<Candidate_Committee> CandidateCommittees { get; set; }
        public ICollection<Candidate_Award> CandidateAwards { get; set; }
    }
}
