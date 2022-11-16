using Irongate.Repository.Domain.Models;

namespace Irongate.Repository.Interfaces;

public interface IClimateRepository : IGenericRepository<Climate>
{
    
    public Task<List<Climate>> GetAll();
    public Task<Climate> GetById(int id);
}