using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICommitteeRepo : IRepositoryBase<Committee>
    {
        Task<IEnumerable<Committee>> GetAllCommitee();
        Task<Committee> GetCommitteeById(int id);
        void DeleteCommittee(Committee committee);
        void UpdateCommitte(Committee committee);
        void Create(Committee committee);
        
    }
}
