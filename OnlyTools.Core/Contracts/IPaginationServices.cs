using OnlyTools.Models;
namespace OnlyTools.Core.Contracts
{

    public interface IPaginationServices
    {
        PaginationModel CreatePaginationModel(int pageIndex, int totalPages, bool hasPreviousPage, bool hasNextPage, string action, string controller, object routeValues);
    }
}
