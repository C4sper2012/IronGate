using System.Reflection.Metadata;
using Irongate.Repository.Interfaces;
using Org.BouncyCastle.Crypto.Signers;

namespace Irongate.Service;

public abstract class GenericService<T, I, E> : IGenericService<T> where T : class where I : IGenericRepository<E> where E : class
{
    private readonly I _genericRepository;
    private readonly MappingService _mappingService;
    private readonly string _entityName = typeof(E).ToString().Replace("Repository.", "");

    public GenericService(I genericRepository, MappingService mappingService)
    {
        _genericRepository = genericRepository;
        _mappingService = mappingService;
    }

    public async Task<T> GetById()
    {
        try
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<T>> GetAll()
    {
        try
        {
            List<T> tempList = _mappingService._mapper.Map<List<T>>(await _genericRepository.GetAll());
            return tempList;
        }
        catch (Exception e)
        {
            return new List<T>();
        }
    }
}