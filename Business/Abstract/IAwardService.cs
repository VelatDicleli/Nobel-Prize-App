using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAwardService
    {
        Task<IEnumerable<Award>> GetAllAwards();
        Task<Award> GetAwardById(int id);
        Task UpdateAward(Award award);
        Task DeleteAward(Award award);
        Task CreateAward(Award award);


    }
}
