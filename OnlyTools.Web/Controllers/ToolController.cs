using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Models;
using System.Security.Claims;

namespace OnlyTools.Web.Controllers
{
    [Authorize]
    public class ToolController : Controller
    {
        private readonly IToolServices _services;
        public ToolController(IToolServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> All()
        {
            var tools = await _services.GetAllToolsAsync();
            return View(tools);
        }

        [HttpGet]
        public async Task<IActionResult> AddTool() 
        {
            var tool = new ToolModel();
            return View(tool);
        }

        [HttpPost]
        public async Task<IActionResult> AddTool(ToolModel tool) 
        {
            string userId = GetUserId();
            tool.OwnerID = userId;
            //tool.Owner = new ToolOwner() 
            //{
            //    Id = userId,
            //    Email = User.Identity.Name,
            //};
            //if (!ModelState.IsValid) 
            //{
            //    return View(tool);
            //}
            await _services.AddNewToolAsync(tool, userId);
            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
