using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAwardRepo:IRepositoryBase<Award>
    {
        Task<IEnumerable<Award>> GetAllAward();
        Task<Award> GetAward(int id);
        void UpdateAward(Award award);
        void DeleteAward(Award award);
        void CreateAward(Award award);  

    }
}
