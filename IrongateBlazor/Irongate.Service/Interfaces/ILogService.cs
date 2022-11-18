using Irongate.Service.Models;

namespace Irongate.Service.Interfaces
{
    public interface ILogService
    {
        public Task DeleteAsync();
        public Task CreateAsync(Log log);
        public Task<List<Log>> GetLogs();

    }
}