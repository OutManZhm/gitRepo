using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeddingCelebration.Model.Entity;

namespace WeddingCelebration.IDAL
{
    public interface IBarrageRepository : IRepository
    {
        Task<bool> AddAsync(Barrage prod);
        Task<IEnumerable<Barrage>> GetAllAsync();
        Task<Barrage> GetByIDAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Barrage prod);
        bool DeleteAll();
    }
}
