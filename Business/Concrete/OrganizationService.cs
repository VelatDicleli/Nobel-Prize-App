using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrganizationService:IOrganizationService
    {
        private IRepoManager _repoManager;

        public OrganizationService(IRepoManager repoManager)
        {
            _repoManager = repoManager;
        }

        public async Task CreateOrganization(Organization organization)
        {
            _repoManager.organizationRepo.CreateOrganizaton(organization);
            await _repoManager.SaveChanges();
        }

        public async Task DeleteOrganization(Organization organization)
        {
            _repoManager.organizationRepo.DeleteOrganization(organization);
            await _repoManager.SaveChanges();
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizations()
        {
            return await _repoManager.organizationRepo.GetAllOrganization();
        }

        public async Task<Organization> GetOrganizationById(int id)
        {
            return await _repoManager.organizationRepo.GetOrganization(id);
        }

        public async Task UpdateOrganization(Organization organization)
        {
            _repoManager.organizationRepo.UpdateOrganization(organization);
            await _repoManager.SaveChanges();
        }
    }
}
