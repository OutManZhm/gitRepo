
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingCelebration.IDAL;
using WeddingCelebration.IService;
using WeddingCelebration.Model.Entity;

namespace WeddingCelebration.Service
{
    public class BarrageService: IBarrageService
    {
        private readonly IBarrageRepository _barrageRepository;
        public BarrageService(IBarrageRepository barrageRepository)
        {
            _barrageRepository = barrageRepository;
        }

        public Task<bool> AddAsync(Barrage prod)
        {
            return _barrageRepository.AddAsync(prod);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _barrageRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Barrage>> GetAllAsync()
        {
            return _barrageRepository.GetAllAsync();
        }

        public Task<Barrage> GetByIDAsync(int id)
        {
            return _barrageRepository.GetByIDAsync(id);
        }

        public Task<bool> UpdateAsync(Barrage prod)
        {
            return _barrageRepository.UpdateAsync(prod);
        }
    }
}
