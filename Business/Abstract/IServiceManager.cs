using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceManager
    {
        ICandidateService candidateService { get; }
        IAwardService awardService { get; }
        IOrganizationService organizationService { get; }
        ICommitteeService committeeService { get; }
        IExpertService expertService { get; }
    }
}
