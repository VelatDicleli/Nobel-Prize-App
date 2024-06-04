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
    public class CommitteeService:ICommitteeService
    {
        private IRepoManager _repoManager;

        public CommitteeService(IRepoManager repoManager)
        {
            _repoManager = repoManager;
        }

        public async Task CreateCommittee(Committee committee)
        {
            _repoManager.committeeRepo.Create(committee);
            await _repoManager.SaveChanges();
        }

        public async Task DeleteCommitteeById(Committee committee)
        {
            _repoManager.committeeRepo.DeleteCommittee(committee);
            await _repoManager.SaveChanges();
        }

        public async Task<IEnumerable<Committee>> GetAllCommitties()
        {
            return await _repoManager.committeeRepo.GetAllCommitee();
        }

        public async Task<Committee> GetCommitteeById(int id)
        {
            return await _repoManager.committeeRepo.GetCommitteeById(id);
        }

        public async Task UpdateCommittee(Committee committee)
        {
            _repoManager.committeeRepo.UpdateCommitte(committee);
            await _repoManager.SaveChanges();
        }
    }
}
