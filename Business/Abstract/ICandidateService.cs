
using DataAccess.Abstract;
using Entities;
using Entities.ComplexTypeEntities;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync(CandidateWithAwardParameter parameter);
        Task<IEnumerable<CandidateWithAward>> GetAllCandidatesWithAwardAsync(CandidateWithAwardParameter parameter);
        Task CreateCandidate(Candidate candidate, CreateCandidateRequest createCandidateRequest);
        Task<CandidateWithAward> GetCandidate(int id);
        Task Delete(Candidate candidate);
        Task<Candidate> GetCandidateByIdForRemoving(int id);
        Task UpdateCandidate(Candidate candidate,UpdateCandidateParameters updateCandidateParameters);


    }
}
