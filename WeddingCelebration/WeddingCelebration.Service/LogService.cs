
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingCelebration.IDAL;
using WeddingCelebration.IService;
using WeddingCelebration.Model.Entity;
namespace WeddingCelebration.Service
{
   public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public Task<bool> AddAsync(Log prod)
        {
            return _logRepository.AddAsync(prod);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _logRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Log>> GetAllAsync()
        {
            return _logRepository.GetAllAsync();
        }

        public Task<Log> GetByIDAsync(int id)
        {
            return _logRepository.GetByIDAsync(id);
        }

        public Task<bool> UpdateAsync(Log prod)
        {
            return _logRepository.UpdateAsync(prod);
        }
    }
}
