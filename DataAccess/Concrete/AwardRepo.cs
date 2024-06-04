using DataAccess.Abstract;
using DataAccess.Ef_Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class AwardRepo : RepositoryBase<Award>, IAwardRepo
    {
        public AwardRepo(RepositoryContext context) : base(context)
        {

        }

        public void CreateAward(Award award)
        {
            Create(award);
        }

        public void DeleteAward(Award award)
        {   
            Delete(award);
        }

        public async Task<IEnumerable<Award>> GetAllAward()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Award> GetAward(int id)
        {
            return await FindByCondition(a => a.AwardId == id).SingleOrDefaultAsync();
        }

        public void UpdateAward(Award award)
        {
            Update(award);
        }
    }
}
