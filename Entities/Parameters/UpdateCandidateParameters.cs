using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Parameters
{
    public class UpdateCandidateParameters : RequestParameters
    {
        public int? OrganizationId { get; set; }
        public int? CommitteeId { get; set; }
        public int? AwardId { get; set; }
        public bool Result { get; set; }
        public DateTime? EvaluationDate { get; set; }
        public int? update_organizationId { get; set; }
        public int? update_committeeId { get; set; }
        public int? update_awardId { get; set; }
        public bool update_result { get; set; }
        public DateTime? update_evaluationDate { get; set; }
    }
}
