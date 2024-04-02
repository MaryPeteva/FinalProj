using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Models.Tool;

namespace OnlyTools.Core.Contracts
{
    public interface IToolServices
    {
        Task AddNewToolAsync(ToolUploadModel tool);
        Task DeleteToolAsync(int id);
        Task<IEnumerable<ToolModel>> GetAllToolsAsync();
        Task<IEnumerable<ToolModel>> GetMyToolsAsync(string myId);
        Task<ToolDetailsModel> GetSpecificToolByIdAsync(int id);
        Task RentToolAsync(int toolId, string userId);
        Task UpdateToolAsync(int id, ToolUploadModel tool);
    }
}
