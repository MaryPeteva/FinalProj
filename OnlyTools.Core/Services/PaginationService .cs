using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using OnlyTools.Core.Contracts;
using OnlyTools.Models;

namespace OnlyTools.Core.Services
{
    public class PaginationService:IPaginationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelperFactory _urlHelperFactory;

        public PaginationService(IHttpContextAccessor httpContextAccessor, IUrlHelperFactory urlHelperFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _urlHelperFactory = urlHelperFactory;
        }

        public PaginationModel CreatePaginationModel(int pageIndex, int totalPages, bool hasPreviousPage, bool hasNextPage, string action, string controller, object routeValues)
        {
            return new PaginationModel(_httpContextAccessor, _urlHelperFactory)
            {
                PageIndex = pageIndex,
                TotalPages = totalPages,
                HasPreviousPage = hasPreviousPage,
                HasNextPage = hasNextPage,
                Action = action,
                Controller = controller,
                RouteValues = routeValues
            };
        }
    }
}
