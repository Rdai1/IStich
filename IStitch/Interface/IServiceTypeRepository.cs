using IStitch.Models;

namespace IStitch.Interface
{
    public interface IServiceTypeRepository
    {
        Task<IEnumerable<ServiceType>> GetAll();
        Task<ServiceType> GetByCategory(String Category);
        bool Add(ServiceType sers);
        bool Update(ServiceType sers);
        bool Delete(ServiceType sers);
        bool Save();
    }
}
