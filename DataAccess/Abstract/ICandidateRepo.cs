
using Entities;
using Entities.ComplexTypeEntities;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICandidateRepo : IRepositoryBase<Candidate>
    {
        Task<CandidateWithAward> GetCandidateByIdAsync(int id);
        Task<IEnumerable<CandidateWithAward>> GetAllCandidateWithAwardAsync(CandidateWithAwardParameter parameter);
        Task<IEnumerable<Candidate>> GetAllCandidateAsync(CandidateWithAwardParameter parameter);
        Task CreateCandidate(Candidate candidate,CreateCandidateRequest createCandidateRequest);  
        void DeleteCandidate(Candidate candidate);
        Task<Candidate> GetCandidateByIdForRemoving(int id);
        Task UpdateCandidate(Candidate candidate, UpdateCandidateParameters updateCandidateParameters);
        
    }
}
