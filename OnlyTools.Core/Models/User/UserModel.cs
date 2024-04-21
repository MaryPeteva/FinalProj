using OnlyTools.Core.Models.Like;
using OnlyTools.Core.Models.Tips;
using OnlyTools.Core.Models.Tool;
using System.ComponentModel.DataAnnotations;

namespace OnlyTools.Core.Models.User
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<ToolModel> OwnedTools { get; set; }
        public IEnumerable<ToolModel> RentedTools { get; set; }
        public IEnumerable<TipsAllModel> PostedTips { get; set; }
        public IEnumerable<LikeModel> LikedTips { get; set; }
        
    }
}
