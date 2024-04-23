using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OnlyTools.Controllers
{
    public class BaseController : Controller
    {
        protected async Task<(IEnumerable<T> items, int totalPages, bool hasPreviousPage, bool hasNextPage)> Paginate<T>(IEnumerable<T> items, int page, int pageSize)
        {
            int totalItems = items.Count();
            int skip = (page - 1) * pageSize;
            items = items.Skip(skip).Take(pageSize).ToList();

            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            bool hasPreviousPage = page > 1;
            bool hasNextPage = page < totalPages;

            return (items, totalPages, hasPreviousPage, hasNextPage);
        }

        public Guid GetUserId()
        {

            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdString, out Guid userId))
            {
                return userId;
            }
            else
            {
                throw new InvalidOperationException("User ID is not in a valid format.");
            }
        }
    }
}
