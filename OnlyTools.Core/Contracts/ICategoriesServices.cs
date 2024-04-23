using OnlyTools.Core.Models.Category;

namespace OnlyTools.Core.Contracts
{
    public interface ICategoriesServices
    {
        Task<IEnumerable<CategoryModel>> GetToolCategoriesAsync();
        Task<IEnumerable<CategoryModel>> GetTipCategoriesAsync();
        Task<IEnumerable<CategoryModel>> GetJobsCategoriesAsync();
    }
}
