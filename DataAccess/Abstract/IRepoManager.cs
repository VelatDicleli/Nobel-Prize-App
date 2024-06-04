using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepoManager
    {
        ICandidateRepo candidate { get; }
        IAwardRepo awardRepo { get; }
        IOrganizationRepo organizationRepo { get; }
        ICommitteeRepo committeeRepo { get; }
        IExpertRepo expertRepo { get; }
        Task SaveChanges();
    }
}
