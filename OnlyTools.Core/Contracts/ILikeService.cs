
namespace OnlyTools.Core.Contracts
{
    public interface ILikeService
    {
        Task LikeTipAsync(Guid userId, int tipId);
    }
}
