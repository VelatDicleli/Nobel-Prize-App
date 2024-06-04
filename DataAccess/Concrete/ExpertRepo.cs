using DataAccess.Abstract;
using DataAccess.Ef_Core.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ExpertRepo : RepositoryBase<Expert>, IExpertRepo
    {
        public ExpertRepo(RepositoryContext context) : base(context)
        {
        }

        public void CreateExpert(Expert expert)
        {
            Create(expert);
        }

        public void DeleteExpert(Expert expert)
        {
            Delete(expert);
        }

        public async Task<IEnumerable<Expert>> GetAllExperts()
        {
            return await FindAll().Include(e => e.Committee).ToListAsync();
        }

        public async Task<Expert> GetExpert(int id)
        {
            return await FindByCondition(e=>e.ExpertId == id).SingleOrDefaultAsync();
        }

        public void UpdateExpert(Expert expert)
        {
            Update(expert);
        }
    }
}
