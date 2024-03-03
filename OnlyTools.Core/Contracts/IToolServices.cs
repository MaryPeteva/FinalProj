using OnlyTools.Core.Models;

namespace OnlyTools.Core.Contracts
{
    public interface IToolServices
    {
        Task AddNewToolAsync(ToolModel tool, string userId);
        Task<IEnumerable<ToolModel>> GetAllToolsAsync();
    }
}
