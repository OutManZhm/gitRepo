using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeddingCelebration.Model.Entity;

namespace WeddingCelebration.IDAL
{

    public interface ILogRepository : IRepository
    {
        Task<bool> AddAsync(Log prod);
        Task<IEnumerable<Log>> GetAllAsync();
        Task<Log> GetByIDAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Log prod);
    }
}
