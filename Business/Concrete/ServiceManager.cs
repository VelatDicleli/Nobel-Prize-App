using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceManager : IServiceManager
    {   
        readonly ICandidateService _candidateService;
        readonly IOrganizationService _organizationService;
        readonly ICommitteeService _committeeService;
        readonly IAwardService _awardService;
        readonly IExpertService _expertService;

        public ServiceManager(ICandidateService candidateService, IOrganizationService organizationService, ICommitteeService committeeService, IAwardService awardService, IExpertService expertService)
        {
            _candidateService = candidateService;
            _organizationService = organizationService;
            _committeeService = committeeService;
            _awardService = awardService;
            _expertService = expertService;
        }

        public ICandidateService candidateService => _candidateService;

        public IAwardService awardService => _awardService;

        public IOrganizationService organizationService => _organizationService;

        public ICommitteeService committeeService => _committeeService;

        public IExpertService expertService => _expertService;
    }
}
