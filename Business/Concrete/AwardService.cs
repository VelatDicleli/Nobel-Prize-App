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
    public class AwardService : IAwardService
    {
        private IRepoManager _repoManager;

        public AwardService(IRepoManager repoManager)
        {
            _repoManager = repoManager;
        }

        public async Task CreateAward(Award award)
        {
            _repoManager.awardRepo.CreateAward(award);
            await _repoManager.SaveChanges();
        }

        public async Task DeleteAward(Award award)
        {
            _repoManager.awardRepo.DeleteAward(award);
            await _repoManager.SaveChanges();
        }

        public async Task<IEnumerable<Award>> GetAllAwards()
        {
            return await _repoManager.awardRepo.GetAllAward();
        }

        public async Task<Award> GetAwardById(int id)
        {
            return await _repoManager.awardRepo.GetAward(id);
        }

        public async Task UpdateAward(Award award)
        {
            _repoManager.awardRepo.UpdateAward(award);
            await _repoManager.SaveChanges();
        }
    }
}
