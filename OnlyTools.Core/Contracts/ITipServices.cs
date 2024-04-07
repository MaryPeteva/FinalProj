
using OnlyTools.Core.Models.Tips;

namespace OnlyTools.Core.Contracts
{
    public interface ITipServices
    {
        Task AddNewTipAsync(TipPostModel tip);
        Task<IEnumerable<TipsAllModel>> GetAllTipsAsync();
    }
}
