using Microsoft.AspNetCore.Http;
using OnlyTools.Core.Models.User;

namespace OnlyTools.Core.Contracts
{
    public interface IUserServices
    {
        Task<UserModel> GetProfileAsync(Guid id);
        Task UploadProfilePicture(Guid id, IFormFile file);
    }
}
