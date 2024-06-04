using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ComplexTypeEntities
{
    public class CandidateWithAward
    {
        public int CandidateId { get; set; }
        public int AwardId { get; set; }
        public int CommitteeId { get; set; }
        public int OrganizationId {  get; set; }
        public string OrganizationName { get; set; }
        public string Committee { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string FieldOfScience { get; set; }
        public int CandidacyNumber { get; set; }
        public DateTime CandidacyDate { get; set; }
        public string DescriptorName { get; set; }
        public string Category { get; set; }
        public bool Result { get; set; }
        public DateTime EvaluationDate { get; set; }

        

       

    }
}
