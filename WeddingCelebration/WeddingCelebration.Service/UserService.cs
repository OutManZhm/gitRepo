
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingCelebration.IDAL;
using WeddingCelebration.IService;
using WeddingCelebration.Model.Entity;

namespace WeddingCelebration.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<bool> AddAsync(User prod)
        {
            return _userRepository.AddAsync(prod);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task<User> GetByIDAsync(int id)
        {
            return _userRepository.GetByIDAsync(id);
        }

        public Task<bool> UpdateAsync(User prod)
        {
            return _userRepository.UpdateAsync(prod);
        }

        public User FindUserByuAccount(string uaccount, string upassword)
        {
            return _userRepository.FindUserByuAccount(uaccount, upassword);
        }
    }
}
