using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeddingCelebration.Model.Entity;

namespace WeddingCelebration.IDAL
{
    public interface IUserRepository : IRepository
    {
        Task<bool> AddAsync(User prod);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIDAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(User prod);
        bool DeleteAll();

        User FindUserByuAccount(string uaccount, string upassword);
    }
}
