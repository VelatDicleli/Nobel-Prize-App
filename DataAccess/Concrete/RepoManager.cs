using DataAccess.Abstract;
using DataAccess.Ef_Core.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class RepoManager : IRepoManager
    {   readonly RepositoryContext _context;
        readonly ICandidateRepo _candidateRepo;
        readonly IExpertRepo _expertRepo;
        readonly ICommitteeRepo _committeeRepo;
        readonly IAwardRepo _awardRepo;
        readonly IOrganizationRepo _organizationRepo;
        public RepoManager(ICandidateRepo candidateRepo, RepositoryContext context, IExpertRepo expertRepo, ICommitteeRepo committeeRepo, IAwardRepo awardRepo, IOrganizationRepo organizationRepo)
        {
            _candidateRepo = candidateRepo;
            _context = context;
            _expertRepo = expertRepo;
            _committeeRepo = committeeRepo;
            _awardRepo = awardRepo;
            _organizationRepo = organizationRepo;
        }
        public ICandidateRepo candidate => _candidateRepo;

        public IAwardRepo awardRepo => _awardRepo;

        public IOrganizationRepo organizationRepo => _organizationRepo;

        public ICommitteeRepo committeeRepo => _committeeRepo;

        public IExpertRepo expertRepo => _expertRepo;

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
