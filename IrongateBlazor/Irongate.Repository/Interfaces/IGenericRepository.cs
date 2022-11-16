namespace Irongate.Repository.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(object id);
    Task<List<T>> GetAll();
}