namespace OnlyTools.Core.Models.Like
{
    public class LikeModel
    {
        public LikeModel(Guid userId, int tipId)
        {
            UserId = userId;
            TipId = tipId;
        }

        public Guid UserId { get; set; }
        public int TipId { get; set; }
    }
}
