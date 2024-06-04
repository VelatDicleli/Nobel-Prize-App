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
    public class CommitteeRepo : RepositoryBase<Committee>, ICommitteeRepo
    {
        public CommitteeRepo(RepositoryContext context) : base(context)
        {
        }

        public void DeleteCommittee(Committee committee)
        {
            Delete(committee);
        }

        public async Task<IEnumerable<Committee>> GetAllCommitee()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Committee> GetCommitteeById(int id)
        {
            return await FindByCondition(co => co.CommitteeId == id).Include(x => x.Experts)
                .Include(x => x.CommitteeCandidates)
                .ThenInclude(x=>x.Candidate)
                .SingleOrDefaultAsync();
        }

        public void UpdateCommitte(Committee committee)
        {
           Update(committee);
        }
    }
}
