using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrganizationRepo : IRepositoryBase<Organization>
    {
       Task<IEnumerable<Organization>> GetAllOrganization();
       Task<Organization> GetOrganization(int id);
        void DeleteOrganization(Organization organization);
        void CreateOrganizaton(Organization organization);  
        void UpdateOrganization(Organization organization);

    }
}
