using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Parameters
{
    public class CreateCandidateRequest
    {     
        public int? OrganizationId { get; set; }
        public int? CommitteeId { get; set; }
        public int? AwardId { get; set; }
        public bool Result { get; set; }
        public DateTime EvaluationDate { get; set; }
    }
}
