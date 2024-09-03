using IStitch.Models;

namespace IStitch.Interface
{
    public interface ICustomerItemRepository
    {
        Task<IEnumerable<CustomerItems>> GetAll();
        Task<IEnumerable<CustomerItems>> GetAllWithCustomerId(string id);
        bool Add(CustomerItems item);
        bool Update(CustomerItems item);
        bool Delete(CustomerItems item);
        bool Save();
    }
}
