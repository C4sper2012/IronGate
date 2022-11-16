using Irongate.Repository.Domain.Context;
using Irongate.Repository.Domain.Models;
using Irongate.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Irongate.Repository.Repository;

public class ClimateRepository : GenericRepository<Climate>, IClimateRepository
{
    private readonly IrongateContext _dbContext;
    
    public ClimateRepository(IrongateContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Climate>> GetAll()
    {
        return await _dbContext.Climates.ToListAsync();
    }

    public async Task<Climate> GetById(int id)
    {
        return await _dbContext.Climates.SingleAsync(x => x.ID == id);
    }
}