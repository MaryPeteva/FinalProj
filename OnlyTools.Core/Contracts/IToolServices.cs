using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Models;

namespace OnlyTools.Core.Contracts
{
    public interface IToolServices
    {
        Task AddNewToolAsync(ToolUploadModel tool);
        Task<IEnumerable<ToolModel>> GetAllToolsAsync();
        Task<ToolDetailsModel> GetToolDetails(int id);
        Task UpdateToolAsync(int id, ToolUploadModel tool);
    }
}
