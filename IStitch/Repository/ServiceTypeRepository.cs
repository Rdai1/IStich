using IStitch.Interface;
using IStitch.Models;
using IStitch.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace IStitch.Repository
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly AppDbContext _context;
        public ServiceTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(ServiceType sers)
        {
            _context.Add(sers);
            return Save();
        }

        public bool Delete(ServiceType sers)
        {
            _context.Remove(sers);
            return Save();
        }

        public async Task<IEnumerable<ServiceType>> GetAll()
        {
            return await _context.ServiceType.ToListAsync();
        }

        public async Task<ServiceType> GetByCategory(string Category)
        {
            return await _context.ServiceType.FirstOrDefaultAsync(i =>i.Category == Category);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ServiceType sers)
        {
            _context.Update(sers);
            return Save();
        }
    }
}
