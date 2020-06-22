using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeddingCelebration.Model.Entity;

namespace WeddingCelebration.IService
{
    public interface ILogService : IWeddBaseService
    {
        Task<bool> AddAsync(Log prod);
        Task<IEnumerable<Log>> GetAllAsync();
        Task<Log> GetByIDAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
