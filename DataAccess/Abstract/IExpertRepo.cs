using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IExpertRepo : IRepositoryBase<Expert>
    {
        Task<Expert> GetExpert(int id);
        Task<IEnumerable<Expert>> GetAllExperts();
        void CreateExpert(Expert expert);
        void DeleteExpert(Expert expert);
        void UpdateExpert(Expert expert);
    }
}
