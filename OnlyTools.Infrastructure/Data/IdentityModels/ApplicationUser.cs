using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlyTools.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlyTools.Infrastructure.Data.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Comment("profile picture, stored as a byte array, optional")]
        public byte[]? ProfilePicture { get; set; }
    }
}
