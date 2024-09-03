using IStitch.Data;
using IStitch.Interface;
using IStitch.Models;
using Microsoft.EntityFrameworkCore;

namespace IStitch.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(User sers)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User sers)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByPhoneNumber(string number)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.PhoneNumber == number);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(User sers)
        {
            throw new NotImplementedException();
        }
    }
}
