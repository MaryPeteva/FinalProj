
namespace OnlyTools.Core.Contracts
{
    public interface ILikeServices
    {
        Task LikeTipAsync(Guid userId, int tipId);
    }
}
