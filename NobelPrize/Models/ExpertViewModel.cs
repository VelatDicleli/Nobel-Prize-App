using Entities;

namespace NobelPrize.Models
{
    public class ExpertViewModel
    {
        public string ExpertFirstName { get; set; }
        public string ExpertLastName { get; set; }
        public string ExpertField { get; set; }
        public int CommitteeId { get; set; }
        public Committee Committee { get; set; }
    }
}
