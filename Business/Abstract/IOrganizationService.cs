using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetAllOrganizations();
        Task<Organization> GetOrganizationById(int id);
        Task CreateOrganization(Organization organization);
        Task DeleteOrganization(Organization organization);
        Task UpdateOrganization(Organization organization);

    }
}
