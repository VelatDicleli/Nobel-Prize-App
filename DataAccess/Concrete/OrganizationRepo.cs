using DataAccess.Abstract;
using DataAccess.Ef_Core.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class OrganizationRepo : RepositoryBase<Organization>, IOrganizationRepo
    {
        public OrganizationRepo(RepositoryContext context) : base(context)
        {
        }

        public void CreateOrganizaton(Organization organization)
        {
            Create(organization);
        }

        public void DeleteOrganization(Organization organization)
        {
            Delete(organization);
        }

        public async Task<IEnumerable<Organization>> GetAllOrganization()
        {
            return await FindAll().ToListAsync();

        }

        public async Task<Organization> GetOrganization(int id)
        {
            return await FindByCondition(o=>o.OrganizationId == id).SingleOrDefaultAsync();
        }

        public void UpdateOrganization(Organization organization)
        {
            Update(organization);   
        }
    }
}
