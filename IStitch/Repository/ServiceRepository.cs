using IStitch.Interface;
using IStitch.Models;
using Microsoft.EntityFrameworkCore;
using IStitch.Data;

namespace IStitch.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;
        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(Service ser)
        {
            _context.Add(ser);
            return Save();
        }

        public bool Delete(Service ser)
        {
            _context.Remove(ser);
            return Save();
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await _context.Service.ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetAllWithCategory(string category)
        {
            return await _context.Service.Where(i => i.Category == category).ToListAsync();
        }

        public async Task<Service> GetByName(string name)
        {
            return await _context.Service.FirstOrDefaultAsync(i => i.ServiceName == name);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Service ser)
        {
            _context.Update(ser);
            return Save();
        }
    }
}
