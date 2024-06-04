using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Entities.ComplexTypeEntities;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CandidateService : ICandidateService
    {
        private IRepoManager _repoManager;

        public CandidateService(IRepoManager repoManager)
        {
            _repoManager = repoManager;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync(CandidateWithAwardParameter parameter)
        {
            var candidates = await _repoManager.candidate.GetAllCandidateAsync(parameter);
            
            if (candidates == null)
            {
                throw new Exception("empty data");
            }
            
            return candidates;
        }

        public async Task<IEnumerable<CandidateWithAward>> GetAllCandidatesWithAwardAsync(CandidateWithAwardParameter? parameter)
        {
            
            var result = await _repoManager.candidate.GetAllCandidateWithAwardAsync(parameter);

            return result;
        }

        public async Task CreateCandidate(Candidate candidate,CreateCandidateRequest createCandidateRequest)
        {
            await _repoManager.candidate.CreateCandidate(candidate,createCandidateRequest);
            
        }

        public async Task<CandidateWithAward> GetCandidate(int id)
        {
           return await _repoManager.candidate.GetCandidateByIdAsync(id);
        }

        public async Task Delete(Candidate candidate)
        {
            _repoManager.candidate.DeleteCandidate(candidate);
            await _repoManager.SaveChanges();
        }

        public async Task<Candidate> GetCandidateByIdForRemoving(int id)
        {
            return await _repoManager.candidate.GetCandidateByIdForRemoving(id);
           
        }

        public async Task UpdateCandidate(Candidate candidate, UpdateCandidateParameters updateCandidateParameters)
        {
            await _repoManager.candidate.UpdateCandidate(candidate,updateCandidateParameters);
       
        }
    }
}
