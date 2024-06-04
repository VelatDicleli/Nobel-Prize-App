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
    public class ExpertService:IExpertService
    {
        private IRepoManager _repoManager;

        public ExpertService(IRepoManager repoManager)
        {
            _repoManager = repoManager;
        }

        public async Task CreateExpert(Expert expert)
        {
            _repoManager.expertRepo.CreateExpert(expert);
            await _repoManager.SaveChanges();
        }

        public async Task DeletExpert(Expert expert)
        {
            _repoManager.expertRepo.DeleteExpert(expert);
            await _repoManager.SaveChanges();
        }

        public async Task<IEnumerable<Expert>> GetAllExperts()
        {
            return await _repoManager.expertRepo.GetAllExperts();
        }

        public async Task<Expert> GetExpertById(int id)
        {
           return await _repoManager.expertRepo.GetExpert(id);
        }

        public async Task UpdateExpert(Expert expert)
        {
           _repoManager.expertRepo.UpdateExpert(expert);
            await _repoManager.SaveChanges();
        }
    }
}
