using System.Reflection.Metadata;
using Org.BouncyCastle.Crypto.Signers;

namespace Irongate.Service;

public abstract class GenericService<T, I, E> : IGenericService<T> where T : class where I : IGenericService<E> where E : class
{
    private readonly I _genericRepository;
    private readonly MappingService _mappingService;
    private readonly string _entityName = typeof(E).ToString().Replace("Repository.", "");

    public GenericService(I genericRepository, MappingService mappingService)
    {
        _genericRepository = genericRepository;
        _mappingService = mappingService;
    }

    public async Task Create(T entity)
    {
        try
        {
            await _genericRepository.Create(_mappingService._mapper.Map<E>(entity));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task Update(T entity)
    {
        try
        {
            await _genericRepository.Update(_mappingService._mapper.Map<E>(entity));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task Delete(T entity)
    {
        try
        {
            await _genericRepository.Delete(_mappingService._mapper.Map<E>(entity));
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