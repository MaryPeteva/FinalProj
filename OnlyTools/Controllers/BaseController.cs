using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OnlyTools.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
