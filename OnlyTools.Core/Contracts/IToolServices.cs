using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Models;

namespace OnlyTools.Core.Contracts
{
    public interface IToolServices
    {
        Task AddNewToolAsync(ToolUploadModel tool);
        Task DeleteToolAsync(int id);
        Task<IEnumerable<ToolModel>> GetAllToolsAsync();
        Task<ToolDetailsModel> GetSpecificToolById(int id);
        Task RentToolAsync(ToolDetailsModel tool, string userId);
        Task UpdateToolAsync(int id, ToolUploadModel tool);
    }
}
