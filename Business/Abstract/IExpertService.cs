using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExpertService
    {
        Task<IEnumerable<Expert>> GetAllExperts();
        Task<Expert> GetExpertById(int id);
        Task CreateExpert(Expert expert);
        Task DeletExpert(Expert expert);
        Task UpdateExpert(Expert expert);

    }
}
