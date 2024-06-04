using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Expert
    {
        public int ExpertId { get; set; }
        public string ExpertFirstName { get; set; }
        public string ExpertLastName { get; set; }
        public string ExpertField { get; set; }
        public int CommitteeId { get; set; }
        public Committee Committee { get; set; }
    }
}
