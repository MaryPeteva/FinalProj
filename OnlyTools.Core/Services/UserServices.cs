using Microsoft.AspNetCore.Http;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models.User;
using OnlyTools.Infrastructure.Data;
using OnlyTools.Infrastructure.Data.IdentityModels;

namespace OnlyTools.Core.Services
{
    public class UserServices : IUserServices
    {
        readonly OnlyToolsDbContext context;
        public UserServices(OnlyToolsDbContext _context)
        {
            context = _context;
        }
        public async Task<UserModel> GetProfileAsync(Guid id)
        {
            ApplicationUser user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            
            UserModel profile = new UserModel
            {
                UserName = user.UserName,
                Password = user.PasswordHash,
                Email = user.Email,
                ProfilePicture = user.ProfilePicture,
                PhoneNumber = user.PhoneNumber
            };
            return profile;
        }

        public async Task UploadProfilePicture(Guid id, IFormFile file)
        {
            await Console.Out.WriteLineAsync("IN SERVICE");
            ApplicationUser user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            // Read the uploaded file content into a byte array
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                user.ProfilePicture = memoryStream.ToArray();
            }

            await context.SaveChangesAsync();
        }
    }
}
