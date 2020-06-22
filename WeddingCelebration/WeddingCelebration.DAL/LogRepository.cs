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
  public  class LogRepository : ILogRepository
    {
        public DBContext _dBContext;

        public LogRepository(DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<bool> AddAsync(Log prod)
        {

            return await _dBContext.DbConnection.InsertAsync(prod) > 0;
        }

        public async Task<IEnumerable<Log>> GetAllAsync()
        {

            return await _dBContext.DbConnection.GetAllAsync<Log>();
        }

        public async Task<Log> GetByIDAsync(int id)
        {

            return await _dBContext.DbConnection.GetAsync<Log>(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dBContext.DbConnection.GetAsync<Log>(id);
            return await _dBContext.DbConnection.DeleteAsync(entity);
        }

        public async Task<bool> UpdateAsync(Log prod)
        {
            return await _dBContext.DbConnection.UpdateAsync(prod);
        }
    }
}
