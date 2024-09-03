using IStitch.Models;

namespace IStitch.Interface
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAll();
        Task<IEnumerable<Service>> GetAllWithCategory(string category);
        Task<Service> GetByName(string name);
        bool Add(Service ser);
        bool Update(Service ser);
        bool Delete(Service ser);
        bool Save();
    }
}
