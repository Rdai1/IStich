using IStitch.Data;
using IStitch.Interface;
using IStitch.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace IStitch.Repository
{
    public class CustomerItemRepository : ICustomerItemRepository
    {
        private readonly AppDbContext _context;
        public CustomerItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(CustomerItems item)
        {
            _context.Add(item);
            return Save();
        }

        public bool Delete(CustomerItems item)
        {
            _context.Remove(item);
            return Save();
        }

        public async Task<IEnumerable<CustomerItems>> GetAll()
        {
            return await _context.CusItems.ToListAsync();
        }

        public async Task<IEnumerable<CustomerItems>> GetAllWithCustomerId(string Id)
        {
            return await _context.CusItems.Where(i => i.CustomerId == Id).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CustomerItems item)
        {
            _context.Update(item);
            return Save();
        }
    }
}
