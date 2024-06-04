using Entities;
using Entities.ComplexTypeEntities;
using Entities.Parameters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Ef_Core
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<CandidateWithAward> Search(this IQueryable<CandidateWithAward> data, CandidateWithAwardParameter? parameter)
        {
            if (parameter is null)
                return data;
            
            if (!string.IsNullOrEmpty(parameter.FirstName))
            {
                data = data.Where(c => c.FirstName.Contains(parameter.FirstName));
            }
            if (!string.IsNullOrEmpty(parameter.LastName))
            {
                data = data.Where(c => c.LastName.Contains(parameter.LastName));
            }

            if (!string.IsNullOrEmpty(parameter.DescriptorName))
            {
                data = data.Where(c => c.DescriptorName.Contains(parameter.DescriptorName));
            }

            if (!string.IsNullOrEmpty(parameter.CandidacyNumber))
            {
                data = data.Where(c=>c.CandidacyNumber.ToString().Contains(parameter.CandidacyNumber));
            }

            if (!string.IsNullOrEmpty(parameter.Nationality))
            {
                data = data.Where(c => c.Nationality.Contains(parameter.Nationality));
            }

            return data;
            
        }


        public static IQueryable<Candidate> Search(this IQueryable<Candidate> data, CandidateWithAwardParameter? parameter)
        {
            if (parameter is null)
                return data;

            if (!string.IsNullOrEmpty(parameter.FirstName))
            {
                data = data.Where(c => c.FirstName.Contains(parameter.FirstName));
            }
            if (!string.IsNullOrEmpty(parameter.LastName))
            {
                data = data.Where(c => c.LastName.Contains(parameter.LastName));
            }


            if (!string.IsNullOrEmpty(parameter.CandidacyNumber))
            {
                data = data.Where(c => c.CandidacyNumber.ToString().Contains(parameter.CandidacyNumber));
            }

            if (!string.IsNullOrEmpty(parameter.Nationality))
            {
                data = data.Where(c => c.Nationality.Contains(parameter.Nationality));
            }

            return data;

        }
    }
}
