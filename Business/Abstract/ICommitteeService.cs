using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommitteeService
    {
        Task<IEnumerable<Committee>> GetAllCommitties();
        Task<Committee> GetCommitteeById(int id);
        Task CreateCommittee(Committee committee);
        Task DeleteCommitteeById(Committee committee);
        Task UpdateCommittee(Committee committee);
    }
}
