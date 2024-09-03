using IStitch.Models;

namespace IStitch.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(String id);
        Task<User> GetByPhoneNumber(String number);
        bool Add(User sers);
        bool Update(User sers);
        bool Delete(User sers);
        bool Save();
    }
}
