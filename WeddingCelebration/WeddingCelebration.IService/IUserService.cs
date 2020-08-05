using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeddingCelebration.Model.Entity;

namespace WeddingCelebration.IService
{

    public interface IUserService : IWeddBaseService
    {
        Task<bool> AddAsync(User prod);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIDAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(User prod);
        User FindUserByuAccount(string uaccount, string upassword);
    }

}
