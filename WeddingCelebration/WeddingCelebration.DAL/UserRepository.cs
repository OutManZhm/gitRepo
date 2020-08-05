using Dapper;
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

    public class UserRepository : IUserRepository
    {
        public DBContext _dBContext;

        public UserRepository(DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<bool> AddAsync(User prod)
        {

            return await _dBContext.DbConnection.InsertAsync(prod) > 0;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {

            return await _dBContext.DbConnection.GetAllAsync<User>();
        }

        public async Task<User> GetByIDAsync(int id)
        {

            return await _dBContext.DbConnection.GetAsync<User>(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dBContext.DbConnection.GetAsync<User>(id);
            return await _dBContext.DbConnection.DeleteAsync(entity);
        }

        public async Task<bool> UpdateAsync(User prod)
        {
            return await _dBContext.DbConnection.UpdateAsync(prod);
        }
        [UnitOfWork]
        public virtual bool DeleteAll()
        {
            var entity = _dBContext.DbConnection.Get<User>("1");
            _dBContext.DbConnection.Update(entity);
            return _dBContext.DbConnection.Delete<User>(entity);
        }

        public User FindUserByuAccount(string uaccount, string upassword)
        {
            string sql = @"SELECT * from User where uAccount=@uaccount and uPassword=@upassword and uStatus=1";
            var result = _dBContext.DbConnection.Query<User>(sql, new { uaccount,  upassword }).AsList();
            return result.Count>0? result[0]:null;
        }

    }
}
