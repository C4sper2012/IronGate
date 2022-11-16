using Irongate.Repository.Domain.Context;
using Irongate.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Irongate.Repository.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly IrongateContext _dbContext;
    public GenericRepository(IrongateContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<T> GetById(object id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    
    public async Task<List<T>> GetAll()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }
}