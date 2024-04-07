using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Models.Category;
using OnlyTools.Core.Models.Tool;
using OnlyTools.Infrastructure.Data.Models;

namespace OnlyTools.Core.Contracts
{
    public interface IToolServices
    {
        Task AddNewToolAsync(ToolUploadModel tool);
        Task DeleteToolAsync(int id);
        Task<IEnumerable<ToolModel>> GetAllToolsAsync();
        Task<IEnumerable<ToolModel>> GetMyRentedToolsAsync(Guid myId);
        Task<IEnumerable<ToolModel>> GetMyToolsAsync(Guid myId);
        Task<ToolDetailsModel> GetSpecificToolByIdAsync(int id);
        Task RentToolAsync(int toolId, Guid userId);
        Task ReturnToolAsync(int id);
        Task UpdateToolAsync(int id, ToolUploadModel tool);
    }
}
