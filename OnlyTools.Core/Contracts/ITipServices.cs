﻿
using OnlyTools.Core.Models.Tips;

namespace OnlyTools.Core.Contracts
{
    public interface ITipServices
    {
        Task AddNewTipAsync(TipPostModel tip);
        Task DeleteTipAsync(int id);
        Task<IEnumerable<TipsAllModel>> GetAllTipsAsync();
        Task<IEnumerable<TipsAllModel>> GetMyTipsAsync(Guid myId);
        Task<TipsDetailedModel> GetSpecificTipByIdAsync(int id);
        Task LikeTipAsync(Guid myId, int id);
        Task UpdateTipAsync(int id, TipPostModel tip);
    }
}
