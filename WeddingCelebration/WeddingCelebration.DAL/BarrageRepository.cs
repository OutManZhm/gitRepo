using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using WeddingCelebration.IDAL;
using WeddingCelebration.Model.Entity;

namespace WeddingCelebration.DAL
{

    public class BarrageRepository : IBarrageRepository
    {
        public DBContext _dBContext;

        public BarrageRepository(DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<bool> AddAsync(Barrage prod)
        {

            return await _dBContext.DbConnection.InsertAsync(prod) > 0;
        }

        public async Task<IEnumerable<Barrage>> GetAllAsync()
        {

            return await _dBContext.DbConnection.GetAllAsync<Barrage>();
        }

        public async Task<Barrage> GetByIDAsync(int id)
        {

            return await _dBContext.DbConnection.GetAsync<Barrage>(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dBContext.DbConnection.GetAsync<Barrage>(id);
            return await _dBContext.DbConnection.DeleteAsync(entity);
        }

        public async Task<bool> UpdateAsync(Barrage prod)
        {
            return await _dBContext.DbConnection.UpdateAsync(prod);
        }
        [UnitOfWork]
        public virtual bool DeleteAll()
        {
            var entity = _dBContext.DbConnection.Get<Barrage>("1");
            _dBContext.DbConnection.Update(entity);
            return _dBContext.DbConnection.Delete<Barrage>(entity);
        }
    }
}
