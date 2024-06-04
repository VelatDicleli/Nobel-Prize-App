
using DataAccess.Abstract;
using DataAccess.Ef_Core;
using DataAccess.Ef_Core.Repository;
using Entities;
using Entities.ComplexTypeEntities;
using Entities.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace DataAccess.Concrete
{
    public class CandidateRepo : RepositoryBase<Candidate>, ICandidateRepo
    {
        public CandidateRepo(RepositoryContext context) : base(context)
        {
        }

       


        public async Task CreateCandidate(Candidate candidate, CreateCandidateRequest createCandidateRequest)
        {

            _context.Candidate.Add(candidate);
            await _context.SaveChangesAsync();

            Candidate_Award candidate_Award = new()
            {
                CandidateId = candidate.CandidateId,
                AwardId = createCandidateRequest.AwardId,
                
            };
            Candidate_Committee candidate_Committee = new()
            {
                CandidateId = candidate.CandidateId,
                CommitteeId = createCandidateRequest.CommitteeId,
                Result = createCandidateRequest.Result,
                EvaluationDate = createCandidateRequest.EvaluationDate


            };
            Candidate_Organization candidate_Organization = new()
            {
               CandidateId = candidate.CandidateId,
               OrganizationId = createCandidateRequest.OrganizationId,
               
            };

           
            _context.Candidate_Award.Add(candidate_Award);
            _context.Candidate_Committee.Add(candidate_Committee);
            _context.Candidate_Organization.Add(candidate_Organization);

            await _context.SaveChangesAsync();
        
            
        }

        

        public void DeleteCandidate(Candidate candidate)
        {   
            Delete(candidate);
        }

      

        public async Task<IEnumerable<Candidate>> GetAllCandidateAsync(CandidateWithAwardParameter parameter)
        {
            return FindAll().OrderBy(x=>x.CandidateId).Search(parameter).ToList();
                
        }

      

        public async Task<IEnumerable<CandidateWithAward>> GetAllCandidateWithAwardAsync(CandidateWithAwardParameter p)
        {
            var candidateWithAward = from candidate in _context.Candidate
                                     join candidateAward in _context.Candidate_Award on candidate.CandidateId equals candidateAward.CandidateId
                                     join candidateOrganization in _context.Candidate_Organization on candidate.CandidateId equals candidateOrganization.CandidateId
                                     join committeeCandidate in _context.Candidate_Committee on candidate.CandidateId equals committeeCandidate.CandidateId
                                     select new CandidateWithAward()
                                     {
                                         CandidateId = candidate.CandidateId,
                                         FirstName = candidate.FirstName,
                                         LastName = candidate.LastName,
                                         CandidacyDate = candidate.CandidacyDate,
                                         FieldOfScience= candidate.FieldOfScience,
                                         Nationality = candidate.Nationality,
                                         CandidacyNumber = candidate.CandidacyNumber,
                                         Category = candidateAward.Award.Category,
                                         Committee = committeeCandidate.Committee.CommitteeCategory,
                                         DescriptorName = candidateAward.Award.DescriptorName,
                                         OrganizationName = candidateOrganization.Organization.Name

                                     };
                                     
            

            return await candidateWithAward.OrderBy(c=>c.CandidateId)
                        .Search(p)
                        .ToListAsync();


        }

        public async Task<CandidateWithAward> GetCandidateByIdAsync(int id)
        {
            var candidateWithAward = from candidate in _context.Candidate
                                     join candidateAward in _context.Candidate_Award on candidate.CandidateId equals candidateAward.CandidateId into awards
                                     from award in awards.DefaultIfEmpty()
                                     join candidateOrganization in _context.Candidate_Organization on candidate.CandidateId equals candidateOrganization.CandidateId into organizations
                                     from organization in organizations.DefaultIfEmpty()
                                     join committeeCandidate in _context.Candidate_Committee on candidate.CandidateId equals committeeCandidate.CandidateId into committees
                                     from committee in committees.DefaultIfEmpty()
                                     where candidate.CandidateId == id
                                     select new CandidateWithAward()
                                     {
                                         CandidateId = candidate.CandidateId,
                                         AwardId = award != null ? (int)award.AwardId : 0,
                                         CommitteeId = committee != null ? (int)committee.CommitteeId : 0,
                                         OrganizationId = organization != null ? (int)organization.OrganizationId : 0,
                                         FirstName = candidate.FirstName,
                                         LastName = candidate.LastName,
                                         CandidacyDate = candidate.CandidacyDate,
                                         FieldOfScience = candidate.FieldOfScience,
                                         Nationality = candidate.Nationality,
                                         CandidacyNumber = candidate.CandidacyNumber,
                                         DateOfBirth = candidate.DateOfBirth,
                                         Category = award != null ? award.Award.Category : null,
                                         DescriptorName = award != null ? award.Award.DescriptorName : null,
                                         EvaluationDate = committee != null ? committee.EvaluationDate : DateTime.MinValue
                                     };

            return await candidateWithAward.FirstOrDefaultAsync();


            //return await FindByCondition(c => c.CandidateId == id).SingleOrDefaultAsync();

        }

        public async Task<Candidate> GetCandidateByIdForRemoving(int id)
        {
            return await FindByCondition(c => c.CandidateId == id).FirstOrDefaultAsync();
        }

        


        public async Task UpdateCandidate(Candidate candidate, UpdateCandidateParameters updateCandidateParameters)
        {
            _context.Candidate.Update(candidate);

            Candidate_Award candidate_Award = null;
            Candidate_Committee candidate_Committee = null;
            Candidate_Organization candidate_Organization = null;

            if (updateCandidateParameters.update_awardId != null)
            {
                candidate_Award = new Candidate_Award
                {
                    CandidateId = candidate.CandidateId,
                    AwardId = (int)updateCandidateParameters.update_awardId
                };
            }

            if (updateCandidateParameters.update_committeeId != null)
            {
                candidate_Committee = new Candidate_Committee
                {
                    CandidateId = candidate.CandidateId,
                    CommitteeId = (int)updateCandidateParameters.update_committeeId,
                    Result = updateCandidateParameters.update_result,
                    EvaluationDate = (DateTime)updateCandidateParameters.update_evaluationDate
                };
            }

            if (updateCandidateParameters.update_organizationId != null)
            {
                candidate_Organization = new Candidate_Organization
                {
                    CandidateId = candidate.CandidateId,
                    OrganizationId = (int)updateCandidateParameters.update_organizationId
                };
            }

            var existingAward = await _context.Candidate_Award
                .FirstOrDefaultAsync(x => x.AwardId == updateCandidateParameters.AwardId && x.CandidateId == candidate.CandidateId);

            if (existingAward == null && candidate_Award != null)
            {
                _context.Candidate_Award.Add(candidate_Award);
            }
            else if (existingAward != null)
            {
                _context.Candidate_Award.Remove(existingAward);
                _context.Candidate_Award.Add(candidate_Award);
            }

            var existingOrganization = await _context.Candidate_Organization
                .FirstOrDefaultAsync(x => x.OrganizationId == updateCandidateParameters.OrganizationId && x.CandidateId == candidate.CandidateId);

            if (existingOrganization == null && candidate_Organization != null)
            {
                _context.Candidate_Organization.Add(candidate_Organization);
            }
            else if (existingOrganization != null)
            {
                _context.Candidate_Organization.Remove(existingOrganization);
                _context.Candidate_Organization.Add(candidate_Organization);
            }

            var existingCommittee = await _context.Candidate_Committee
                .FirstOrDefaultAsync(x => x.CommitteeId == updateCandidateParameters.CommitteeId && x.CandidateId == candidate.CandidateId);

            if (existingCommittee == null && candidate_Committee != null)
            {
                _context.Candidate_Committee.Add(candidate_Committee);
            }
            else if (existingCommittee != null)
            {
                _context.Candidate_Committee.Remove(existingCommittee);
                _context.Candidate_Committee.Add(candidate_Committee);
            }

            await _context.SaveChangesAsync(); 
        }


    }
}
